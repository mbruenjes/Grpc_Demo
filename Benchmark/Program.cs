namespace Benchmark
{
  using System;
  using System.Linq;
  using System.Net.Http;
  using System.Threading.Tasks;
  using BenchmarkDotNet.Attributes;
  using BenchmarkDotNet.Running;
  using Grpc.Net.Client;
  using Grpc.Net.Client.Web;
  using GrpcService;
  using SuperheroServiceRest;
  using SuperheroServiceSoap;
  using Superhero = GrpcService.Superhero;
  using Universe = Common.Universe;

  public class SuperheroBenchmark : IDisposable
  {
    private readonly GrpcChannel channel;

    // gRPC
    private readonly Superhero.SuperheroClient grpcClient;

    // SOAP
    private readonly SuperheroServiceClient superheroServiceClient;

    // REST
    private readonly SuperheroServiceRest superheroServiceRest;

    public SuperheroBenchmark()
    {
      this.superheroServiceClient = new SuperheroServiceClient(SuperheroServiceClient.EndpointConfiguration.BasicHttpsBinding_ISuperheroService);

      var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
      this.channel = GrpcChannel.ForAddress(
        "https://grpcservice20211105010651.azurewebsites.net",
        new GrpcChannelOptions
        {
          HttpClient = new HttpClient(handler)
        });
      this.grpcClient = new Superhero.SuperheroClient(this.channel);

      this.superheroServiceRest = new SuperheroServiceRest(
        "https://grpc-demo-restserviceapi.azure-api.net/",
        new HttpClient());
    }

    public void Dispose()
    {
      this.channel.Dispose();
    }

    [Benchmark]
    public async Task<Common.Superhero> Grpc()
    {
      var response = await this.grpcClient.GetSuperheroAsync(new SuperheroRequest());

      return new Common.Superhero
      {
        Alias = response.Alias,
        Name = response.Name,
        Height = response.Height,
        Weight = response.Weight,
        Universe = Enum.Parse<Universe>(response.Universe)
      };
    }

    [Benchmark]
    public async Task<Common.Superhero> Rest()
    {
      var response = await this.superheroServiceRest.SuperheroAsync();

      return new Common.Superhero
      {
        Alias = response.Alias,
        Name = response.Name,
        Height = (float)response.Height,
        Weight = (float)response.Weight,
        Universe = (Universe)response.Universe
      };
    }

    [Benchmark]
    public async Task<Common.Superhero> Soap()
    {
      var response = await this.superheroServiceClient.GetSuperheroAsync();

      return new Common.Superhero
      {
        Alias = response.Alias,
        Name = response.Name,
        Height = response.Height,
        Weight = response.Weight,
        Universe = (Universe)response.Universe
      };
    }
  }

  public class AllSuperheroesBenchmark : IDisposable
  {
    private readonly GrpcChannel channel;

    // gRPC
    private readonly Superhero.SuperheroClient grpcClient;

    // SOAP
    private readonly SuperheroServiceClient superheroServiceClient;

    // REST
    private readonly SuperheroServiceRest superheroServiceRest;

    public AllSuperheroesBenchmark()
    {
      this.superheroServiceClient = new SuperheroServiceClient(SuperheroServiceClient.EndpointConfiguration.BasicHttpsBinding_ISuperheroService);
      var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
      this.channel = GrpcChannel.ForAddress(
        "https://grpcservice20211105010651.azurewebsites.net",
        new GrpcChannelOptions
        {
          HttpClient = new HttpClient(handler)
        });
      this.grpcClient = new Superhero.SuperheroClient(this.channel);

      this.superheroServiceRest = new SuperheroServiceRest(
        "https://grpc-demo-restserviceapi.azure-api.net/",
        new HttpClient());
    }

    public void Dispose()
    {
      this.channel.Dispose();
    }

    [Benchmark]
    public async Task<Common.Superhero[]> Grpc()
    {
      var response = await this.grpcClient.GetSuperherosAsync(new SuperheroRequest());

      return response.Superheroes.Select(
        superhero => new Common.Superhero
        {
          Alias = superhero.Alias,
          Name = superhero.Name,
          Height = superhero.Height,
          Weight = superhero.Weight,
          Universe = Enum.Parse<Universe>(superhero.Universe)
        }).ToArray();
    }

    [Benchmark]
    public async Task<Common.Superhero[]> Rest()
    {
      var response = await this.superheroServiceRest.AllAsync();

      return response.Select(
        superhero => new Common.Superhero
        {
          Alias = superhero.Alias,
          Name = superhero.Name,
          Height = (float)superhero.Height,
          Weight = (float)superhero.Weight,
          Universe = (Universe)superhero.Universe
        }).ToArray();
    }

    [Benchmark]
    public async Task<Common.Superhero[]> Soap()
    {
      var response = await this.superheroServiceClient.GetSuperheroesAsync();

      return response.Select(
        superhero => new Common.Superhero
        {
          Alias = superhero.Alias,
          Name = superhero.Name,
          Height = superhero.Height,
          Weight = superhero.Weight,
          Universe = (Universe)superhero.Universe
        }).ToArray();
    }
  }

  internal class Program
  {
    private static void Main(string[] args)
    {
      var summary = BenchmarkRunner.Run(typeof(SuperheroBenchmark));
      var summaryAll = BenchmarkRunner.Run(typeof(AllSuperheroesBenchmark));
      Console.ReadKey();
    }
  }
}