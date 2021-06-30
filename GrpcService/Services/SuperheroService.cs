using System.Threading.Tasks;
using Common;
using Grpc.Core;

namespace GrpcService.Services
{
    public class SuperheroService : Superhero.SuperheroBase
    {
        private readonly SuperheroRepository _repository;
        
        public SuperheroService()
        {
            _repository = new SuperheroRepository();
        }
        public override async Task<SuperheroResponse> GetSuperhero(SuperheroRequest request, ServerCallContext context)
        {
            var superhero = _repository.GetSuperhero();

            return await Task.Run(() => new SuperheroResponse()
            {
                Alias = superhero.Alias,
                Name = superhero.Name,
                Height = superhero.Height,
                Weight = superhero.Weight,
                Universe = superhero.Universe.ToString("G")
            });
        }
    }
}