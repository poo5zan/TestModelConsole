﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class April23_2016_Test
    {

        [TestMethod]
        public void Fill() {

            var april23_2016 = new April23_2016();

            int[] result1 = april23_2016.Fill(new int[]{ 1,2,3,5, 9, 12,-2,-1},3,10);
            int[] result1Expected = new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1 };
            for (int i = 0; i < result1.Length; i++)
            {
                Assert.AreEqual(result1Expected[i], result1[i]);
            }
           
            int[] result2 = april23_2016.Fill(new int[] { 4, 2, -3, 12 },1,5);
            int[] result2Expected = new int[] { 4, 4, 4, 4, 4 };
            for (int i = 0; i < result2.Length; i++)
            {
                Assert.AreEqual(result2Expected[i], result2[i]);
            }

            var result3 = april23_2016.Fill(new int[] { 2, 6, 9, 0, -3 },0,4);
            Assert.IsNull(result3);
        }

        [TestMethod]
        public void SumIsPower() {

            var april23_Test = new April23_2016();
            var result1 = april23_Test.SumIsPower(new int[] { 8, 8, 8, 8 });
            Assert.AreEqual(true, result1);

            var result2 = april23_Test.SumIsPower(new int[] { 8,8,8});
            Assert.AreEqual(false, result2);
        }

        [TestMethod]
        public void IsHollow() {
            var april23_2016 = new April23_2016();

            var result1 = april23_2016.IsHollow(new int[] { 1, 2, 4, 0, 0, 0, 3, 4, 5 });
            Assert.AreEqual(true, result1);

            var result11 = april23_2016.IsHollow(new int[] { 1, 2, 4, 0, 1, 0,0, 3, 4, 5 });
            Assert.AreEqual(false, result11);

            var result2 = april23_2016.IsHollow(new int[] { 1, 2, 0, 0, 0, 3, 4, 5 });
            Assert.AreEqual(false, result2);

            var result3 = april23_2016.IsHollow(new int[] { 1, 2, 4, 9, 0, 0, 0, 3, 4, 5 });
            Assert.AreEqual(false, result3);

            var result4 = april23_2016.IsHollow(new int[] { 1, 2, 0, 0, 3, 4 });
            Assert.AreEqual(false, result4);
        }
    }
}
