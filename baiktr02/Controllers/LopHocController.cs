﻿using baiktr02.Data;
using baiktr02.Models;
using Microsoft.AspNetCore.Mvc;

namespace baiktr02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LopHocController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var lophoc = _db.LopHoc.ToList();
            ViewBag.Lophoc = lophoc;       
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult themmoi(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                _db.LopHoc.Add(lophoc);

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
            var lophoc = _db.LopHoc.Find(id);
            return View(lophoc);
        }
        [HttpPost]
        public IActionResult ChinhSua(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.LopHoc.Update(lophoc);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult xoa(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            return View(lophoc);
        }

        [HttpPost]
        public IActionResult xoanb(int id)
        {
            var lophoc = _db.LopHoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            _db.LopHoc.Remove(lophoc);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult xemchitiet(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.LopHoc.Update(lophoc);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
