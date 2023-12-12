using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IRepository repo;
        public ProductController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public IEnumerable<SanPham> getProducts()
        {
            return repo.getProducts;
        }
    }
}
