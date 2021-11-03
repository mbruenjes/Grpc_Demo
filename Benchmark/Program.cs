using System;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Grpc.Net.Client;
using SuperheroServiceSoap;
using Superhero = Common.Superhero;
using Universe = Common.Universe;

namespace Benchmark
{
  public class SuperheroBenchmark : IDisposable
  {
    // SOAP
    private readonly SuperheroServiceClient superheroServiceClient;
    private readonly GrpcChannel channel;

    // gRPC
    private readonly GrpcService.Superhero.SuperheroClient grpcClient;

    // REST
    private readonly SuperheroServiceRest.SuperheroServiceRest superheroServiceRest;

    public SuperheroBenchmark()
    {
      superheroServiceClient = new SuperheroServiceClient();

      channel = GrpcChannel.ForAddress("https://localhost:5001");
      grpcClient = new GrpcService.Superhero.SuperheroClient(channel);

      superheroServiceRest = new SuperheroServiceRest.SuperheroServiceRest("https://localhost:6001", new System.Net.Http.HttpClient());
    }

    [Benchmark]
    public async Task<Superhero> Soap()
    {
      var response = await superheroServiceClient.GetSuperheroAsync();

      return new Superhero()
      {
        Alias = response.Alias,
        Name = response.Name,
        Height = response.Height,
        Weight = response.Weight,
        Universe = (Universe)response.Universe
      };
    }

    [Benchmark]
    public async Task<Superhero> Grpc()
    {

      var response = await grpcClient.GetSuperheroAsync(new GrpcService.SuperheroRequest());

      return new Superhero()
      {
        Alias = response.Alias,
        Name = response.Name,
        Height = response.Height,
        Weight = response.Weight,
        Universe = Enum.Parse<Universe>(response.Universe)
      };
    }

    [Benchmark]
    public async Task<Superhero> Rest()
    {
      var response = await superheroServiceRest.SuperheroAsync();

      return new Superhero()
      {
        Alias = response.Alias,
        Name = response.Name,
        Height = (float)response.Height,
        Weight = (float)response.Weight,
        Universe = (Universe)response.Universe
      };
    }

    public void Dispose()
    {
      channel.Dispose();
    }
  }

  public class AllSuperheroesBenchmark : IDisposable
  {
    // SOAP
    private readonly SuperheroServiceClient superheroServiceClient;
    private readonly GrpcChannel channel;

    // gRPC
    private readonly GrpcService.Superhero.SuperheroClient grpcClient;

    // REST
    private readonly SuperheroServiceRest.SuperheroServiceRest superheroServiceRest;

    public AllSuperheroesBenchmark()
    {
      superheroServiceClient = new SuperheroServiceClient();

      channel = GrpcChannel.ForAddress("https://localhost:5001");
      grpcClient = new GrpcService.Superhero.SuperheroClient(channel);

      superheroServiceRest = new SuperheroServiceRest.SuperheroServiceRest("https://localhost:6001", new System.Net.Http.HttpClient());
    }

    [Benchmark]
    public async Task<Superhero[]> Soap()
    {
      var response = await superheroServiceClient.GetSuperheroesAsync();

      return response.Select(superhero => new Superhero()
      {
        Alias = superhero.Alias,
        Name = superhero.Name,
        Height = (float)superhero.Height,
        Weight = (float)superhero.Weight,
        Universe = (Universe)superhero.Universe
      }).ToArray();
    }

    [Benchmark]
    public async Task<Superhero[]> Grpc()
    {

      var response = await grpcClient.GetSuperherosAsync(new GrpcService.SuperheroRequest());

      return response.Superheroes.Select(superhero => new Superhero()
      {
        Alias = superhero.Alias,
        Name = superhero.Name,
        Height = superhero.Height,
        Weight = superhero.Weight,
        Universe = Enum.Parse<Universe>(superhero.Universe)
      }).ToArray();
    }

    [Benchmark]
    public async Task<Superhero[]> Rest()
    {
      var response = await superheroServiceRest.AllAsync();

      return response.Select(superhero => new Superhero()
      {
        Alias = superhero.Alias,
        Name = superhero.Name,
        Height = (float)superhero.Height,
        Weight = (float)superhero.Weight,
        Universe = (Universe)superhero.Universe
      }).ToArray();
    }

    public void Dispose()
    {
      channel.Dispose();
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var summary = BenchmarkRunner.Run(typeof(SuperheroBenchmark));
      var summaryAll = BenchmarkRunner.Run(typeof(AllSuperheroesBenchmark));
      Console.ReadKey();
    }
  }
}