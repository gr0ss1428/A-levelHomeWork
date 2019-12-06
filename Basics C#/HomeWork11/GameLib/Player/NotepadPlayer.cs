using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class NotepadPlayer : RegPlayer
    {
        readonly string skills = "Игрок-блокнот";
        public override string Skills
        {
            get { return skills; }
        }
        IHistory history;
        public NotepadPlayer(IHistory history,string name, int min, int max) : base(name, min, max)
        {
            this.history = history;
        }
        public override int NextStep()
        {
            int value;
            do
            {
                value =base.NextStep();
            } while (history.IsContains(this,value));
            return value;
        }
        public override void NewRun()
        {
            base.NewRun();//снова на удачу, но раньше была коллекция ходов тут
        }
    }
}
