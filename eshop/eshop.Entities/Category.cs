﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Categeory bilgisayar = new Category();
        //bilgisayar.Products.Add(new Product());

        //Navigation property:
        public IList<Product> Products { get; set; }
    }
}
