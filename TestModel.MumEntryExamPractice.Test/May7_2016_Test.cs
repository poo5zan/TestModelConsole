using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class May7_2016_Test
    {
        [TestMethod]
        public void FactorTwoCount()
        {
            var may7_2016 = new May7_2016();
            var result_48_4 = may7_2016.FactorTwoCount(48);
            Assert.AreEqual(result_48_4, 4);
            var result_27_0 = may7_2016.FactorTwoCount(27);
            Assert.AreEqual(result_27_0, 0);
        }

        [TestMethod]
        public void MeeraArray()
        {
            var may7_2016 = new May7_2016();
            //valid
            var result1 = may7_2016.MeeraArray(new int[] { 4, 8, 6, 3, 2, 9, 8, 11, 8, 13, 12, 12, 6 });
            Assert.AreEqual(1, result1);

            //invalid
            var result2 = may7_2016.MeeraArray(new int[] { 2, 4, 6, 8, 6 });
            Assert.AreEqual(0, result2);

            //invalid
            var result3 = may7_2016.MeeraArray(new int[] { 2, 8, 7, 10, -4, 6 });
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void GoodSpread() {
            var may7_2016 = new May7_2016();

            var result1 = may7_2016.GoodSpread(new int[] { 2, 1, 2, 5, 2, 1, 5, 9 });
            Assert.AreEqual(1, result1);

            var result2 = may7_2016.GoodSpread(new int[] { 3, 1, 3, 1, 3, 5, 5, 3 });
            Assert.AreEqual(0, result2);
                        
        }
    }
}
