using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork18.Wheels
{
    abstract class Wheels
    {
        protected int size;
        public int GetSize { get => size; }

        public abstract void Rolls();
    }
}
