using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
   public  class Feb27_2016
    {

        public int IsEvenSpaced(int[] inputArray)
        {
            if (inputArray.Length < 2) { return 0; }

            int maximumValue = inputArray[0];
            int minimumValue = inputArray[0];

            for (int i = 0; i < inputArray.Length; i++)
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

            if ((maximumValue - minimumValue) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int IsSub(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i == inputArray.Length - 1) { continue; }
                int sum = 0;
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    sum += inputArray[j];
                }

                if (inputArray[i] <= sum) { return 0; }
            }

            return 1;
        }

        public int IsSym(int[] inputArray)
        {
            for (int i = 0, j = inputArray.Length - 1; i < inputArray.Length / 2; i++, j--)
            {
                //both odd
                if (inputArray[i] % 2 == 1 && inputArray[j] % 2 == 1)
                { continue; }
                //both even
                if (inputArray[i] % 2 == 0 && inputArray[j] % 2 == 0)
                { continue; }
                //reached here means failed
                return 0;
            }

            return 1;
        }

    }
}
