using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.Common.Tests.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data,string tableName = "")
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
               
        //public static DataTable ToDataTable(this string data)
        //{
        //    return (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));
        //}
    }

    [TestClass]
    public class DataTableExtensionsTests {
        [TestMethod]
        public void DataTableExtensionFromIenumerableObj()
        {            
            Object obj;
            //obj = new List<Pers>() { new Pers { Age=2,Name="4"},new Pers {Name = "fda" } };
            obj = new List<Pers>();
            var obji = (IEnumerable<Object>)obj;
            var d = obji.ToDataTable();
            //var dt = DataTableExtensions.GetDataTable(per, "hello");
        }

        [TestMethod]
        public void DataTableExtensionFromConcreteIenumerable()
        {            
            var pers = new List<Pers>() { new Pers { Age = 2, Name = "4" }, new Pers { Name = "fda" } };
            var d = pers.ToDataTable();
            //var dt = DataTableExtensions.GetDataTable(per, "hello");
        }

        public class Pers {
            public int Age { get; set; }
            public string Name { get; set; }  
        }

    }

}
