using GameLib.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameLib
{
    public class Server : IServer
    {
        IHistory history;
        IDisplay display;
        List<BasePlayer> players;
        public delegate void DelegatNewRun();
        public event DelegatNewRun NewRun;
        int MaxTry { get; set; }
        int PumpkinWeight { get; set; }
        public Server(IDisplay disp)
        {
            history = new History();
            display = disp;
            players = new List<BasePlayer>();
            MaxTry = 100;
        }
        public void ClearPlayer()
        {
            history.Clear();
            players.Clear();
        }
        public void NewTry()
        {
            history.Clear();
            if (players.Count() > 0)
            {
                NewRun?.Invoke();
                BeginGame();
            }
        }
        void BeginGame()
        {
            bool victory = false;
            int value = 0;
            for (int i = 1; i <= MaxTry; i++)
            {
                display.DisplayInfo($"Шаг {i}");
                foreach (var pl in players)
                {
                    value = pl.NextStep();
                    history.AddValue(pl, value);
                    display.DisplayInfo($"{pl.Name} - {value}");
                    if (value == PumpkinWeight)
                    {
                        victory = true;
                        display.Victory($"{pl.Name} скилл \"{pl.Skills}\" на {i} шагу");
                        pl.Wins++;
                        break;
                    }
                }
                if (victory)
                {
                    break;
                }
                display.DisplayInfo($"\n");
            }
            if (!victory) WhoVictory();
            UpdateVictory();
        }
        /// <summary>
        /// Очень не красиво считаем, наверное
        /// В истории каждого игрока ищим минимальную разницу
        /// </summary>
        void WhoVictory()
        {
            int[,] min = new int[players.Count, 2];
            for (int i = 0; i < players.Count; i++)
            {
                List<int> values = history.GetHistoryByPlayer(players[i]);
                min[i, 0] = Math.Abs(PumpkinWeight - values[0]);
                min[i, 1] = values[0];
                for (int y = 1; y < values.Count; y++)
                {
                    int temp = Math.Abs(PumpkinWeight - values[y]);
                    if (min[i, 0] > temp)
                    {
                        min[i, 0] = temp;
                        min[i, 1] = values[y];
                    }
                }
            }

            int indexWin = 0;
            for (int i = 0; i < players.Count - 1; i++)//запоминаем индекс игрока в массиве с самой меньшей разницей
            {
                if (min[i, 0] < min[i + 1, 0]) indexWin = i;
                else indexWin = i + 1;
            }

            List<int> indexWinsPlayer = new List<int>();
            for (int i = 0; i < players.Count; i++)//заносим в список игроков с наименьшей разницей
            {
                if (min[indexWin, 0] == min[i, 0]) indexWinsPlayer.Add(i);
            }

            string message = "Победили\n";
            foreach (var index in indexWinsPlayer)//отмечаем победу
            {
                players[index].Wins++;
                message += $"Игрок {players[index].Name} с числом {min[index, 1]} \n";
            }
            display.MassVictory(message);
        }
        public void AddPlayer(string name, Skills.SkillsPlayerEnum skills)
        {
            switch (skills)
            {
                case Skills.SkillsPlayerEnum.REGULARPLAYER:
                    BasePlayer playerReg = new RegPlayer(name, 40, 140);
                    this.NewRun += playerReg.NewRun;
                    players.Add(playerReg);
                    break;
                case Skills.SkillsPlayerEnum.NOTEPADPLAYER:
                    BasePlayer playerNote = new NotepadPlayer(history, name, 40, 140);
                    this.NewRun += playerNote.NewRun;
                    players.Add(playerNote);
                    break;
                case Skills.SkillsPlayerEnum.UBERPLAYER:
                    BasePlayer playerUber = new UberPlayer(name, 40, 140);
                    this.NewRun += playerUber.NewRun;
                    players.Add(playerUber);
                    break;
                case Skills.SkillsPlayerEnum.CHEATER:
                    BasePlayer playerCheat = new CheaterPlayer(history, name, 40, 140);
                    this.NewRun += playerCheat.NewRun;
                    players.Add(playerCheat);
                    break;
                case Skills.SkillsPlayerEnum.UBERCHEATER:
                    BasePlayer playerUCheat = new UberCheatPlayer(history, name, 40, 140);
                    this.NewRun += playerUCheat.NewRun;
                    players.Add(playerUCheat);
                    break;
            }
        }
        public void NewPumpkinWeight(int pumpkinWeight)
        {
            this.PumpkinWeight = pumpkinWeight;
        }
        public void UpdateVictory()
        {
            display.UpdateVictoryHistory(players.ToArray());
        }
    }
}