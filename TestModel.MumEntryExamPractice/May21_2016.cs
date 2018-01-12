using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class May21_2016
    {
        /// <summary>
        /// 1.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public int GetExponent(int n, int p)
        {
            //refer march21 for updated answer
            if (p <= 1) { return -1; }

            int exponent = 1;
            int denominator = p;
            int numerator = n;
            int remainder = 0;
            
            while (remainder == 0)
            {
                remainder = numerator % denominator;
                if (remainder != 0)
                {
                    exponent--;
                    break;
                }
                else
                {
                    exponent++;
                    denominator = (Int32)Math.Pow(p, exponent);
                }
            }

            return exponent;            

        }

        /// <summary>
        /// 2.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Is121Array(int[] a)
        {
            int result = 1;
            bool is2Present = false;
            //first element is not 1, invalid
            if (a[0] != 1)
            {
                result = 0;
                return result;
            }

            for (int i = 0, j = a.Length - 1; i < a.Length / 2; i++, j--)
            {
                //invalid character
                if ((a[i] != 1 && a[i] != 2) || ( a[j] != 1 && a[j] != 2))
                {
                    result = 0;
                    return result;
                }

                //not matched
                if (a[i] != a[j])
                {
                    result = 0;
                    return result;
                }

                //check if it has one 2
                if (a[i] == 2 || a[j] == 2)
                {
                    is2Present = true;
                }               
            }
                      

            //check if the middle element is 2 or not
            //is the length of array is odd
            if (a.Length % 2 == 1)
            {
                int index = a.Length / 2;
                if (a[index] != 2)
                {
                    result = 0;
                    return result;
                }
                else
                {
                    is2Present = true;
                }
            }

            if (!is2Present)
            {
                result = 0;
                return result;
            }

            return result;
        }

        public int IsMaxMinEqual(int[] inputArray)
        {
            int _valid = 1;
            int _invalid = 0;     
            
            if (inputArray.Length < 2) {                
                return 0;
            }
            int minimumValue = inputArray[0];
            int minimumValueCount = 0;
            int maximumValue = inputArray[0];
            int maximumValueCount = 0;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] < minimumValue)
                {
                    minimumValue = inputArray[i];
                }
                if (inputArray[i] > maximumValue)
                {
                    maximumValue = inputArray[i];
                }
            }

            //if all the elements of the array is same
            if (minimumValue == maximumValue) { return 0; }

            //count minimum and maximum value
            foreach (var element in inputArray)
            {
                if (element == minimumValue)
                {
                    minimumValueCount++;
                }
                if (element == maximumValue)
                {
                    maximumValueCount++;
                }
            }

            //different # of min and max
            if (minimumValueCount != maximumValueCount) { return 0; }

            return _valid;
        }


    }
}
