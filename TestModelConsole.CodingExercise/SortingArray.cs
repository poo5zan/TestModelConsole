using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole.CodingExercise
{
    public class SortingArray
    {
        public int[] Sort(int[] inputArray)
        {
            //sort array
            for (int i = 0; i < inputArray.Length; i++) {

                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] < inputArray[j])
                    {
                        //swap
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }

            return inputArray;
        }

        public int FindMaximumCountInArray(int[] inputArray)
        {
            inputArray = Sort(inputArray);
            int maxCount = 0;
            int max = 0;
            int distinctValue = inputArray[0];

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == distinctValue)
                {
                    maxCount++;
                }
                else
                {
                    maxCount = 0;
                    distinctValue = inputArray[i];
                }
                if (maxCount > max)
                {
                    max = maxCount;
                }
            }

            return max;
        }
    }
}
