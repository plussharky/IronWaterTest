using IronWaterStudioNet6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IronWaterStudioNet6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Developer()
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