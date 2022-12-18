using IronWaterStudioNet6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace IronWaterStudioNet6.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IProductRepository repository;

        public DataController(IProductRepository repo,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            repository = repo;
        }

        [HttpGet("[action]/{productId}")]
        public ActionResult GetProduct(int productId = 1)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(product),
                    ContentType = "application/json"
                };
            else
                return NotFound();
        }

        [HttpGet("[action]/{name}&{priceMin:decimal}&{priceMax:decimal}")]
        [HttpGet("[action]/{name}&{priceMin:decimal}")]
        [HttpGet("[action]/{name}")]
        [HttpGet("[action]/")]
        public ActionResult GetFiltredList(string? name,
            decimal priceMin = 0, decimal priceMax = 1000000000)
        {
            IQueryable<Product> products = repository.Products;
            if (String.IsNullOrEmpty(name) == false)
                products = products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            products = products.Where(p => p.Price >= priceMin && p.Price <= priceMax);
            if (products?.Count() > 0)
                return new ContentResult {
                    Content = JsonConvert.SerializeObject(products),
                    ContentType = "application/json"
                };
            else
                return NotFound();
        }
    }
}
