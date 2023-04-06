using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Pokemons;

namespace Tamagotchi.Uteis
{
    public static class Menu
    {
        public static void MenuInicial()
        {
            Console.WriteLine("Bemmm vindooo ao centro Tamagotchi!!");
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Adotar um mascote");
            Console.WriteLine("2 - Ver seus Mascotes");
            Console.WriteLine("3 - Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Menu.MenuDeAdocao();
                    break;
                case 2:
                    Menu.MeusMascotes();
                    break;
                case 3:
                    Console.WriteLine("Tchauzinhuuu");
                    break;
            }
        }

        public static void MenuDeAdocao()
        {

            var baseUrl = "https://pokeapi.co/api/v2/pokemon/";
            Console.WriteLine("Adotando um mascotinhuuu");
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
                Console.WriteLine("1 - Escolher mascote");
                Console.WriteLine("2 - Próxima pagina");
                Console.WriteLine("3 - Página Anterior");
                Console.WriteLine("4 - Voltar para o menu");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Nome do mascote escolhido: ");
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
                            Console.WriteLine("Falha ao adicionar");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Adicionado com sucesso");
                            break;
                        }
                    case 2:
                        if (resposta.Next == null)
                        {
                            Console.WriteLine("Última Página");
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
                            Console.WriteLine("Primeira Página");
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
            Menu.MenuInicial();




        }

        public static void MeusMascotes()
        {
            var baseUrl = "https://pokeapi.co/api/v2/pokemon/";
            Console.WriteLine("Meus bixinhuuuusss");
            foreach (var pokemon in Usuario.listaDePokemons)
            {
                Console.WriteLine(pokemon.Name);

            }

            Console.WriteLine("1 - Ver informações do meu mascote");
            Console.WriteLine("2 - Voltar ao menu inicial");
            int opcao = int.Parse(Console.ReadLine());
            Pokemon mascoteEscolhido = new Pokemon();
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Qual mascote deseja ver as informações ?");
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
                    if(encontrado == false)
                    {
                        Console.WriteLine("Pokemon não encontrado!!");
                        Menu.MeusMascotes();
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
                            Console.WriteLine($"Habilidade: {ability.Name}");
                        }
                        Menu.MeusMascotes();
                        break;

                    }



                case 2:
                    Menu.MenuInicial();
                    break;

            }


        }
    }
}
