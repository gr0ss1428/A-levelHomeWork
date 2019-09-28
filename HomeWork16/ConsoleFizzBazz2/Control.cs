using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleFizzBazz2
{
    class Control
    {
        private static Control _instanseControl = null;
        private static object objLocker = new object();
        private Stopwatch stopwatch = new Stopwatch();
        public StringBuilder sbFizzBuzz;

        public TimeSpan Time
        {
            get
            {
                return stopwatch.Elapsed;
            }
        }

        private Control()
        {
        }

        public static Control GetControl()
        {
            try
            {
                Monitor.Enter(objLocker);
                if (_instanseControl == null)
                {
                    _instanseControl = new Control();
                }
            }
            finally
            {
                Monitor.Exit(objLocker);
            }
            return _instanseControl;
        }

        public void StartFizzBuzz(int end, FizzBuzzAlg.FizzBuzz fizzBuzz)
        {
            sbFizzBuzz = new StringBuilder();
            stopwatch.Reset();
            sbFizzBuzz = fizzBuzz.FizzBuzzStart(end, stopwatch);
        }
    }
}
