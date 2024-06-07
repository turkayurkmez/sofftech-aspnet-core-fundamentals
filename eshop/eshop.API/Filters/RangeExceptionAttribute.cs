using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class RangeExceptionAttribute : ExceptionFilterAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
        //Bu attribute'ün kullanıldığı action'da bir hata olıuşursa; bu filtre yakalayacak.

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                var exception = (ArgumentOutOfRangeException)context.Exception;
                context.Result = new BadRequestObjectResult(new { error = $"verilen {exception.ActualValue} değeri kabul edilmiyor. {Min} ve {Max} değerleri arasında olmalı" });
            }
        }

    }
}
