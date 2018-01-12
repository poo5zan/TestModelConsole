using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Feb13_2016
    {
        public int FactorTwoCount(int number)
        {
            int numerator = number;
            int denominator = 2;
            int remainder = 0;
            int countFactor = 0;
            while (remainder == 0)
            {
                remainder = numerator % denominator;
                if (remainder == 0)
                {
                    numerator = numerator / denominator;
                    countFactor++;
                }
            }

            return countFactor;
        }

        public int IsMeera(int[] inputArray)
        {
            bool oddFound = false;
            int countOfEvenLeft = 0;
            int countOfEvenRight = 0;
            //check the presence of odd
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 == 1)
                {
                    oddFound = true;
                    countOfEvenLeft = i;
                    break;
                }
            }

            if (oddFound == false) { return 0; }

            //count number of even from right
            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                //loop until you get odd
                if (inputArray[i] % 2 == 0)
                {
                    countOfEvenRight++;
                }
                else
                {
                    //odd
                    break;
                }
            }

            if (countOfEvenLeft == countOfEvenRight)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int GoodSpread(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                int countOccurrence = 0;
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j])
                    {
                        countOccurrence++;
                    }
                    if (countOccurrence > 3)
                    {
                        //error
                        return 0;
                    }
                }
            }

            return 1;
        }

    }
}
