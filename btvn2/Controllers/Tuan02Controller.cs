using Microsoft.AspNetCore.Mvc;

namespace btvn2.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nguyen Trong Tin";
            ViewBag.MSSV = "1822030064";
            ViewBag.Nam = 2003;
            return View();
        }
    }
}
