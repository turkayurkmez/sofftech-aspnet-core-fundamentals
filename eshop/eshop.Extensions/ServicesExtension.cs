using eshop.Application;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddNecessariesForApp(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<EshopDbContext>(option => option.UseSqlServer(connectionString));

            return services;
        }
    }
}
