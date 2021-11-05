namespace GrpcService.Services
{
  using System.Linq;
  using System.Threading.Tasks;
  using Common;
  using Grpc.Core;
  using Superhero = GrpcService.Superhero;

  public class SuperheroService : Superhero.SuperheroBase
  {
    private readonly SuperheroRepository _repository;

    public SuperheroService()
    {
      this._repository = new SuperheroRepository();
    }

    public override async Task<SuperheroResponse> GetSuperhero(SuperheroRequest request, ServerCallContext context)
    {
      var superhero = this._repository.GetSuperhero();

      return await Task.Run(
        () => new SuperheroResponse
        {
          Alias = superhero.Alias,
          Name = superhero.Name,
          Height = superhero.Height,
          Weight = superhero.Weight,
          Universe = superhero.Universe.ToString("G")
        });
    }

    public override async Task<AllSuperheroesResponse> GetSuperheros(SuperheroRequest request, ServerCallContext context)
    {
      var superheroes = this._repository.GetSuperheroes();
      var response = new AllSuperheroesResponse();
      response.Superheroes.Add(
        superheroes.Select(
          superhero => new SuperheroResponse
          {
            Alias = superhero.Alias,
            Name = superhero.Name,
            Height = superhero.Height,
            Weight = superhero.Weight,
            Universe = superhero.Universe.ToString("G")
          }));

      return await Task.Run(() => response);
    }
  }
}