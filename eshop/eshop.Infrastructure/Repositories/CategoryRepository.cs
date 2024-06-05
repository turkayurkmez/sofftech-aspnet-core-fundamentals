using eshop.Entities;
using eshop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EshopDbContext dbContext;

        public CategoryRepository(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.AsEnumerable();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
