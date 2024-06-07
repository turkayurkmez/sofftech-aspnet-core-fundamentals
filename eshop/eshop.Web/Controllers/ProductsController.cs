using eshop.Application;
using eshop.Application.DataTransferObject;
using eshop.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace eshop.Web.Controllers
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string AdminOrEdit = "Admin,Editor";

    }

    [Authorize(Roles = Roles.AdminOrEdit )]
    public class ProductsController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
         
            return View(products);
        }

        private IEnumerable<SelectListItem> getCategoriesForSelect()
        {
            var categories = categoryService.GetCategories();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = getCategoriesForSelect();
            return View();
        }

        public IActionResult Create(CreateProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(productRequest);
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = getCategoriesForSelect();
            var product = productService.GetProduct(id);
            if (product != null)
            {
                return View(product);
            }
            ModelState.AddModelError("exist", $"{id} id'li ürün bulunamadı");
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));

            }
            return View();
        }


    }
}
