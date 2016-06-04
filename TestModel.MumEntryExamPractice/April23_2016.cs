using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class April23_2016
    {
        public int[] Fill(int[] inputArray, int countOfElements, int lengthOfResponseArray)
        {
            if (countOfElements < 1) {
                return null;
            }

            int elementCount = 0;
            int[] arrayToReturn = new int[lengthOfResponseArray];
            
            for (int i = 0; i < lengthOfResponseArray; i++)
            {
                arrayToReturn[i] = inputArray[elementCount];
                elementCount++;
                //reset elementCount
                if (elementCount == countOfElements)
                {
                    elementCount = 0;
                }
            }
            
            return arrayToReturn;
        }

        public bool SumIsPower(int[] inputArray) {
            int denominator = 2;
            int numerator = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                numerator += inputArray[i];
            }

            while (numerator > 2) {
                numerator = numerator / denominator;
            }
            if (numerator == denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHollow(int[] inputArray) {
            int countZero = 0;
            int firstZeroIndex = 0;
            int LastZeroIndex = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == 0)
                {
                    if (firstZeroIndex == 0)
                    {
                        firstZeroIndex = i;
                    }
                    countZero++;
                    //there is element in between zero
                    if (LastZeroIndex != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (firstZeroIndex != 0)
                    {
                        LastZeroIndex = i;
                    }
                }

            }

            if (countZero < 3) { return false; }

            int _CountLeft = 0;
            int _CountRight = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == 0)
                {
                    break;
                }
                else
                {
                    _CountLeft++;
                }
            }

            for (int j = inputArray.Length-1; j >= 0; j--)
            {
                if (inputArray[j] == 0)
                {
                    break;
                }
                else
                {
                    _CountRight++;
                }
            }

            if (_CountLeft != _CountRight) { return false; }
            //count non zero
            //for (int i = 0, j = inputArray.Length-1; i < inputArray.Length; i++,j--)
            //{
            //    if (inputArray[i] == 0 || inputArray[j] == 0)
            //    {
            //        return false;
            //    }   
            //}

            return true;
        }

    }
}
