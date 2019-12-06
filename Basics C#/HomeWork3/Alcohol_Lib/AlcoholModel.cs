using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Lib
{
    public abstract class AlcoholModel
    {
        public AlcoholModel(string types, string name, string manufacrurer, double abv, uint kCal)
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
        public double AbvPercent { get; }
        public uint KCal { get; }
    }
    public class AlcoholBottle : AlcoholModel, IEquatable<AlcoholBottle>
    {
        
        public AlcoholBottle(string types, string name, string manufacrurer, double abv, uint kCal, uint volume, uint quantity,uint price) : base(types, name, manufacrurer, abv, kCal)
        {
            Volume = volume;
            Quantity = quantity;
            Prise = price;
            PrisePosition = Quantity * Prise;

        }
        public uint Volume { get; }
        public uint Quantity { get; private set; }
        public uint Prise { get; private set; }
        public uint PrisePosition { get; private set; } 
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
        public void AddQuantityBottle(uint quantity = 1)
        {
            Quantity += quantity;
            this.PrisePosition = this.Quantity * this.Prise;
        }
        public void NewValueQuantity(uint quantity)
        {
            this.Quantity = quantity;
            this.PrisePosition = this.Quantity * this.Prise;
        }
        public void NewPrise(uint prise)
        {
            this.Prise = prise;
            this.PrisePosition = this.Quantity * this.Prise;
        }
        public bool Equals(AlcoholBottle otherBottle )
        {
            if (this.Types == otherBottle.Types && this.AbvPercent == otherBottle.AbvPercent && this.KCal == otherBottle.KCal
                && this.Name == otherBottle.Name && this.Manufacturer == otherBottle.Manufacturer && this.Volume==otherBottle.Volume) return true;
            else return false;
        }
    }
}
