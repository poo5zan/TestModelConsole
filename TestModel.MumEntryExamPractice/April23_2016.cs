﻿using System;
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


    }
}
