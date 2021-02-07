using Microsoft.AspNetCore.Mvc;

namespace MySite.Controllers
{
    public class BlogController : Controller
    {
        [Route("Blog/Index")]
        [Route("Blog/")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
