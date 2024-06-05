﻿using eshop.Application;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddSession(opt =>
{
    //elbette; tüm option özelliklerinin varsayılan değerleri var
    opt.IdleTimeout = TimeSpan.FromMinutes(20); 
});


var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<EshopDbContext>(option => option.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseAuthorization();


app.MapControllerRoute(
     name: "category",
     pattern: "{category?}/Sayfa{page}",
     defaults: new { controller = "Home", action = "Index", page = 1  }
    );

app.MapControllerRoute(
     name:"paging",
     pattern:"Sayfa{page}",
     defaults:new {controller = "Home",action="Index", page=1}
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
