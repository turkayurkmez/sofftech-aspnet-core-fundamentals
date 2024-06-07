﻿using eshop.Application.DataTransferObject;
using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(string categoryName);

        Product GetProduct(int id);
        void CreateProduct(CreateProductRequest productRequest);
        void UpdateProduct(Product product);
    }
}
