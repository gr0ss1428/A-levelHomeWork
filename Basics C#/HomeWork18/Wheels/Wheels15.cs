﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork18.Wheels
{
    class Wheels15 : Wheels
    {
        public Wheels15()
        {
            size = 15;
        }
        public override void Rolls()
        {
            Console.WriteLine("I'm only on the pavement");
        }
    }
}
