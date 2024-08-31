using Microsoft.AspNetCore.Mvc;

namespace bt03.Controllers
{
    public class NhomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
