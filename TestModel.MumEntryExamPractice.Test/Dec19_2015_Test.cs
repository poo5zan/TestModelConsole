using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Dec19_2015_Test
    {
        [TestMethod]
        public void IsMeera()
        {
            var dec19_2015 = new Dec19_2015();

            var result6 = dec19_2015.IsMeera(6);
            Assert.AreEqual(1, result6);

            var result30 = dec19_2015.IsMeera(30);
            Assert.AreEqual(1, result30);

            var result21 = dec19_2015.IsMeera(21);
            Assert.AreEqual(0, result21);

        }

        [TestMethod]
        public void IsBunker() {
            var dec19_2016 = new Dec19_2015();

            var result1 = dec19_2016.IsBunker(new int[] { 7, 6, 10, 1 });
            Assert.AreEqual(1,result1);

            var result2 = dec19_2016.IsBunker(new int[] { 7, 6, 10 });
            Assert.AreEqual(0,result2);

            var result3 = dec19_2016.IsBunker(new int[] { 6, 10, 1 });
            Assert.AreEqual(0,result3);

            var result4 = dec19_2016.IsBunker(new int[] { 3, 7, 1, 8, 1 });
            Assert.AreEqual(1,result4);

           
        }

        [TestMethod]
        public void IsNice() {

            var dec19_2015 = new Dec19_2015();

            var result1 = dec19_2015.IsNice(new int[] { 2, 10, 9, 3 });
            Assert.AreEqual(1,result1);

            var result2 = dec19_2015.IsNice(new int[] { 2, 2, 3, 3, 3 });
            Assert.AreEqual(1,result2);

            var result3 = dec19_2015.IsNice(new int[] { 1, 1, 1, 2, 1, 1 });
            Assert.AreEqual(1,result3);

            var result4 = dec19_2015.IsNice(new int[] { 0, -1, 1 });
            Assert.AreEqual(1,result4);

            var result5 = dec19_2015.IsNice(new int[] { 3, 4, 5, 7 });
            Assert.AreEqual(0,result5);
        }

    }
}
