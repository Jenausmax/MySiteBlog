using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Controllers
{
    public class HelpController : Controller
    {
        [Route("Help/Index")]
        [Route("Help/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
