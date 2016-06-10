using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Dec19_2015
    {
        public int IsMeera(int number) {
            int remainder = 0;
            int count = 0;

            for (int i = 2; i < number; i++)
            {
                remainder = number % i;
                if (remainder == 0)
                {
                    count++;
                }
            }

            if (number % count == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int IsBunker(int[] inputArray)
        {
            bool foundOne = false;
            bool foundPrime = false;
            for (int i = 0; i < inputArray.Length; i++)
            {
                //skipping checking prime, if already found
                if (foundPrime == false)
                {
                    if (Helpers.IsPrime(inputArray[i]) == 1)
                    {
                        foundPrime = true;
                    }
                }
                //check one
                if (foundOne == false)
                {
                    if (inputArray[i] == 1) { foundOne = true; }
                }
            }

            if (foundOne == true && foundPrime == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int IsNice(int[] inputArray) {
            for (int i = 0; i < inputArray.Length; i++)
            {
                bool foundElement = false;
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j] - 1
                      || inputArray[i] == inputArray[j] + 1)
                    {
                        foundElement = true;
                        break;
                    }
                }

                if (foundElement == false) {
                    return 0;
                }
            }
            return 1;
        }
    }
}
