using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class UberPlayer:BasePlayer
    {
        readonly string skills = "Убер-игрок";
        public override string Skills
        {
            get { return skills; }
        }
        protected int step;
        public UberPlayer(string name, int min, int max) : base(name, min, max)
        {
            step = min-1;
        }
        public override int NextStep()
        {
            return ++step;
        }
        public override void NewRun()
        {
            step = Min - 1;
        }
    }
}
