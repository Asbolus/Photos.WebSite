using Microsoft.AspNetCore.Mvc;
using Photos.WebSite.Models;
using Photos.WebSite.Services;
using System.Collections.Generic;

namespace Photos.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpGet("Rate")]
        public ActionResult AddRating([FromQuery] string productId, [FromQuery] int rating)
        {
            ProductService.AddRating(productId, rating);

            return Ok();
        }
    }
}