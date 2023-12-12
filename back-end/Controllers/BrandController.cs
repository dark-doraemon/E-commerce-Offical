using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private IRepository repo;
        public BrandController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public IEnumerable<Brand> brands()
        {
            return repo.getBrands;
        }
    }
}
