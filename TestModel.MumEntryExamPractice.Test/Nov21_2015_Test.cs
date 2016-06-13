using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Nov21_2015_Test
    {

        [TestMethod]
        public void Fill()
        {
            var nov21_2015 = new Nov21_2015();

            var result1 = nov21_2015.Fill(new int[] { 1, 2, 3, 5, 9, 12, -2, -1 }, 3, 10);

            var result2 = nov21_2015.Fill(new int[] { 4, 2, -3, 12 }, 1, 5);

            var result3 = nov21_2015.Fill(new int[] { 2, 6, 9, 0, -3 }, 0, 4);
        }

        [TestMethod]
        public void SumIsPower()
        {
            var nov21_2015 = new Nov21_2015();

            var result1 = nov21_2015.SumIsPower(new int[] { 8, 8, 8, 8 });
            Assert.AreEqual(true, result1);

            var result2 = nov21_2015.SumIsPower(new int[] { 8, 8, 8 });
            Assert.AreEqual(false, result2);
        }

        [TestMethod]
        public void IsHollow() {
            var nov21_2015 = new Nov21_2015();

            var result1 = nov21_2015.IsHollow(new int[] { 1, 2, 4, 0, 0, 0, 3, 4, 5 });
            Assert.AreEqual(1, result1);
            var result2 = nov21_2015.IsHollow(new int[] { 1, 2, 0, 0, 0, 3, 4, 5 });
            Assert.AreEqual(0, result2);

            var result3 = nov21_2015.IsHollow(new int[] { 1, 2, 4, 9, 0, 0, 0, 3, 4, 5 });
            Assert.AreEqual(0, result3);

            var result4 = nov21_2015.IsHollow(new int[] { 1, 2, 0, 0, 3, 4 });
            Assert.AreEqual(0, result4);


        }

    }
}
