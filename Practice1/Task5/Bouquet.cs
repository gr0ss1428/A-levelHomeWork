using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5
{
    public interface IBouquet
    {
        int CountFlower { get; }
        double Price { get; }

        void Add(Flower flower);

        bool Remove(Flower flower);

        void GetInfo();
    }

    public class Bouquet : IBouquet
    {
        private List<Flower> lstFlower;
        public IDisplay display;

        public int CountFlower
        {
            get
            {
                return lstFlower.Count;
            }
        }

        public double Price
        {
            get
            {
                return lstFlower.Sum(i => i.Count * i.Price);
            }
        }

        public Bouquet(IDisplay display)
        {
            this.display = display;
            lstFlower = new List<Flower>();
        }

        /*
         *Так как я это делал в задаче 4 думаю такое адд и удаление тут более актуально
         *
         */

        public void Add(Flower flower)
        {
            if (lstFlower.Contains(flower))
            {
                lstFlower[lstFlower.IndexOf(flower)].Count += flower.Count;
            }
            else lstFlower.Add(flower);
        }

        public bool Remove(Flower flower)
        {
            if (lstFlower.Contains(flower))
            {
                lstFlower[lstFlower.IndexOf(flower)].Count -= flower.Count;
                if (lstFlower[lstFlower.IndexOf(flower)].Count <= 0) return lstFlower.Remove(flower);
                else return true;
            }
            else return lstFlower.Remove(flower);
        }

        /*
         * Может и не стоило это делать, но кажется перегрузка +- с цветами тут в самый раз
         * */

        public static Bouquet operator +(Bouquet bouquet, Flower flower)
        {
            bouquet.Add(flower);
            return bouquet;
        }

        public static Bouquet operator -(Bouquet bouquet, Flower flower)
        {
            bouquet.Remove(flower);
            return bouquet;
        }

        public static Bouquet operator +(Bouquet bouquet1, Bouquet bouquet2)
        {
            foreach (var items in bouquet2.lstFlower)
                bouquet1.Add(items);
            return bouquet1;
        }

        public static Bouquet operator -(Bouquet bouquet1, Bouquet bouquet2)
        {
            foreach (var items in bouquet2.lstFlower)
                bouquet1.Remove(items);
            return bouquet1;
        }

        public void GetInfo()
        {
            StringBuilder message = new StringBuilder(string.Empty);
            foreach (var flow in lstFlower)
            {
                message.Append(flow.GetInfo());
            }
            message.Append($"\tPrice bouquet:{Price}");
            display.PrintInfo(message.ToString());
        }
    }
}