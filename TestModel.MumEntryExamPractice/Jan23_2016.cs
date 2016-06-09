using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Jan23_2016
    {
        public int IsFancy(int number)
        {
            int firstLeft = 1;
            int secondLeft = 1;
            int result = 0;

            if (number == 1) { return 1; }

            while (result < number)
            {
                result = 3 * firstLeft + 2 * secondLeft;
                if (result < number)
                {
                    secondLeft = firstLeft;
                    firstLeft = result;
                }
                if (result == number)
                {
                    return 1;
                }
            }

            return 0;
        }

        public int IsMeera(int[] inputArray)
        {
            bool foundOne = false;
            bool foundNine = false;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == 1) { foundOne = true; }
                if (inputArray[i] == 9) { foundNine = true; }
            }

            //if both found
            if (foundOne == true && foundNine == true) { return 1; }
            //if none found
            if (foundOne == false && foundNine == false) { return 1; }
            //other
            return 0;
        }

        public int IsBean(int[] inputArray)
        {
            if (inputArray.Length == 1)
            {
                if (inputArray[0] == 0) { return 1; }
            }

            for (int i = 0; i < inputArray.Length; i++)
            {
                bool foundElement = false;

                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j]) { continue; }

                    if (inputArray[i] == 2 * inputArray[j]
                     || inputArray[i] == 2 * inputArray[j] + 1
                     || inputArray[i] == inputArray[j] / 2)
                    {
                        foundElement = true;
                        break;
                    }                   
                }

                if (foundElement == false)
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
