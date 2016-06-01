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

        [TestMethod]
        public void IsMaxMinEqual_should_validate_array() {
            var may21_2016 = new May21_2016();
            
            //Valid 1
            //Invalid 0

            //Invalid, because array must have at least 
            //two different elements
            var result_empty_Array = may21_2016.IsMaxMinEqual(new int[] { });
            Assert.AreEqual(result_empty_Array, 0);
            
            //Invalid, because array must have atleast
            //two different elements
            var result_one_array = may21_2016.IsMaxMinEqual(new int[] { 2 });
            Assert.AreEqual(result_one_array, 0);

            //Invalid, because array must have at least two different elements
            var result_same_element = may21_2016.IsMaxMinEqual(new int[] { 1, 1, 1, 1, 1, 1 });
            Assert.AreEqual(result_same_element, 0);

            //Valid, because both max value(11) and 
            //min value 2 appear exactly one time
            var result_with_min_max_ocurring_once = may21_2016.IsMaxMinEqual(new int[] { 2, 4, 6, 8, 11 });
            Assert.AreEqual(result_with_min_max_ocurring_once, 1);

            //valid, because both max and min appears exactly one time
            var result_with_min_max_negative = may21_2016.IsMaxMinEqual(new int[] { -2, -4, -6, -8, -11 });
            Assert.AreEqual(result_with_min_max_negative, 1);

            //valid
            var result = may21_2016.IsMaxMinEqual(new int[] { 11, 4, 9, 11, 8, 5, 4, 10 });
            Assert.AreEqual(result, 1);

            //invalid
            var result2 = may21_2016.IsMaxMinEqual(new int[] { 11, 4, 9, 11, 8, 5, 4, 10,11 });
            Assert.AreEqual(result, 0);

        }

    }
}
