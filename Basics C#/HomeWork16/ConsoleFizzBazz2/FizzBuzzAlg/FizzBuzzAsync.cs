using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleFizzBazz2.FizzBuzzAlg
{
    public class FizzBuzzAsync : FizzBuzz
    {
        protected int CountThreads { get; }

        public FizzBuzzAsync(int threads)
        {
            if (threads <= 0) threads = 1;
            CountThreads = threads;
        }

        public override StringBuilder FizzBuzzStart(int end, Stopwatch stopwatch)
        {
            int parts = CalculateParts(end);
            int start = 0;
            StringBuilder sbFizzBuzz = new StringBuilder();

            Task<StringBuilder>[] tasks = new Task<StringBuilder>[CountThreads];
            stopwatch.Start();
            for (int i = 0; i < tasks.Length - 1; i++)
            {
                tasks[i] = ThreadFizzBuzz(start, start + parts);
                start += parts;
            }
            tasks[tasks.Length - 1] = ThreadFizzBuzz(end - parts, end);

            Task.WaitAll(tasks);
            stopwatch.Stop();
            foreach (var task in tasks)
            {
                sbFizzBuzz.Append(task.Result.ToString());
            }

            return sbFizzBuzz;
        }

        private async Task<StringBuilder> ThreadFizzBuzz(int start, int end)
        {
            var str = await Task.Run(() =>
              {
                  StringBuilder sbFizzBuzz = new StringBuilder();
                  for (int i = start; i < end; i++)
                  {
                      sbFizzBuzz.Append(FizzBuzzCalculate(i));
                  }
                  return sbFizzBuzz;
              });

            return str;
        }

        protected int CalculateParts(int end)
        {
            if (end % CountThreads == 0)
            {
                return end / CountThreads;
            }
            else
            {
                int tempEnd = end;
                do
                {
                    tempEnd--;
                } while (tempEnd % CountThreads != 0);

                return tempEnd / CountThreads;
            }
        }
    }
}
