using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleFizzBazz2.FizzBuzzAlg
{
    public class FizzBuzzThread : FizzBuzzAsync
    {
        private StringBuilder[] sbFizzBuzz;
        private static int countFinished;

        private class Tools
        {
            public int start;
            public int end;
            public int id;
        }

        public FizzBuzzThread(int threads) : base(threads)
        {
            sbFizzBuzz = new StringBuilder[threads];
        }

        public override StringBuilder FizzBuzzStart(int end, Stopwatch stopwatch)
        {
            int parts = CalculateParts(end);
            countFinished = 0;
            Thread[] threads = new Thread[CountThreads];
            int start = 0;
            stopwatch.Start();
            for (int i = 0; i < CountThreads - 1; i++)
            {
                threads[i] = CreatedThread();
                threads[i].Start(new Tools() { start = start, end = start + parts, id = i });
                start += parts;
            }
            threads[threads.Length - 1] = CreatedThread();
            threads[threads.Length - 1].Start(new Tools() { start = end - parts, end = end, id = threads.Length - 1 });

            while (countFinished != CountThreads)
            {
                //это некрасиво
            }
            stopwatch.Stop();

            StringBuilder sb = new StringBuilder();
            foreach (var s in sbFizzBuzz)
            {
                sb.Append(s.ToString());
            }

            return sb;
        }

        private void ThreadFizzBuzz(object param)
        {
            Tools toos = param as Tools;
            StringBuilder fizzBuzz = new StringBuilder();
            for (int i = toos.start; i < toos.end; i++)
            {
                fizzBuzz.Append(FizzBuzzCalculate(i));
            }
            sbFizzBuzz[toos.id] = fizzBuzz;
            countFinished++;
        }

        private Thread CreatedThread()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadFizzBuzz));
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Highest;

            return thread;
        }
    }
}
