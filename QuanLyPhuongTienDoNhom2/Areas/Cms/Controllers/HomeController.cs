using Microsoft.AspNetCore.Mvc;

namespace QuanLyPhuongTienDoNhom2.Areas.Cms.Controllers
{
    [Area("cms")]
    //[Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
