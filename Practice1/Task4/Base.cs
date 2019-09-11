using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    interface IBase
    {
        int CountAllPosition { get; }
        int CountAllFurniture { get; }
        int CountAllMaterial { get; }
        void Add(Product product);
        bool Remove(Product product);
        bool RemoveAt(int index);
        void RemoveAllPos();
        List<Product> GetProducts();
        void SortMaterialFirst();
        void SortFurnitureFirst();
        void PrintAll();
        void PrintByIndex(int index);
        void PrintFurnitures();
        void PrintMaterials();
    }

    public class Base : IBase
    {
        List<Product> lstProducts;
        protected IDisplay display;
        public int CountAllPosition
        {
            get
            {
                return lstProducts.Count();
            }
        }

        public int CountAllFurniture
        {
            get
            {
                return lstProducts.Where((i) => i is Furniture).Count();
            }
        }

        public int CountAllMaterial
        {
            get
            {
                return lstProducts.Where((i) => i is Material).Count();
            }
        }

        public Base(IDisplay display)
        {
            lstProducts = new List<Product>();
            this.display = display;
        }

        public void Add(Product product)
        {
            if (lstProducts.Contains(product))
            {
                lstProducts[lstProducts.IndexOf(product)].Count += product.Count;
            }
            else lstProducts.Add(product);
        }
        /*
         * Типа удаляем не столько объект сколько количество и если удаялемое количество
         * больше имеющегося удаляем объект
         * 
         * */
        public bool Remove(Product product)
        {
            if (lstProducts.Contains(product))
            {
                lstProducts[lstProducts.IndexOf(product)].Count -= product.Count;
                if(lstProducts[lstProducts.IndexOf(product)].Count <= 0) return lstProducts.Remove(product);
                else return true;
            }
            return lstProducts.Remove(product);
        }

        public bool RemoveAt(int index)
        {
            if (index >= lstProducts.Count || index < 0) return false;
            else lstProducts.RemoveAt(index);
            return true;
        }

        public void RemoveAllPos()
        {
            lstProducts.Clear();
        }

        public List<Product> GetProducts()
        {
            return lstProducts;
        }

        public void SortMaterialFirst()//хз зачем
        {
            List<Material> lstM = GetAllMaterials();
            List<Furniture> lstF = GetAllFurniture();
            lstProducts.Clear();
            lstProducts.AddRange(lstM);
            lstProducts.AddRange(lstF);
        }

        public void SortFurnitureFirst()//хз зачем
        {
            List<Material> lstM = GetAllMaterials();
            List<Furniture> lstF = GetAllFurniture();
            lstProducts.Clear();
            lstProducts.AddRange(lstF);
            lstProducts.AddRange(lstM);
        }

        private List<Material> GetAllMaterials()
        {
            List<Material> lst = new List<Material>();
            foreach (var item in lstProducts.Where((i) => i is Material))
                lst.Add((Material)item);
            return lst;
        }

        private List<Furniture> GetAllFurniture()
        {
            List<Furniture> lst = new List<Furniture>();
            foreach (var item in lstProducts.Where((i) => i is Furniture))
                lst.Add((Furniture)item);
            return lst;
        }
        /*
         * Вот тут как то все не красиво 
         */
        public void PrintAll()
        {
            Print(lstProducts);
        }

        public void PrintByIndex(int index)
        {
            if (index < lstProducts.Count && index >= 0) display.Print(lstProducts[index].GetInfo());
            else throw new IndexOutOfRangeException();
        }

        public void PrintFurnitures()
        {
            Print(lstProducts.Where((i) => i is Furniture).ToList());
        }

        public void PrintMaterials()
        {
            Print(lstProducts.Where((i) => i is Material).ToList());
        }

        private void Print(List<Product> lst)
        {
            string message = String.Empty;
            foreach (var items in lst)
            {
                message += items.GetInfo();
            }
            display.Print(message);
        }
    }
}
