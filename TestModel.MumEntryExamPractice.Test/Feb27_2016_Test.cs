using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Feb27_2016_Test
    {

        [TestMethod]
        public void IsEvenSpaced()
        {
            var feb27_2016 = new Feb27_2016();

            var result1 = feb27_2016.IsEvenSpaced(new int[] { 100, 19, 131, 140 });
            Assert.AreEqual(0, result1);
            var result2 = feb27_2016.IsEvenSpaced(new int[] { 200, 1, 151, 160 });
            Assert.AreEqual(0, result2);
            var result3 = feb27_2016.IsEvenSpaced(new int[] { 200, 10, 151, 160 });
            Assert.AreEqual(1, result3);
            var result4 = feb27_2016.IsEvenSpaced(new int[] { 100, 19, -131, -140 });
            Assert.AreEqual(1, result4);
            var result5 = feb27_2016.IsEvenSpaced(new int[] { 80, -56, 11, -81 });
            Assert.AreEqual(0, result5);
        }

        [TestMethod]
        public void IsSub()
        {
            var feb27_2016 = new Feb27_2016();

            var result1 = feb27_2016.IsSub(new int[] { 13, 6, 3, 2 });
            Assert.AreEqual(1, result1);

            var result2 = feb27_2016.IsSub(new int[] { 11, 5, 3, 2 });
            Assert.AreEqual(0, result2);
        }


        [TestMethod]
        public void IsSym() {
            var feb27_2016 = new Feb27_2016();

            var result1 = feb27_2016.IsSym(new int[] { 2, 7, 9, 10, 11, 5, 8 });
            Assert.AreEqual(1, result1);

            var result2 = feb27_2016.IsSym(new int[] { 9, 8, 7, 13, 14, 17 });
            Assert.AreEqual(1, result2);

            var result3 = feb27_2016.IsSym(new int[] { 2, 7, 8, 9, 11, 13, 10 });
            Assert.AreEqual(0, result3);

        }

    }
}
