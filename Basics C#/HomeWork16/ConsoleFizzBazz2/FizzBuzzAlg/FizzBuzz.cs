using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleFizzBazz2.FizzBuzzAlg
{
    public class FizzBuzz
    {
        public virtual StringBuilder FizzBuzzStart(int end, Stopwatch stopwatch)
        {
            StringBuilder sbFizzBuzz = new StringBuilder();
            stopwatch.Start();
            for (int i = 0; i < end; i++)
            {
                sbFizzBuzz.Append(FizzBuzzCalculate(i));
            }

            stopwatch.Stop();
            return sbFizzBuzz;
        }

        protected string FizzBuzzCalculate(int value)
        {
            string strFizzBuzz = string.Empty;
            if (value % 3 == 0) strFizzBuzz += "Fizz";
            if (value % 5 == 0) strFizzBuzz += "Buzz";
            if (value % 3 != 0 && value % 5 != 0) strFizzBuzz += value.ToString();
            strFizzBuzz += " ";

            return strFizzBuzz;
        }
    }
}
