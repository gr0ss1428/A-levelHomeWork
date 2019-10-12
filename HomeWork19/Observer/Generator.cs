using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Generator
    {
        public event Action<int> NewValue;
        private Random random;

        public Generator()
        {
            random = new Random();
        }
    }
}
