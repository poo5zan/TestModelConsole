using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.Common.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, string tableName = "")
        {
            if (data == null)
            {
                return null;
            }

            PropertyDescriptorCollection properties = null;
            var type = typeof(T);
            if (type == typeof(Object))
            {
                //get type from list data
                var typeFromObject = data.FirstOrDefault()?.GetType();
                if (typeFromObject == null)
                {
                    return null;
                }
                type = typeFromObject;
            }

            properties = TypeDescriptor.GetProperties(type);

            if (properties == null || properties.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable(tableName);
            foreach (PropertyDescriptor prop in properties)
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? null;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static DataTable ToDataTable(this string data)
        {
            return (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));
        }
    }

}
