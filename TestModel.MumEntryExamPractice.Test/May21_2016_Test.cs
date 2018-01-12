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

            var may21_2016 = new March26_2016(); //new May21_2016();

           // var result_162_3 = new May21_2016().GetExponent(162, 3);

            var result_27_3_3 = may21_2016.GetExponent(27, 3);
            Assert.AreEqual(result_27_3_3, 3);
            var result_28_3_0 = may21_2016.GetExponent(28, 3);
            Assert.AreEqual(result_28_3_0, 0);
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
        public void Is121Array_should_validate_121_array() {

            var _may21_2016 = new March26_2016(); //new May21_2016();

            //Valid:1
            //Invalid:0

            //Valid, because the same number of 1s are 
            //at the beginning and end of the array
            // and there is atleast one 2 in between them
            var r1 = _may21_2016.Is121Array(new int[]{ 1,2,1});
            Assert.AreEqual(r1, 1);

            //Valid, because the same number of 1s are at the beginning
            //and end of the array and there is at least one 2 in between them
            var r2 = _may21_2016.Is121Array(new int[] { 1, 1, 2, 2, 2, 1, 1 });
            Assert.AreEqual(r2, 1);

            //Invalid, because the number of 1s at the end does not
            //equal the number of 1s at the beginning
            var r3 = _may21_2016.Is121Array(new int[] { 1, 1, 2, 2, 2, 1, 1, 1 });
            Assert.AreEqual(r3, 0);

            //Invalid, because the middle does not contain only 2s
            var r4 = _may21_2016.Is121Array(new int[] { 1, 1, 2, 1, 2, 1, 1 });
            Assert.AreEqual(r4, 0);

            //Invalid, because the array contains a number other than 1 and 2
            var r5 = _may21_2016.Is121Array(new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 1, 3 });
            Assert.AreEqual(r5, 0);

            //Invalid, because the array doesn't contain any 2s
            var r6 = _may21_2016.Is121Array(new int[] { 1, 1, 1, 1, 1, 1 });
            Assert.AreEqual(r6, 0);

            //Invalid, because the first element of the array is not a 1
            var r7 = _may21_2016.Is121Array(new int[] { 2, 2, 2, 1, 1, 1, 2, 2, 2, 1, 1 });
            Assert.AreEqual(r7, 0);

            //Invalid, because the last element of the array is not a 1
            var r8 = _may21_2016.Is121Array(new int[] { 1, 1, 1, 2, 2, 2, 1, 1, 2, 2 });
            Assert.AreEqual(r8, 0);

            //Invalid, because there are no 1s in the array
            var r9 = _may21_2016.Is121Array(new int[] { 2, 2, 2 });
            Assert.AreEqual(r9, 0);
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
            Assert.AreEqual(result2, 0);

        }

    }
}
