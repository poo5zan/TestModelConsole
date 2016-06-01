using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.MumEntryExamPractice.Test
{   
    [TestClass]
    public class May21_2016_Test
    {
        [TestMethod]
        public void GetExponent_should_return_its_largest_exponent() {

            var may21_2016 = new May21_2016();

           // var result_162_3 = new May21_2016().GetExponent(162, 3);

            //var result_27_3 = may21_2016.GetExponent(27, 3);
            //Assert.AreEqual(result_27_3, 3);
            //var result_28_3 = may21_2016.GetExponent(28, 3);
            //Assert.AreEqual(result_28_3, 0);
            var result_280_7_1 = may21_2016.GetExponent(280, 7);
            Assert.AreEqual(result_280_7_1, 1);
            var result_n250_5_3 = may21_2016.GetExponent(-250, 5);
            Assert.AreEqual(result_n250_5_3, 3);
            var result_18_1_n1 = may21_2016.GetExponent(18, 1);
            Assert.AreEqual(result_18_1_n1, -1);
            var result_128_4_3 = may21_2016.GetExponent(128, 4);
            Assert.AreEqual(result_128_4_3, 3);


        }
    }
}
