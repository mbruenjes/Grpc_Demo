namespace RestService.Controllers
{
  using Common;
  using Microsoft.AspNetCore.Mvc;

  [ApiController]
  [Route("/superhero")]
  public class SuperheroController : Controller
  {
    private readonly SuperheroRepository _repository;

    public SuperheroController()
    {
      this._repository = new SuperheroRepository();
    }

    [HttpGet("all")]
    public ActionResult<Superhero[]> GetAllSuperheroes()
    {
      return this.Ok(this._repository.GetSuperheroes());
    }

    // GET
    [HttpGet]
    public ActionResult<Superhero> Index()
    {
      return this.Ok(this._repository.GetSuperhero());
    }
  }
}