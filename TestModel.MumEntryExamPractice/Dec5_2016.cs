using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Dec5_2016
    {
        public int IsEvenSubset(int m, int n)
        {
            //get factors of m
            for (int i = 2; i < m; i++)
            {
                int remainder = m % i;
                //if factor
                if (remainder == 0)
                {
                    //if even
                    if (i % 2 == 0)
                    {
                        //check if it's factor of n too
                        if (n % i != 0)
                        {
                            //not factor of n
                            return 0;
                        }
                    }
                }
            }

            return 1;
        }

        public int IsTwinoid(int[] inputArray)
        {
            int countEven = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 == 0)
                {
                    //even
                    countEven++;
                }
                else
                {
                    //odd
                    if (countEven > 2) {
                        //more than 2 consecutive even
                        return 0;
                    }
                    if (countEven == 2) {
                        return 1;
                    }
                    countEven = 0;
                }
            }

            return 0;
        }

        
        public int IsBalanced(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                bool foundNegative = false;
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == -inputArray[j])
                    {
                        foundNegative = true;
                        //exit the current inner for loop
                        break;
                    }
                }
                
                if (foundNegative == false)
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
