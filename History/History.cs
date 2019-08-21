using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History
{
    public static class HistoryArr
    {
        static string[] names;
        static int[] scores;
        static int position;
        public static int LengthHistory
        {
            get { return position; }
        }
        static HistoryArr()
        {
            names = new string[10];
            scores = new int[10];
            for (int i = 0; i < scores.Length; i++)
            {
                names[i] = "Сикорский И.И.";
                scores[i] = 10+i;
            }
            position = 9;
            Sort();
        }
        static void Sort()
        {
            for (int i = 0; i < scores.Length - 1; i++)
                for (int y = i + 1; y < scores.Length; y++)
                {
                    if (scores[i] < scores[y])
                    {
                        int temp = scores[i];
                        string strtemp = names[i];
                        scores[i] = scores[y];
                        names[i] = names[y];
                        scores[y] = temp;
                        names[y] = strtemp;
                    }
                }
        }
        static public void AddResult(int score, string name)
        {
            Sort();
            if(position < scores.Length - 1)
            {
                names[position] = name;
                scores[position] = score;
            }
            else if(position==scores.Length-1)
            {
                int i = 0;
                int iTemp = 0;
                string sTemp = String.Empty;
                for (; i < scores.Length; i++)
                {
                    if(score>scores[i])
                    {
                        iTemp = scores[i];
                        sTemp = names[i];
                        names[i] = name;
                        scores[i] = score;
                        break;
                    }
                }
                i++;
                for(;i<scores.Length;i++)
                {
                    int temp = scores[i];
                    string str = names[i];
                    scores[i] = iTemp;
                    names[i] = sTemp;
                    iTemp = temp;
                    sTemp = str;
                }
            }
        }
        static public string GetHistoryByPosStr(int pos)
        {
            if (pos >= 0 && pos <= position)
                return $"{names[pos]}  {scores[pos]}";
            else return null;
        }

    }
}
