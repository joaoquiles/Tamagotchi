using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Model.Usuario;
using Tamagotchi.Pokemons;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    public static class Menu
    {
        public static void MenuInicial()
        {
            Mensagens.BoasVindas();
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    MenuDeAdocao();
                    break;
                case 2:
                    MeusMascotes();
                    break;
                case 3:
                    Mensagens.Sair();
                    break;
            }
        }

        public static void MenuDeAdocao()
        {
            Mensagens.BoasVindasAdocao();
            var baseUrl = "https://pokeapi.co/api/v2/pokemon/";
            bool fechar = true;
            while (fechar)
            {
                RestClient client = new RestClient(baseUrl);
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);

                ListaDePokemons resposta = JsonConvert.DeserializeObject<ListaDePokemons>(response.Content);
                int colWidth = 20;
                int colCount = 4;

                for (int i = 0; i < resposta.Results.Count; i += colCount)
                {
                    for (int j = 0; j < colCount && i + j < resposta.Results.Count; j++)
                    {
                        string pokemonName = resposta.Results[i + j].Name;
                        Console.Write(pokemonName.PadRight(colWidth));
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
                Mensagens.OpcoesDeAdocao();
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Mensagens.EscolherMascote();
                        string mascoteEscolhido = Console.ReadLine();
                        bool adicionado = false;
                        foreach (var pokemon in resposta.Results)
                        {
                            if (pokemon.Name.Equals(mascoteEscolhido))
                            {
                                Usuario.listaDePokemons.Add(pokemon);
                                adicionado = true;
                                break;
                            }
                        }
                        if (adicionado == false)
                        {
                            Mensagens.FalhaAoAdicionar();
                            break;
                        }
                        else
                        {
                            Mensagens.AdicionadoComSucesso();
                            break;
                        }
                    case 2:
                        if (resposta.Next == null)
                        {
                            Mensagens.UltimaPagina();
                            break;
                        }
                        else
                        {
                            baseUrl = resposta.Next;
                            break;
                        }

                    case 3:
                        if (resposta.Previous == null)
                        {
                            Mensagens.PrimeiraPagina();
                            break;
                        }
                        else
                        {
                            baseUrl = resposta.Previous;
                            break;
                        }
                    case 4:
                        fechar = false;
                        break;
                }
            }
            MenuInicial();




        }

        public static void MeusMascotes()
        {
            Mensagens.BoasVindasMeusMascotes();
            var baseUrl = "https://pokeapi.co/api/v2/pokemon/";
            foreach (var pokemon in Usuario.listaDePokemons)
            {
                Console.WriteLine(pokemon.Name);

            }

            Mensagens.OpcoesMeusMascotes();
            int opcao = int.Parse(Console.ReadLine());
            Pokemon mascoteEscolhido = new Pokemon();
            switch (opcao)
            {
                case 1:
                    Mensagens.EscolherMascote();
                    string mascote = Console.ReadLine();
                    bool encontrado = false;
                    foreach (var pokemon in Usuario.listaDePokemons)
                    {
                        if (mascote.Equals(pokemon.Name))
                        {
                            mascoteEscolhido = pokemon;
                            baseUrl = pokemon.Url;
                            encontrado = true;
                            break;

                        }
                    }
                    if (encontrado == false)
                    {
                        Mensagens.MascoteNaoEncontrado();
                        MeusMascotes();
                        break;
                    }
                    else
                    {
                        RestClient client = new RestClient(baseUrl);
                        var request = new RestRequest("", Method.Get);
                        var response = client.Execute(request);

                        var informacoesPokemon = JsonConvert.DeserializeObject<InfoPokemon>(response.Content);

                        Console.WriteLine($"Nome: {mascoteEscolhido.Name}");
                        Console.WriteLine($"Altura: {informacoesPokemon.Height}");
                        Console.WriteLine($"Peso: {informacoesPokemon.Weight}");
                        foreach (var ability in informacoesPokemon.Abilities)
                        {
                            Console.WriteLine($"Habilidade: {ability.Ability.name}");
                        }
                        MeusMascotes();
                        break;

                    }



                case 2:
                    MenuInicial();
                    break;

            }


        }
    }
}
