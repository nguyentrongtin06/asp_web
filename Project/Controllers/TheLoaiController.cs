using Project.Data;
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class TheLoaiController : Controller
    {
       
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.theloai.ToList();
            ViewBag.theloai=theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                _db.theloai.Add(theLoai);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theloai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.theloai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theloai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.theloai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.theloai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theloai.Find(id);
            return View(theloai);
        }
        [HttpGet]
        public IActionResult Details(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.theloai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Search(String searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var theloai= _db.theloai.
                Where(tl => tl.Name.Contains(searchString)).ToList();
                ViewBag.searchString = searchString;
                ViewBag.TheLoai = theloai;
            }
            else
            {
                var theloai = _db.theloai.ToList();
                ViewBag.Theloai = theloai;
            }
            return View("index");
        }
    }
}
