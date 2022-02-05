using Microsoft.AspNetCore.Mvc;

namespace JersonDiaz.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Text()
        {
            return View("Text");
        }
    }
}
