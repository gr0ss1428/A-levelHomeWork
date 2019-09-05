using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStock
{
   public class Stock
    {
        List<SProduct> stock;
        public double MaxVolume { get; private set; }
        public double CurrentVolume { get; private set; }
        public delegate void AddSome();
        public event AddSome update;
        public Stock(double maxVolume)
        {
            MaxVolume = maxVolume;
            CurrentVolume = 0;
            stock = new List<SProduct>();
        }
        public bool AddProduct(SProduct sp)
        {
            if (CurrentVolume + sp.Volume > MaxVolume) return false;
            else
            {
                CurrentVolume += sp.Volume;
                stock.Add(sp);
                update();
                return true;
            }
        }
        public bool IsPlace(SProduct sp)
        {
            return CurrentVolume + sp.Volume <= MaxVolume;
        }
        public double CurrentFreeSpace()
        {
            return MaxVolume - CurrentVolume;
        }
        public void WriteOff(DateTime dateTime)
        {
            var expir = stock.ToArray().Where((i) => i.IsExpired(dateTime) == true);
            int z = expir.Count();
            for(int i=0;i<z;i++)
            {
                stock.Remove(expir.ElementAt(i));
                CurrentVolume -= expir.ElementAt(i).Volume;
            }
            update();
        }
        public void  StockExtension(int ext)
        {
            MaxVolume += ext;
        }
        public SProduct[] GetSProductsArr()
        {
            return stock.ToArray();
        }
    }
}
