using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class CheaterPlayer:RegPlayer
    {
        readonly string skills = "Читер";
        public override string Skills
        {
            get { return skills; }
        }
        IHistory IContainsHistory { get; }
        public CheaterPlayer(IHistory contains,string name, int min, int max) : base(name, min, max)
        {
            IContainsHistory = contains;
        }
        public override int NextStep()
        {
            int value;
            do
            {
                value = base.NextStep();
            } while (IContainsHistory.IsContains(value));
            return value;
        }
        public override void NewRun()
        {
            base.NewRun();
        }
    }
}
