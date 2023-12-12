using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private IRepository repo;
        public CategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<LoaiSanPham> categories()
        {
            return repo.getLoaiSanPhams;
        }
    }
}
