using Microsoft.AspNetCore.Mvc;

namespace MySite.Controllers
{
    public class BlogController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }


    }
}
