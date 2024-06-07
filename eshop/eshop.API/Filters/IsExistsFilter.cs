using eshop.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class IsExistsFilter : IActionFilter
    {

        private readonly IProductService productService;

        public IsExistsFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = "id parametresi olmalı" });
            }

            if (context.ActionArguments.TryGetValue("id", out object id))
            {

                if (!productService.IsProductExists((int)id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün bulunamadı" });
                }

            }






        }
    }
}
