using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Lib
{
   public static class AlcoholBase
    {
        static Dictionary<string, List<AlcoholBottle>> _alcoholBase;

        static AlcoholBase()
        {
            _alcoholBase = new Dictionary<string, List<AlcoholBottle>>();
            AddRandomValue();

        }
        public static bool newAlcoholTypes(string types)
        {
            if (!_alcoholBase.ContainsKey(types))
            {
                _alcoholBase.Add(types, new List<AlcoholBottle>());
                return true;
            }
            else return false;
        }
        public static List<string> GetAlcoholTypesLst()
        {
           
            return _alcoholBase.Keys.ToList();
        }
        public static AlcoholBottle[] GetAlcoholItemsByTypesArr(string types)
        {

            return _alcoholBase[types].ToArray();
        }
        public static void AddNewBottle(AlcoholBottle alcoholBottle)
        {
            newAlcoholTypes(alcoholBottle.Types);
            if (!_alcoholBase[alcoholBottle.Types].Contains(alcoholBottle)) _alcoholBase[alcoholBottle.Types].Add(alcoholBottle);
            else
            {
                foreach(var alcBatle in _alcoholBase[alcoholBottle.Types])
                {
                    if (alcBatle.Equals(alcoholBottle))
                    {
                        alcBatle.AddQuantityBottle( alcoholBottle.Quantity);
                        alcBatle.NewPrise(alcoholBottle.Prise);
                    }
                }
            }
        }
        public static bool RemoveAlcohoBottleinBase(string types,AlcoholBottle bottle)//ударение по ключу и обЪукту
        {
           
            if (_alcoholBase.ContainsKey(types))
            {
                return _alcoholBase[types].Remove(bottle);
            }
            else return false;
        }
        public static bool RemoveAlcohoBottleinBase(uint typesNum, uint numBottle)//Удаление по порядковому номеру
        {
            string typesStr = _alcoholBase.Keys.ToArray()[typesNum];
            if (_alcoholBase.ContainsKey(typesStr))
            {
                return _alcoholBase[typesStr].Remove(_alcoholBase[typesStr].ToArray()[numBottle]);
            }
            else return false;
        }
        public static bool RemoveAlcohoBottleAll(uint types)
        {
            string[] typesArr = _alcoholBase.Keys.ToArray();
            if (types < typesArr.Length)
            {
                string typesStr = typesArr[types];
                _alcoholBase[typesStr].RemoveRange(0, _alcoholBase[typesStr].Count);
                return true;
            }
            else return false;
        }
        public static int GetQuantityBottleInTypes(string types)
        {
            if (_alcoholBase.ContainsKey(types)) return _alcoholBase[types].Count;
            else return -1;
        }
        public static bool RemoveAlcohoBottleAll(string types)
        {
            if (_alcoholBase.ContainsKey(types))
            {
                _alcoholBase[types].RemoveRange(0, _alcoholBase[types].Count);
                return true;
            }
            else return false;
        }
        public static void EditPosition(string types, int items, uint newQuantity, uint newPrice)
        {

            if (_alcoholBase.ContainsKey(types))
            {
                _alcoholBase[types][items].NewValueQuantity(newQuantity);
                _alcoholBase[types][items].NewPrise(newPrice);
            }
        }
       public static string GetItemStr(AlcoholBottle bottle)
        {
            return $"Имя:{bottle.Name} Производитель:{bottle.Manufacturer} Об.:{bottle.AbvPercent} Ккал:{bottle.KCal} Млл:{bottle.Volume} Кол-во:{bottle.Quantity} Цена:{bottle.Prise} Cтоимость:{bottle.PrisePosition}";
        }
        public static void AddRandomValue()
        {
            AlcoholBase.newAlcoholTypes("Beer");
            AlcoholBase.newAlcoholTypes("Wine");
            AlcoholBase.newAlcoholTypes("Vodka");
            AlcoholBottle ab1 = new AlcoholBottle("Beer", "Guinness", "Diageo", 4.1, 35, 500, 10, 50);
            AlcoholBottle ab2 = new AlcoholBottle("Beer", "Murphy’s", "Murphy’s", 5.1, 35, 500, 50, 50);
            AlcoholBottle ab3 = new AlcoholBottle("Beer", "Newcastle Brown Ale", "Scottish & Newcastle", 4.7, 30, 500, 50, 40);
            AlcoholBottle aw1 = new AlcoholBottle("Wine", "Charton Bordeaux", "Bordeaux", 12, 83, 750, 30, 210);
            AlcoholBottle aw2 = new AlcoholBottle("Wine", "Chateau Prieure-Lichine", "Chateau Prieure-Lichine", 12.5, 83, 750, 30, 6200);
            AlcoholBottle aw3 = new AlcoholBottle("Wine", "Moet & Chandon Brut Imperial", "Moet", 12, 80, 750, 10, 1800);
            AlcoholBase.AddNewBottle(ab1);
            AlcoholBase.AddNewBottle(ab2);
            AlcoholBase.AddNewBottle(ab3);
            AlcoholBase.AddNewBottle(aw1);
            AlcoholBase.AddNewBottle(aw2);
            AlcoholBase.AddNewBottle(aw3);
        }
    }
}
