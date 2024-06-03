using introduceDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        //Home/Index
        public IActionResult Index()
        {
            ViewBag.Name = "Türkay";
            ViewBag.Hour = DateTime.Now.Hour;
            ViewBag.Country = "Türkiye";

          var products  = new List<Product>
            {
                new(){ Id=1, Name="X", Price =1},
                new(){ Id=2, Name="Y", Price =10},

            };

          
            return View(products);
        }
        [HttpGet]
        public IActionResult Response()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Response(UserResponse response)
        {

            if (ModelState.IsValid)
            {
                return View("Result", response);
            }
          
            return View();
        }
    }
}
