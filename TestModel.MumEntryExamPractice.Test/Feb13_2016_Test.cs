﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Feb13_2016_Test
    {

        [TestMethod]
        public void FactorTwoCount()
        {
            var feb13_2016 = new Feb13_2016();

            var result48 = feb13_2016.FactorTwoCount(48);
            Assert.AreEqual(4, result48);

            var result27 = feb13_2016.FactorTwoCount(27);
            Assert.AreEqual(0, result27);

        }

        [TestMethod]
        public void IsMeera()
        {
            var feb13_2016 = new Feb13_2016();

            var result1 = feb13_2016.IsMeera(new int[] { 4, 8, 6, 3, 2, 9, 8, 11, 8, 13, 12, 12, 6 });
            Assert.AreEqual(1, result1);

            var result2 = feb13_2016.IsMeera(new int[] { 2, 4, 6, 8, 6 });
            Assert.AreEqual(0, result2);

            var result3 = feb13_2016.IsMeera(new int[] { 2, 8, 7, 10, -4, 6 });
            Assert.AreEqual(0, result3);
        }

        [TestMethod]
        public void GoodSpread()
        {
            var feb13_2016 = new Feb13_2016();

            var result1 = feb13_2016.GoodSpread(new int[] { 2, 1, 2, 5, 2, 1, 5, 9 });
            Assert.AreEqual(1, result1);

            var result2 = feb13_2016.GoodSpread(new int[] { 3, 1, 3, 1, 3, 5, 5, 3 });
            Assert.AreEqual(0, result2);
            
        }

    }
}
