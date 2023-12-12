using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private IRepository repo;
        public BrandController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet("[action]")]
        public IEnumerable<Brand> getBrands()
        {
            return repo.getBrands;
        }
    }
}
