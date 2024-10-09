using baiktr03.Data;
using baiktr03_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace baiktr03_04.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Order> order = _db.Order.Include("supplier").ToList();
            return View(order);  
        }
    }
}
