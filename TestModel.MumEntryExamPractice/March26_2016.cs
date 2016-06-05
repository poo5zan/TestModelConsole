using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    // same as May21, just writing again for re-practice
   public  class March26_2016
    {
        public int GetExponent(int n, int p)
        {
            if (p <= 1) { return -1; }

            int numerator = n;
            int denominator = p;
            int exponent = 1;
            int remainder = 0;

            while (remainder == 0)
            {
                remainder = numerator % denominator;
                if (remainder == 0)
                {
                    exponent++;
                    denominator = denominator * p;
                }
            }

            return exponent - 1;
        }

        public int Is121Array(int[] inputArray)
        {
            //this covers, first element 1 and not 1 in array
            if (inputArray[0] != 1) {
                return 0;
            }

            bool first2Found = false;
            bool last2Found = false;

            //check basic validity
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == 2)
                {
                    if (first2Found == false) { first2Found = true; }
                    if (last2Found == true)
                    {
                        //found 2 after one
                        return 0;
                    }
                }
                else if (inputArray[i] == 1)
                {
                    if (first2Found == true) {

                        last2Found = true;

                    }
                }
                else {
                    //invalid character
                    return 0;
                }
            }

            //check if two exists,
            if (first2Found == false) { return 0; }

            //check the occurrence, palindrome check
            for (int i = 0, j = inputArray.Length - 1; i < inputArray.Length / 2; i++, j--)
            {
                if(inputArray[i] != inputArray[j])
                {
                    //fails,
                    return 0;
                }
            }

            return 1;


        }


    }
}
