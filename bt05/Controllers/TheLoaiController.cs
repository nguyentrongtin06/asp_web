using bt05.Models;
using Microsoft.AspNetCore.Mvc;

namespace bt05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 28";
            ViewBag.Thang = "Tháng 30";
            ViewData["Nam"] = "năm 100 nhớ";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                Id = 1,
                Name = "trinh tham"
            };
            return View(theloai);
        }
    }
}
