using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public class RegPlayer:BasePlayer
    {
        readonly string skills = "Обычный игрок";
        public override string Skills
        {
            get { return skills; }
        }
        protected Random rand;
        public RegPlayer(string name,int min,int max):base(name,min,max)
        {
            rand = new Random((int)(DateTime.Now.Ticks%1000));
        }
        public override int NextStep()
        {
            return rand.Next(MinWeight, MaxWeight);
        }
        public override void NewRun()
        {
            rand = new Random((int)(DateTime.Now.Ticks % rand.Next(1,1001)));//на удачу
        }
    }
}
