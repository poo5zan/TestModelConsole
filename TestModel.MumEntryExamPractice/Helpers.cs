using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice
{
    public class Helpers
    {
        public static int IsPrime(int number)
        {
            if (number <= 1)
            {
                return 0;
            }

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) { return 0; }
            }

            return 1;
        }
    }
}
