using baitapkiemtra01.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace baitapkiemtra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taikhoan)
        {
            {
                if (taikhoan != null && taikhoan.Password != null && taikhoan.Password.Length > 0)
                {
                    taikhoan.Password = taikhoan.Password + "_da_ma_hoa";
                }
                return View(taikhoan);
            }
        }
        public IActionResult BaiTap02()
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham ="may tinh",
                GiaBan = 20000000,
               image = "/images/maytinh2.png"
                
            };
           
            return View(sanpham); 
        }
    } 
}
