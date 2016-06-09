using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Jan9_2016_Test
    {
        [TestMethod]
        public void MinDistance()
        {
            var jan9_2016 = new Jan9_2016();

            var result63 = jan9_2016.MinDistance(63);
            Assert.AreEqual(2, result63);

            var result25 = jan9_2016.MinDistance(25);
            Assert.AreEqual(0, result25);

            var result11 = jan9_2016.MinDistance(11);
            Assert.AreEqual(-1, result11);
        }
        
        [TestMethod]
        public void IsWave() {
            var jan9_2016 = new Jan9_2016();

            var result1 = jan9_2016.IsWave(new int[] { 7, 2, 9, 10, 5 });
            Assert.AreEqual(1,result1);

            var result2 = jan9_2016.IsWave(new int[] { 4, 11, 12, 1, 6 });
            Assert.AreEqual(1,result2);

            var result3 = jan9_2016.IsWave(new int[] { 1, 0, 5 });
            Assert.AreEqual(1,result3);

            var result4 = jan9_2016.IsWave(new int[] { 2});
            Assert.AreEqual(1,result4);

            var result5 = jan9_2016.IsWave(new int[] { 2, 6, 3, 4 });
            Assert.AreEqual(0,result5);
        }

        [TestMethod]
        public void IsBean() {
            var jan9_2016 = new Jan9_2016();

            var result1 = jan9_2016.IsBean(new int[] { 1, 2, 3, 9, 6, 13 });
            Assert.AreEqual(1,result1);

            var result2 = jan9_2016.IsBean(new int[] { 3, 4, 6, 7, 13, 15 });
            Assert.AreEqual(1,result2);

            var result3 = jan9_2016.IsBean(new int[] { 1, 2, 3, 4, 10, 11, 12 });
            Assert.AreEqual(1,result3);

            var result4 = jan9_2016.IsBean(new int[] { 3, 6, 9, 5, 7, 13, 6, 17 });
            Assert.AreEqual(1,result4);

            var result5 = jan9_2016.IsBean(new int[] { 9, 6, 18 });
            Assert.AreEqual(0,result5);

            var result6 = jan9_2016.IsBean(new int[] { 4, 7, 16 });
            Assert.AreEqual(0,result6);

        }

    }
}
