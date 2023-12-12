using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
