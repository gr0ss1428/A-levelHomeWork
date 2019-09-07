using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
   public class UberCheatPlayer:UberPlayer
    {
        readonly string skills = "Убер-читер";
        public override string Skills
        {
            get { return skills; }
        }
        IHistory IContainsHistory { get; }
        public UberCheatPlayer(IHistory contains,string name, int min, int max) : base(name, min, max)
        {
            IContainsHistory = contains;
        }
        public override int NextStep()
        {
            do
            {
                step++;
            } while (IContainsHistory.IsContains(step));
            return step;
        }
        public override void NewRun()
        {
            base.NewRun();
        }
    }
}
