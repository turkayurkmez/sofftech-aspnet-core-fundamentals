﻿using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class FakeCategoryService : ICategoryService
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new(){ Id=1, Name="Kitap"},
                new(){ Id=2, Name="Müzik"},
                new(){ Id=3, Name="Bilgisayar"},

            };


        }
    }
}
