using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFizzBazz2.FizzBuzzAlg
{
   public class FizzBuzzParallel: FizzBuzz
    {
        public override StringBuilder FizzBuzzStart(int end, Stopwatch stopwatch)
        {
            StringBuilder sbFizzBuzz = new StringBuilder();
            stopwatch.Start();
            Parallel.For(0, end, (i) => sbFizzBuzz.Append(FizzBuzzCalculate(i)));
            stopwatch.Stop();
            
            return sbFizzBuzz;
        }

    }
}
