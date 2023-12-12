using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {

        private IRepository repo;
        public CategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public IEnumerable<LoaiSanPham> getCategories()
        {
            return repo.getLoaiSanPhams;
        }
    }
}
