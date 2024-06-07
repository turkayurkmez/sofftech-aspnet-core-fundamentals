using eshop.Application;
using eshop.Entities;
using eshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductService productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(string? category, int page = 1)
        {
           // var productService = new FakeProductService();
            var products = category == null ?  productService.GetProducts() : productService.GetProductsByCategory(category) ;

            var pageSize = 4;
            var total = products.Count();
            var pageCount = (int)Math.Ceiling((decimal)total / pageSize);

            /*
             * 1. sayfada: hiç atlama    4'ü göster
             * 2. sayfada: ilk 4'ü atla, 4 göster
             * 3.        : ilk 8'i       4 göster
             * 
             */

            //var paginatedProducts = products.Skip((page - 1) * pageSize).Take(pageSize);
            int startPoint = (page - 1) * pageSize;
            int endPoint = startPoint + pageSize;
            var alternative = products.Take(startPoint..endPoint);

            ViewBag.PageCount = pageCount;
            ViewBag.ActivePage = page;

            
            return View(alternative);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
