using eshop.API.Filters;
using eshop.Application;
using eshop.Application.DataTransferObject;
using eshop.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            return product == null ? NotFound(new { message = "belirtilen id'de ürün yok" }) : Ok(product);

        }

        [HttpGet("[action]/{name}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search(string name)
        {
            var products = _productService.SearchProductsByName(name);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Create(CreateProductRequest createProductRequest)
        {
            if (ModelState.IsValid)
            {
                var lastId = _productService.CreateProduct(createProductRequest);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = lastId }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [IsExists]
        public IActionResult Update(int id, Product product)
        {

            //if (id<10 || id>1000)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(id), actualValue:id,message:string.Empty);
            //}


            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return Ok(product);
            }
            return BadRequest(ModelState);





        }

        [HttpDelete("{id}")]
        [IsExists]
        public IActionResult Delete(int id)
        {


            _productService.DeleteProduct(id);
            return Ok();

        }



    }
}
