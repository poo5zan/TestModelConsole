﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class FuzzyMatcherTests
    {

        [TestMethod]
        public void DamerauLevenshteinDistanceStrTests()
        {
            var str1 = "dog";
            var str2 = "d";
            var e = FuzzyMatcher.DamerauLevenshteinDistanceStr(str1, str2,10);
            var p = 0;
        }

    }
}
