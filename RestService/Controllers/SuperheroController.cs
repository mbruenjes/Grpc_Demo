using Common;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [ApiController]
    [Route("/")]
    public class SuperheroController : Controller
    {
        private SuperheroRepository _repository;
        
        public SuperheroController()
        {
            _repository = new SuperheroRepository();
        }
        
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_repository.GetSuperhero());
        }
    }
}