using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(string id)
        {
            ProductDto product = _productsService.GetProductById(id);
            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Delete(string id)
        {
            ProductDto deletedProduct = _productsService.Delete(id);
            if (deletedProduct == null)
                return NotFound();
            else
                return Ok("The product with id:" + id + "was deleted succesfully!");
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Put(string id, [FromBody] ProductDto product)
        {
            ProductDto updatedProduct = _productsService.Update(id, product);

            if (updatedProduct == null)
            {
                NewProductDto newProduct = new NewProductDto
                {
                    Name = product.Name,
                    Category = product.Category
                };
                _productsService.Add(newProduct);

            }
            return Ok("The product with id:" + id + "was updated succesfully!");
        }
    }
}
