using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.theloai.Select(Item => new SelectListItem
            {
                Value = Item.Id.ToString(),
                Text = Item.Name
            });
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sanpham);
            }
            else
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault (sp => sp.Id == id);
                return View(sanpham);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if(sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham); 
                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return Json(new {success=true});
        }
    }
}
