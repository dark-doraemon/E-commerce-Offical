using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IRepository repo;
        public PersonController(IRepository repo)
        {
            this.repo = repo;
        }

        //[HttpGet("[action]")]
        //public ActionResult<IEnumerable<Person>> people()
        //{
            
        //}
    }
}
