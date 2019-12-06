using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skier_lib
{
    public class SkierModel
    {
        [Required(ErrorMessage = "Введите число")]
        public uint? id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string name { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public uint? distFirstDay { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public uint? persentBoost { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public uint? calcDist { get; set; }
        public uint calcDay { get; set; }
        
    }
    public class SkierTools
    {
        public static uint GetDayRunDistanse(uint? distFirstDay, uint? persentBoost, uint? calcDist)
        {
            uint day = 0;
            uint allDist = 0;
            do
            {
                allDist += (uint)(distFirstDay * Math.Pow((1 + ((double)persentBoost / 100)), (double)day));
                day++;
            } while (!(allDist >= calcDist));
            day = (day - 1) * 2 + 1;
            return day;
        }
        public static List<string> ListFormatingStrHistoryEn(List<SkierModel> history)
        {
            List<string> strList=new List<string>();
            uint count = 1;
            foreach(var skModel in history)
            {
                strList.Add(String.Format("Training {0}:Performance characteristics skier №{1}, first training {2}km, boost {3}%,  distanse {4}km runing on day {5}",
                    count,skModel.id, skModel.distFirstDay, skModel.persentBoost, skModel.calcDist, skModel.calcDay));
                count++;
            }
            return strList;
        }
        public static List<string> ListFormatingStrHistoryRu(List<SkierModel> history)
        {
            List<string> strList = new List<string>();
            uint count = 1;
            foreach (var skModel in history)
            {
                strList.Add(String.Format("Тренировка {0}:ТТХ бегуна №{1}, первая тренировка {2}km, boost {3}%,  дистанцию {4}km пробежит за {5} дней",
                    count, skModel.id, skModel.distFirstDay, skModel.persentBoost, skModel.calcDist, skModel.calcDay));
                count++;
            }
            return strList;
        }
    }
}
