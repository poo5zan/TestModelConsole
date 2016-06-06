using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class March12_2016_Test
    {
        [TestMethod]
        public void IsPascal() {

            var march12_2016 = new March12_2016();

            var result6 = march12_2016.IsPascal(6);
            Assert.AreEqual(1, result6);

            var result15 = march12_2016.IsPascal(15);
            Assert.AreEqual(1, result15);

            var result7 = march12_2016.IsPascal(7);
            Assert.AreEqual(0, result7);

        }

        [TestMethod]
        public void IsMeeraArray() {

            var march21_2016 = new March12_2016();

            var result1 = march21_2016.IsMeeraArray(new int[] { 7, 6, 10, 1 });
            Assert.AreEqual(1, result1);

            var result2 = march21_2016.IsMeeraArray(new int[] { 7, 6, 10 });
            Assert.AreEqual(0, result2);

            var result3 = march21_2016.IsMeeraArray(new int[] { 6, 10, 1 });
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void IsSuff() {

            var march12_2016 = new March12_2016();

            var result1 = march12_2016.IsSuff(new int[] { 2, 10, 9, 3 });
            Assert.AreEqual(1, result1);

            var result2 = march12_2016.IsSuff(new int[] { 2, 2, 3, 3, 3 });
            Assert.AreEqual(1, result2);

            var result3 = march12_2016.IsSuff(new int[] { 1, 1, 1, 2, 1, 1 });
            Assert.AreEqual(1, result3);

            var result4 = march12_2016.IsSuff(new int[] { 0, -1, 1 });
            Assert.AreEqual(1, result4);

            var result5 = march12_2016.IsSuff(new int[] { 3, 4, 5, 7 });
            Assert.AreEqual(0, result5);


        }

    }
}
