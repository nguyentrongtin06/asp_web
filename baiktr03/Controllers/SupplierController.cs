using baiktr03.Data;
using baiktr03_04.Models;
using Microsoft.AspNetCore.Mvc;

namespace baiktr03_04.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var supplier = _db.Supplier.ToList();
            ViewBag.supplier = supplier;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Supplier.Add(Supplier);

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
            var supplier = _db.Supplier.Find(id);
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng 
                _db.Supplier.Update(supplier);
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
            var supplier = _db.Supplier.Find(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var supplier = _db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            _db.Supplier.Remove(supplier);
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
            var supplier = _db.Supplier.Find(id);
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Details(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.Supplier.Update(Supplier);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
