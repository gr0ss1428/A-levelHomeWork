using GameLib.Player;
using System.Collections.Generic;

namespace GameLib
{
    public interface IDisplay
    {
        void DisplayInfo(string message);
        void Victory(string namePlayer);
        void MassVictory(string message);
        void UpdateVictoryHistory(BasePlayer[] players);
    }
    public interface IServer
    {
        void ClearPlayer();
        void NewTry();
        void AddPlayer(string name,Skills.SkillsPlayerEnum skills);
        void NewPumpkinWeight(int pumpkinWeight);
        void UpdateVictory();
    }
}