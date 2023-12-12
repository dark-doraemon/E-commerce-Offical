using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IRepository repo;
        public ProductController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet("[action]")]
        public IEnumerable<SanPham> getProducts()
        {
            return repo.getProducts;
        }
    }
}
