using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Observer
{
    class Collector
    {
        private int maxCollect;
        public int MaxCollect
        {
            get
            { 
                return maxCollect; 
            }
            private set
            {
                if (!IsSubscribe) maxCollect = value;
            }
        }
        List<int> collect;
        IObservable observable;
        object tempObj = new object();
        string Name { get;}
        public bool IsSubscribe { get; private set; }

        public Collector(int max, string name, IObservable obs)
        {
            collect = new List<int>();
            observable = obs;
            IsSubscribe = false;
            maxCollect = max;
            Name = name;
        }

        public void Subscribe()
        {
            try
            {
                Monitor.Enter(tempObj);
                if (!IsSubscribe)
                {
                    collect.Clear();
                    observable.NewValue += ValueCollector;
                    IsSubscribe = true;
                }
            }
            finally
            {
                Monitor.Exit(tempObj);
            }
        }

        public void Unsubscribe()
        {
            try
            {
                Monitor.Enter(tempObj);
                if (IsSubscribe)
                {
                    Console.WriteLine($"{Name} Unsubscribe");
                    observable.NewValue -= ValueCollector;
                    IsSubscribe = false;
                }
            }
            finally
            {
                Monitor.Exit(tempObj);
            }
        }

        private void ValueCollector(int value)
        {
            collect.Add(value);
            if (collect.Count == maxCollect)
            {
                Unsubscribe();
                Calculate();
            }

        }

        private void Calculate()
        {
            int value = 0;
            foreach (var val in collect)
            {
                value += val;
                Console.Write($"{val} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Average value: {value / MaxCollect}");
        }
    }
}
