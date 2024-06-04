using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new(){ Id=1, Name="Ürün X", Description="Ürün X Açıklaması", Price=10, Rating=4.6},
                new(){ Id=2, Name="Ürün Y", Description="Ürün Y Açıklaması", Price=10, Rating=4.6},
                new(){ Id=3, Name="Ürün Z", Description="Ürün Z Açıklaması", Price=10, Rating=4.6},
                new(){ Id=4, Name="Ürün W", Description="Ürün W Açıklaması", Price=10, Rating=4.6},
                new(){ Id=5, Name="Ürün Q", Description="Ürün Q Açıklaması", Price=10, Rating=4.6},

            };

            return products;
        }

        public List<Product> GetProductsByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
