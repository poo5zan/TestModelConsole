using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class April9_2016_Test
    {
        [TestMethod]
        public void CountDigit() {
            var april9_2016 = new April9_2016();

            var result1 = april9_2016.CountDigit(32121,1);
            Assert.AreEqual(2, result1);

            var result2 = april9_2016.CountDigit(33331, 3);
            Assert.AreEqual(4, result2);

            var result3 = april9_2016.CountDigit(33331,6);
            Assert.AreEqual(0, result3);

            var result4 = april9_2016.CountDigit(3, 3);
            Assert.AreEqual(1, result4);
            var result5 = april9_2016.CountDigit(-543, 3);
            Assert.AreEqual(-1, result5);

            var result6 = april9_2016.CountDigit(445, -4);
            Assert.AreEqual(-1, result6);



        }


        [TestMethod]
        public void TestPrime()
        {
            var april9_2016 = new April9_2016();

            var result1 = april9_2016.IsPrime(1);
            Assert.AreEqual(1, result1);
            var result2 = april9_2016.IsPrime(2);
            Assert.AreEqual(1, result2);
            var result3 = april9_2016.IsPrime(3);
            Assert.AreEqual(1, result3);
            var result4 = april9_2016.IsPrime(4);
            Assert.AreEqual(0, result4);
            var result5 = april9_2016.IsPrime(5);
            Assert.AreEqual(1, result5);
            var result6 = april9_2016.IsPrime(6);
            Assert.AreEqual(0, result6);
            var result7 = april9_2016.IsPrime(7);
            Assert.AreEqual(1, result7);
            var result13 = april9_2016.IsPrime(13);
            Assert.AreEqual(1, result13);

            var result0 = april9_2016.IsPrime(0);
            Assert.AreEqual(0, result0);

            var result8 = april9_2016.IsPrime(8);
            Assert.AreEqual(0, result8);

            var result100 = april9_2016.IsPrime(100);
            Assert.AreEqual(0, result100);

            var result97 = april9_2016.IsPrime(97);
            Assert.AreEqual(1, result97);

            var resultn1 = april9_2016.IsPrime(-1);
            Assert.AreEqual(0, resultn1);


        }

        [TestMethod]
        public void IsBunkerArray() {
            var april9_2016 = new April9_2016();

            var result1 = april9_2016.IsBunkerArray(new int[] { 4, 9, 6, 7, 3 });
            Assert.AreEqual(1, result1);

            var result2 = april9_2016.IsBunkerArray(new int[] { 4, 9, 6, 15, 21});
            Assert.AreEqual(0, result2);
        }

        [TestMethod]
        public void IsMeeraArray() {
            var april9_2016 = new April9_2016();

            var result1 = april9_2016.IsMeeraArray(new int[] { 3, 5, -2 });
            Assert.AreEqual(0, result1);

            var result2 = april9_2016.IsMeeraArray(new int[] { 8, 3, 4 });
            Assert.AreEqual(1, result2);

            var result3 = april9_2016.IsMeeraArray(new int[] { 1, 5, 3 });
            Assert.AreEqual(0, result3);

        }
    }
}
