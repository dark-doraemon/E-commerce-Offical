using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IRepository repo;
        public HomeController(IRepository repo)
        {
            this.repo = repo;   
        }

        [HttpGet]
        public IEnumerable<SanPham> Index()
        {
            var s = repo.getSanPham;
            return repo.getSanPham;
        }
    }
}
