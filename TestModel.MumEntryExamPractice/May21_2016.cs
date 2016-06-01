using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class May21_2016
    {
        public int GetExponent(int n, int p)
        {
            if (p <= 1)
            {
                return -1;
            }

            int exponent = 1;
            //Double result = 0;

            //int d = n % p;
            int remainder = 0;

            while (remainder == 0)
            {
                remainder = n % p;
                if (remainder == 0)
                {
                    exponent++;
                    p = Convert.ToInt32(Math.Pow(p, exponent));
                }
            }
            return exponent;

        }

        public int IsMaxMinEqual(int[] inputArray)
        {
            int _valid = 1;
            int _invalid = 0;     
            
            if (inputArray.Length < 2) {                
                return 0;
            }
            int minimumValue = inputArray[0];
            int minimumValueCount = 0;
            int maximumValue = inputArray[0];
            int maximumValueCount = 0;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] < minimumValue)
                {
                    minimumValue = inputArray[i];
                }
                if (inputArray[i] > maximumValue)
                {
                    maximumValue = inputArray[i];
                }
            }

            //if all the elements of the array is same
            if (minimumValue == maximumValue) { return 0; }

            //count minimum and maximum value
            foreach (var element in inputArray)
            {
                if (element == minimumValue)
                {
                    minimumValueCount++;
                }
                if (element == maximumValue)
                {
                    maximumValueCount++;
                }
            }

            //different # of min and max
            if (minimumValueCount != maximumValueCount) { return 0; }

            return _valid;
        }


    }
}
