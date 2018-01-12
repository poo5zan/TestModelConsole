using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestModelConsole.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var h = new List<Dictionary<string, object>>();
            var ld = new List<Dictionary<string, object>>();
            var d1 = new Dictionary<string, object>();
            d1.Add("id", 1);
            d1.Add("name", "pu");
            ld.Add(d1);
            var d2 = new Dictionary<string, object>();
            d2.Add("id", 2);
            d2.Add("name", "puja");
            ld.Add(d2);
            var d = new Dictionary<string, object>();
            d.Add("products", ld);

            var lds = JsonConvert.SerializeObject(d);
            
        }
    }
}
