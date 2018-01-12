using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Jan9_2016
    {

        public int MinDistance(int number)
        {
            int minimum = number;
            int numerator = number;
            int previousFactor = 0;
            int currentFactor = 0;

            for (int i = 2; i < number; i++)
            {
                int remainder = numerator % i;
                if (remainder == 0)
                {
                    previousFactor = currentFactor;
                    currentFactor = i;
                    int result = currentFactor - previousFactor;
                    if (result < minimum)
                    {
                        minimum = result;
                    }
                }
            }

            //if no factor
            if (currentFactor == 0)
            {
                return -1;
            }

            //if only one factor
            if (previousFactor == 0)
            {
                return 0;
            }
                       

            return minimum;
        }

        public int IsWave(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                //if consecutive odd
                if (inputArray[i] % 2 == 1 && inputArray[i + 1] % 2 == 1)
                {
                    return 0;
                }
                //if consecutive even
                if (inputArray[i] % 2 == 0 && inputArray[i + 1] % 2 == 0)
                {
                    return 0;
                }
            }

            return 1;
        }


        public int IsBean(int[] inputArray) {
            bool foundNine = false;
            bool foundThirteen = false;
            bool foundSeven = false;
            bool foundSixteen = false;

            for (int i = 0; i < inputArray.Length; i++) {

                if (inputArray[i] == 9) { foundNine = true; }
                if (inputArray[i] == 13) { foundThirteen = true; }
                if (inputArray[i] == 7) { foundSeven = true; }
                if (inputArray[i] == 16) { foundSixteen = true; }

            }

            //fail condition
            //if contains 9 but no 13
            if (foundNine == true && foundThirteen == false)
            {
                return 0;
            }
            //if contains 7 and 16
            if (foundSeven == true && foundSixteen == true)
            {
                return 0;
            }

            return 1;

        }

    }
}
