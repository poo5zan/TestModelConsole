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
    }
}
