using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GroceryStoreBL;

namespace GroceryStorePL
{
    public class Service
    {
        private BlService _BlService { get; }
        public int ValidStonesCount { get; set; }

        public Service(int validStonesCount)
        {
            _BlService = new BlService();
            ValidStonesCount = validStonesCount;
        }

        public ExeResult Add(ref ProductPl model)
        {
            List<String> message = new List<string>();
            if (model.Stones != null && model.Stones.Count > ValidStonesCount) message.Add("A lot of stones count>10");
            if (model.JewerlyType_Id <= 0 && model.JewerlyType == null) message.Add("Unknown type");
            if (message.Count > 0) return new ExeResult(message);

            ProductBl productBl = MapTools.MapToProductModel<ProductPl, ProductBl>(model);
            productBl = _BlService.AddProduct(productBl);
            var resultModel = MapTools.MapToProductModel<ProductBl, ProductPl>(productBl);
            if (resultModel != null) model = resultModel;

            return new ExeResult(new List<string>());
        }

        public UserProduct GetProductById(int id)
        {
            var product = _BlService.GetById(id);
            var res = MapTools.MapToUserProduct(product);
            return res;
        }

        public ICollection<UserProduct> GetByType(int id)
        {
            var product = _BlService.GetByType(id);
            List<UserProduct> userProducts = new List<UserProduct>();
            foreach (var item in product)
                userProducts.Add(MapTools.MapToUserProduct(item));
            return userProducts;
        }

        public ICollection<UserProduct> GetByStone(int count)
        {
            var product = _BlService.GetByStone(count);
            List<UserProduct> userProducts = new List<UserProduct>();
            foreach (var item in product)
                userProducts.Add(MapTools.MapToUserProduct(item));
            return userProducts;
        }


    }
}
