using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Dec5_2016Test
    {
        [TestMethod]
        public void IsEvenSubset() {

            var dec5_2016 = new Dec5_2016();

            var result18_12 = dec5_2016.IsEvenSubset(18, 12);
            Assert.AreEqual(1, result18_12);

            var result18_32 = dec5_2016.IsEvenSubset(18, 32);
            Assert.AreEqual(0, result18_32);
        }

        [TestMethod]
        public void IsTwinoid()
        {
            var dec5_2016 = new Dec5_2016();

            var result1 = dec5_2016.IsTwinoid(new int[] { 3, 3, 2, 6, 7 });
            Assert.AreEqual(1, result1);

            var result2 = dec5_2016.IsTwinoid(new int[] { 3, 3, 2, 6, 6, 7 });
            Assert.AreEqual(0, result2);

            var result3 = dec5_2016.IsTwinoid(new int[] { 3, 3, 2, 7, 6, 7 });
            Assert.AreEqual(0, result3);

            var result4 = dec5_2016.IsTwinoid(new int[] { 3, 8, 5, 7, 3 });
            Assert.AreEqual(0, result4);
        }

        [TestMethod]
        public void IsBalanced() {
            var dec5_2016 = new Dec5_2016();

            var result1 = dec5_2016.IsBalanced(new int[]  { -2, 3, 2, -3 });
            Assert.AreEqual(1,result1);

            var result2 = dec5_2016.IsBalanced(new int[] {  -2, 2, 2, 2 });
            Assert.AreEqual(1,result2);

            var result3 = dec5_2016.IsBalanced(new int[] {  -5, 2, -2 });
            Assert.AreEqual(0,result3);
        }
    }
}
