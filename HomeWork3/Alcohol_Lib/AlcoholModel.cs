using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Lib
{
    public abstract class AlcoholModel
    {
        public AlcoholModel(string types, string name, string manufacrurer, uint abv, uint kCal)
        {
            Types = types;
            Name = name;
            Manufacturer = manufacrurer;
            AbvPercent = abv;
            KCal = kCal;
        }
        public string Types { get; }
        public string Name { get; }
        public string Manufacturer { get; }
        public uint AbvPercent { get; }
        public uint KCal { get; }
    }
    public class AlcoholBottle : AlcoholModel
    {
        
        public AlcoholBottle(string types, string name, string manufacrurer, uint abv, uint kCal, uint volume, uint quantity,uint price) : base(types, name, manufacrurer, abv, kCal)
        {
            Volume = volume;
            Quantity = quantity;
            Prise = price;

        }
        public uint Volume { get; }
        public uint Quantity { get; private set; }
        public uint Prise { get; set; }
        public uint BayBottle(uint quantity= 1)
        {
            uint bottleBay = 0;
            if (quantity > this.Quantity)
            {
                    bottleBay = this.Quantity;
                    this.Quantity = 0;
            }
            else
            {
                bottleBay = quantity;
                this.Quantity -= quantity;
            }
            return bottleBay;
        }
        public void AddBottle(uint quantity = 1)
        {
            Quantity += quantity;
        }
    }
}
