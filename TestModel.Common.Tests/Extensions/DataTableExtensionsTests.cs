using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.Common.Extensions;

namespace TestModel.Common.Tests.Extensions
{    
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
