using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void Hello()
        {
            // [] positive character group
            var s = "hello pujan \"hi there \" go away";
            var pattern = new Regex("(?!^\".*?\")");// ^\".*?\"
            //[;\\s]
            var p = pattern.Replace(s, ",");
            //var p2 = new Regex("\".*?\"");

            var o = 0;


        }

    }
}
