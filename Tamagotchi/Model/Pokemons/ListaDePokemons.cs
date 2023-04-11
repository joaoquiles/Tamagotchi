using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace Tamagotchi.Pokemons
{
    public class ListaDePokemons
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Pokemon> Results { get; set; }

    }
}
