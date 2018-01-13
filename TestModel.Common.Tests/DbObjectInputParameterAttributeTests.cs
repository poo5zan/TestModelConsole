using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestModel.Common.Tests.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TestModel.Common.Tests
{
    public class DbObjectInputParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public DbObjectType DbObjectType { get; set; } = DbObjectType.StoredProcedure;
        public string UserDefinedDataTypeName { get; set; }
    }

    public enum DbObjectType
    {
        None = 0,
        StoredProcedure = 1,
        UserDefinedDataType = 2
    }

    public class Person
    {
        [DbObjectInputParameter]
        public string Name { get; set; }
        public int Age { get; set; }
        [DbObjectInputParameter(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }
        [DbObjectInputParameter(Name = "AnotherPersonParam", DbObjectType = DbObjectType.UserDefinedDataType, UserDefinedDataTypeName="AnotherPersonUdt")]
        public List<AnotherPerson> ArkoPerson { get; set; }
    }

    public class AnotherPerson
    {
        public int Id { get; set; }
        public string NewParam { get; set; }
    }

    [TestClass]
    public class DbObjectInputParameterAttributeTests
    {
        [TestMethod]
        public void CheckProperties()
        {
            //var dt = new DataTable();
            //var dt0 = new DataTable(null);
            //var dt1 = new DataTable("");
            //var dt2 = new DataTable("pujan");

            var person = new Person()
            {
                Name = null,
                Age = -13,
                DateOfBirth = DateTime.Now,
                ArkoPerson = new List<AnotherPerson>()
                { new AnotherPerson() { Id = 4, NewParam = "Lov" } }
            };

            var p = GetDbObjectInputParameters(person);
            var s = 0;
        }


        public Dictionary<string, object> GetDbObjectInputParameters(Object obj)
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
                    parameterValue = objEnumerable?.ToDataTable(property.Attribute.UserDefinedDataTypeName) ;
                }
                parameters.Add("@" + parameterName, parameterValue);
            }

            return parameters;
        }

    }
}
