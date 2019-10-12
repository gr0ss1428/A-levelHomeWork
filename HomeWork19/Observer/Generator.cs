using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Observer
{
    interface IObservable
    {
        event Action<int> NewValue;
    }
    class Generator : IObservable
    {
        public event Action<int> NewValue;
        private Random random;
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        public bool IsGenerate { get; private set; }

        public Generator()
        {
            random = new Random();
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }

        public void StartGeniration()
        {
            if (!IsGenerate)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            IsGenerate = false;
                            return;
                        }
                        NewValue?.Invoke(random.Next(0, 500));
                        Thread.Sleep(10);

                    }
                });
                IsGenerate = true;
            }
        }

        public void StopGeneration()
        {
            if (IsGenerate)
            {
                cancelTokenSource.Cancel();
            }
        }
    }
}
