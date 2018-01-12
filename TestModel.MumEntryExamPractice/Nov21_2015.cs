using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Nov21_2015
    {
        //same as april23 2016

        public int[] Fill(int[] arr, int k, int n)
        {
            if (k < 1 || n < 1) { return null; }

            int[] arr2 = new int[n];

            int elementCount = 0;

            for (int i = 0; i < n; i++)
            {
                arr2[i] = arr[elementCount];
                elementCount++;

                if (elementCount == k) { elementCount = 0; }          
            }

            return arr2;
        }

        public bool SumIsPower(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                sum += inputArray[i];
            }

            if (sum == 1) { return true; }

            int numerator = sum;
            while (numerator >= 2) {
                int remainder = numerator % 2;
                if (remainder != 0) { return false; }
                numerator = numerator / 2;
            }

            return true;
        }

        public int IsHollow(int[] inputArray) {
            bool foundFirstZero = false;
            int firstZeroIndex = 0;
            bool foundLastZero = false;
            int lastZeroIndex = 0;
            int countZero = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == 0)
                {
                    if (foundFirstZero == false)
                    {
                        foundFirstZero = true;
                        firstZeroIndex = i;                        
                    }
                    if (foundFirstZero == true && foundLastZero == false)
                    {
                        countZero++;
                    }
                    if (foundLastZero == true)
                    {
                        //got zero again after a non zero element
                        return 0;
                    }
                }
                else
                {
                    if (foundFirstZero == true && foundLastZero == false)
                    {
                        foundLastZero = true;
                        lastZeroIndex = i;
                    }
                }
            }

            if (countZero < 3) { return 0; }

            //
            if (firstZeroIndex == (inputArray.Length - lastZeroIndex))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }
}
