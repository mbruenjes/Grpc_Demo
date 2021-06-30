using System;
using System.Collections.Generic;

namespace Common
{
    public class SuperheroRepository
    {
        private readonly List<Superhero> _superheroes = new()
        {
            new()
            {
                Alias = "Superman",
                Name = "Clark Joseph Kent",
                Height = 190.5f,
                Weight = 106.6f,
                Universe = Universe.Dc
            },
            new ()
            {
                Alias = "Ironman",
                Name = "Anthony Edward Stark",
                Height = 198.1f,
                Weight = 192.8f,
                Universe = Universe.Marvel
            }
        };

        public Superhero GetSuperhero()
        {
            var randomizer = new Random();

            return _superheroes[randomizer.Next(_superheroes.Count)];
        }
    }
}
