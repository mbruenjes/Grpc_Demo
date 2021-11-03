using Common;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
  [ApiController]
  [Route("/superhero")]
  public class SuperheroController : Controller
  {
    private SuperheroRepository _repository;

    public SuperheroController()
    {
      _repository = new SuperheroRepository();
    }

    // GET
    [HttpGet]
    public ActionResult<Superhero> Index()
    {
      return Ok(_repository.GetSuperhero());
    }

    [HttpGet("all")]
    public ActionResult<Superhero[]> GetAllSuperheroes()
    {
      return Ok(_repository.GetSuperheroes());
    }
  }
}