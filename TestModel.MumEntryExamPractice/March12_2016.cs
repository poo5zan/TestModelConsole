using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class March12_2016
    {

        public int IsPascal(int number)
        {
            int sum = 0;
            for (int i = 0; sum < number; i++)
            {
                sum = sum + i;
                if (sum == number)
                {
                    return 1;
                }
            }
            return 0;
        }

        public int IsMeeraArray(int[] inputArray)
        {
            bool isOnePresent = false;
            bool isPrimePresent = false;

            for (int i = 0; i < inputArray.Length; i++)
            {               
                if (inputArray[i] == 1) { isOnePresent = true; }
                if (Helpers.IsPrime(inputArray[i]) == 1) { isPrimePresent = true; }

                if (isOnePresent == true && isPrimePresent == true)
                {
                    return 1;
                }
            }

            return 0;
        }

        public int IsSuff(int[] inputArray)
        {
            bool found = false;
           
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++) {
                    if (inputArray[j] == inputArray[i] - 1 || inputArray[j] == inputArray[i] + 1)
                    {
                        found = true;
                    }                  
                }

                if (found == false) { return 0; }

                //reset the found flag for new element
                found = false;               
            }
            return 1;
        }

    }
}
