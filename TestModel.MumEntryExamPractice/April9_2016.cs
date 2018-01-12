using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class April9_2016
    {

        public int CountDigit(int number, int digitToCount)
        {
            if (number < 0 || digitToCount < 0)
            {
                return -1;
            }

            int numerator = number;
            int denominator = 10;
            int digitCount = 0;
            int remainder = 0;

            while (numerator > 10)
            {
                remainder = numerator % denominator;
                if (remainder == digitToCount)
                {
                    digitCount++;
                }
                numerator = numerator / denominator;
            }

            //if the last digit remaining itself is the digitToCount
            if (numerator == digitToCount)
            {
                digitCount++;
            }

            return digitCount;
        }



        public int IsPrime(int number)
        {
            if (number < 1)
            {
                return 0;
            }  
            
            for (int i = 2; i * i <= number; i++)
            {
                if(number % i == 0) { return 0; }
            }

            return 1;
        }

        public int IsBunkerArray(int[] inputArray)
        {
            //omit the last element, as we need the next element to evaluate
            for (int i = 0; i < inputArray.Length-1; i++)
            {
                //if element is odd
                if (inputArray[i] % 2 == 1)
                {
                    if (IsPrime(inputArray[i + 1]) == 1)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public int IsMeeraArray(int[] inputArray) {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for(int j = 0; j < inputArray.Length; j ++)
                {
                    if (inputArray[i] == 2 * inputArray[j]) {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}
