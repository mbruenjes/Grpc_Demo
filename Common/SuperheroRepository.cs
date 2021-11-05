namespace Common
{
  using System;
  using System.Collections.Generic;

  public class SuperheroRepository
  {
    private readonly List<Superhero> superheroes = new()
    {
      new Superhero
      {
        Alias = "Superman",
        Name = "Clark Joseph Kent",
        Height = 190.5f,
        Weight = 106.6f,
        Universe = Universe.Dc
      },
      new Superhero
      {
        Alias = "Ironman",
        Name = "Anthony Edward Stark",
        Height = 198.1f,
        Weight = 192.8f,
        Universe = Universe.Marvel
      },
      new Superhero
      {
        Alias = "Captain Marvel",
        Name = "Carol Susan Jane Danvers",
        Height = 180.3f,
        Weight = 74.8f,
        Universe = Universe.Marvel
      },
      new Superhero
      {
        Alias = "Batman",
        Name = "Bruce Wayne",
        Height = 188.0f,
        Weight = 95.3f,
        Universe = Universe.Dc
      },
      new Superhero
      {
        Alias = "Flash",
        Name = "Bartholomew Henry Allen",
        Height = 182.9f,
        Weight = 88.5f,
        Universe = Universe.Dc
      },
      new Superhero
      {
        Alias = "Spider-Man",
        Name = "Peter Benjamin Parker",
        Height = 172.7f,
        Weight = 70.3f,
        Universe = Universe.Marvel
      }
    };

    public Superhero GetSuperhero()
    {
      var randomizer = new Random();

      return this.superheroes[randomizer.Next(this.superheroes.Count)];
    }

    public Superhero[] GetSuperheroes()
    {
      return this.superheroes.ToArray();
    }
  }
}