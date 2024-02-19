using Microsoft.AspNetCore.Mvc;

namespace BBShop.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(int? loai)
        {
            return View();
        }
    }
}
