using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.Common.Attributes;

namespace TestModel.Common.Extensions
{
    public static class DbObjectInputParameterExtensions
    {
        public static Dictionary<string, object> ToDbObjectInputParameters<T>(this T obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            var parameters = new Dictionary<string, object>();
            var propertiesWithDbObjInputParam = from p in obj.GetType().GetProperties()
                                                let attr = p.GetCustomAttributes(typeof(DbObjectInputParameterAttribute), true)
                                                where attr.Length == 1
                                                select new { Property = p, Attribute = attr.First() as DbObjectInputParameterAttribute };

            if (propertiesWithDbObjInputParam == null ||
                !propertiesWithDbObjInputParam.Any())
            {
                return parameters;
            }

            foreach (var property in propertiesWithDbObjInputParam)
            {
                var parameterName = "";
                if (!String.IsNullOrWhiteSpace(property?.Attribute?.Name))
                {
                    parameterName = property?.Attribute?.Name;
                }
                else
                {
                    parameterName = property.Property.Name;
                }
                object parameterValue = null;
                if (property.Attribute.DbObjectType == DbObjectType.StoredProcedure)
                {
                    parameterValue = property.Property.GetValue(obj);
                }
                else if (property.Attribute.DbObjectType == DbObjectType.UserDefinedDataType)
                {
                    var objEnumerable = (IEnumerable<Object>)property.Property.GetValue(obj);
                    parameterValue = objEnumerable?.ToDataTable(property.Attribute.UserDefinedDataTypeName);
                }
                parameters.Add("@" + parameterName, parameterValue);
            }

            return parameters;
        }


    }
}
