using IronWaterStudioNet6.Models;
using IronWaterStudioNet6.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IronWaterStudioNet6.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 5;

        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public ProductController(IProductRepository repo, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            repository = repo;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public ViewResult Users()
        {
            return View(userManager.Users);
        }

        public ViewResult SignInUsers()
        {
            return View("Users", signInManager.UserManager.Users);
        }

        [Authorize]
        public ViewResult List(int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                pagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },
                products = repository.Products
                 .OrderBy(p => p.ProductID)
                 .Skip((productPage - 1) * PageSize)
                 .Take(PageSize),
            });
        }

        [Authorize]
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [Authorize]
        [HttpGet]
        public ViewResult Edit(int productId)
        {
            return View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction(nameof(List));
            }
            else
                return View(product);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction(nameof(List));
        }
    }
}
