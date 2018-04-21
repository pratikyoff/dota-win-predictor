using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Host.Controllers
{
    [Route("")]
    public class WebPageController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return File(new FileStream("wwwroot/index.html", FileMode.Open), "text/html");
        }
    }
}
