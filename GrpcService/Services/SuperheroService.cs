using System.Threading.Tasks;
using Common;
using Grpc.Core;

namespace GrpcService.Services
{
    public class SuperheroService : Superhero.SuperheroBase
    {
        private SuperheroRepository _repository;
        
        public SuperheroService()
        {
            _repository = new SuperheroRepository();
        }
        public override Task<SuperheroResponse> GetSuperhero(SuperheroRequest request, ServerCallContext context)
        {
            var superhero = _repository.GetSuperhero();
            
            return new SuperheroResponse()
            {
                
            }
        }
    }
}