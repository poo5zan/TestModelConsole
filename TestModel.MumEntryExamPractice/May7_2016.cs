using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{    
    public class May7_2016
    {
        public int FactorTwoCount(int number)
        {
            int remainder = 0;
            int countNumber = 0;
            while (remainder == 0)
            {
                remainder = number % 2;
                if (remainder == 0)
                {
                    number = number / 2;
                    countNumber++;
                    
                }
            }
            return countNumber;
        }

        public int MeeraArray(int[] inputArray)
        {
            int valid = 1;
            int invalid = 0;
            int oddNumber = 0;
            //check if inputArray contains odd number
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 == 1)
                {
                    oddNumber = inputArray[i];
                    break;
                }
            }

            //if no odd number found, return invalid
            if (oddNumber == 0) {
                return invalid;
            }

            //count if number of consecutive even numbers matches odd number
            for (int i = 0, j = inputArray.Length - 1; i < oddNumber; i++)
            {
                //check if the number is odd
                if ((inputArray[i] % 2 == 1) || (inputArray[j] % 2 == 1))
                {
                    return invalid;
                }
            }

            return valid;
        }

        public int GoodSpread(int[] inputArray) {
            int Valid = 1;
            int InValid = 0;
            int CountOfOccurrenceOfElement = 0;

            //limited elements to check
            if (inputArray.Length < 4) {
                return Valid;
            }
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j])
                    {
                        CountOfOccurrenceOfElement++;
                    }
                    if (CountOfOccurrenceOfElement > 3)
                    {
                        return InValid;
                    }
                }

                CountOfOccurrenceOfElement = 0;

            }

            return Valid;
        }
    }
}
