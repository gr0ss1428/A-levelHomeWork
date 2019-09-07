using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Player;
namespace GameLib
{
    public interface IHistory
    {
        bool IsContains(int value);
        bool IsContains(BasePlayer player, int value);
        void AddValue(BasePlayer player, int value);
        List<int> GetHistoryByPlayer(BasePlayer player);
        void Clear();
    }
    public class History : IHistory
    {
        Dictionary<BasePlayer, List<int>> history;
        List<int> realValue;
        public History()
        {
            history = new Dictionary<BasePlayer, List<int>>();
            realValue = new List<int>();
        }
        public bool IsContains(int value)
        {
            bool contains = false;
            foreach (var val in realValue)
            {
                if (value == val)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        public bool IsContains(BasePlayer player, int value)
        {
            bool contains = false;
            if (history.ContainsKey(player))
            {
                foreach (var val in history[player])
                {
                    if (value == val)
                    {
                        contains = true;
                        break;
                    }
                }
            }
            return contains;
        }
        public void AddValue(BasePlayer player, int value)
        {
            if (!history.ContainsKey(player)) history.Add(player, new List<int>() { value });
            else
            {
                history[player].Add(value);
            }
            if (!realValue.Contains(value)) realValue.Add(value);
        }
        public void Clear()
        {
            history.Clear();
            realValue.Clear();
        }
       public List<int> GetHistoryByPlayer(BasePlayer player)
        {
            return history[player];
        }
    }
}
