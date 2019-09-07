using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Player
{
    public struct Skills
    {
        public enum SkillsPlayerEnum : int
        {
            REGULARPLAYER, NOTEPADPLAYER, UBERPLAYER, CHEATER, UBERCHEATER
        }
        public static List<string> SkillsPlayerStr = new List<string>() { "Обычный игрок", "Игрок-блокнот", "Убер-игрок", "Читер", "Убер-читер" };
    }
    
    public abstract class BasePlayer
    {
        public abstract string Skills { get;}
        public string Name { get; }
        public int Min { get; }
        public int Max { get; }
        //   public Color color { get; }
        public int Wins { get; set; }
        public BasePlayer(string name, int min, int max)
        {
            Name = name;
            Min = min;
            Max = max + 1;
            Wins = 0;
        }
        public abstract int NextStep();
        public abstract void NewRun(); 
    }
}
