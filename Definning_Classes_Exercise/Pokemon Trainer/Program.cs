using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; } = 0;
        public List<Pokemon> CollectionOfPokemon { get; set; }
        public Trainer(string name)
        {
            this.Name = name;
            CollectionOfPokemon = new List<Pokemon>();
        }

    }
    public class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
        public Pokemon(string name,string element,int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                bool istrainersame = false;
                var line = Console.ReadLine().Split(" ");
                var trainerName = line[0];
                if (trainerName == "Tournament")
                {
                    break;
                }
                var pokemonName = line[1];
                var element = line[2];
                var health = int.Parse(line[3]);
                Pokemon pokemon = new Pokemon(pokemonName,element,health);
                foreach (var trainer_item in trainers)
                {
                    if (trainer_item.Name == trainerName)
                    {
                        trainer_item.CollectionOfPokemon.Add(pokemon);
                        istrainersame = true;
                    }
                }
                if (istrainersame == false)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.CollectionOfPokemon.Add(pokemon);
                    trainers.Add(trainer);
                }
            }
            while (true)
            {
                var line = Console.ReadLine();
                if(line == "End")
                {
                    break;
                }
                
                foreach (var trainer in trainers)
                {
                    bool has_pokemon = false;
                    foreach (var pokemon in trainer.CollectionOfPokemon)
                    {
                        if (pokemon.Element == line)
                        {
                            trainer.NumberOfBadges++;
                            has_pokemon = true;
                            break;
                        }
                    }
                    if (has_pokemon == false)
                    {
                        if (trainer.CollectionOfPokemon.Count > 0)
                        {
                            foreach (var pokemon in trainer.CollectionOfPokemon)
                            {
                                pokemon.Health -= 10;
                                if (pokemon.Health <= 0)
                                {
                                    trainer.CollectionOfPokemon.Remove(pokemon);
                                    break;
                                }
                            }
                        }
                        
                    }
                }

            }
            var trainers_sort = trainers.OrderByDescending(x => x.NumberOfBadges);
            foreach (var trainer in trainers_sort)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemon.Count}");
            }
               
        }
    }
}
