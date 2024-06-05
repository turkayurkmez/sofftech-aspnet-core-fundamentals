using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class FakeProductService : IProductService
    {
        private List<Product> products;
        public FakeProductService()
        {
            var categories = new FakeCategoryService().GetCategories().ToList();

            products = new List<Product>()
            {
                new(){ Id=1, Name="Ürün A", Description="Ürün A Açıklaması", Price=10, Rating=4.6, Category= categories[0]},
                new(){ Id=2, Name="Ürün B", Description="Ürün B Açıklaması", Price=10, Rating=4.6, Category= categories[0] },
                new(){ Id=3, Name="Ürün C", Description="Ürün C Açıklaması", Price=10, Rating=4.6,Category= categories[2]},
                new(){ Id=4, Name="Ürün D", Description="Ürün D Açıklaması", Price=10, Rating=4.6,Category= categories[0]},
                new(){ Id=5, Name="Ürün E", Description="Ürün E Açıklaması", Price=10, Rating=4.6,Category= categories[1]},
                new(){ Id=6, Name="Ürün F", Description="Ürün D Açıklaması", Price=10, Rating=4.6,Category= categories[0]},
                new(){ Id=7, Name="Ürün G", Description="Ürün D Açıklaması", Price=10, Rating=4.6,Category= categories[0]},
                new(){ Id=5, Name="Ürün H1", Description="Ürün E Açıklaması", Price=10, Rating=4.6,Category= categories[1]},
                new(){ Id=5, Name="Ürün H2", Description="Ürün E Açıklaması", Price=10, Rating=4.6,Category= categories[1]},
                new(){ Id=5, Name="Ürün H3", Description="Ürün E Açıklaması", Price=10, Rating=4.6,Category= categories[1]},
                new(){ Id=5, Name="Ürün H4", Description="Ürün E Açıklaması", Price=10, Rating=4.6,Category= categories[1]},



            };
        }
        public IEnumerable<Product> GetProducts()
        {


           

            return products;
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            return products.Where(p => p.Category.Name.Equals(categoryName));
        }
    }
}
