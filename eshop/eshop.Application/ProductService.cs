using eshop.Application.DataTransferObject;
using eshop.Entities;
using eshop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
          return productRepository.GetById(id); 
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = productRepository.GetAll();
            return products;
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            return productRepository.GetProductsByCategoryName(categoryName);

        }

        public void CreateProduct(CreateProductRequest productRequest)
        {
            var product = new Product
            {
                CategoryId = productRequest.CategoryId,
                Description = productRequest.Description,
                ImageUrl = productRequest.ImageUrl,
                Name = productRequest.Name,
                Price = productRequest.Price,
                Rating = productRequest.Rating,
            };
            productRepository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }
    }
}
