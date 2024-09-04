using Microsoft.AspNetCore.Mvc;

namespace bt04.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Edit(int id)
        {
            return Ok("Id: "+ id);
        }

        public IActionResult Detail(int id,string ten)
        {
            //return Content("Id: " + id +" ;ten: "+ten);
            return Content(string.Format("Id:{0}; ten: {1} ", id,ten));
        }

        public IActionResult Show(List<string> categories)
        {
            string content = "danh sach the loai: ";
            foreach (var category in categories)
            {
                content = content + " " + category + ", ";
            }
            return Content(content);
        }
    }
}
