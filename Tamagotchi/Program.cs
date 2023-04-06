using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using Tamagotchi.Pokemons;
using static System.Net.WebRequestMethods;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ListaDePokemons> todos = new List<ListaDePokemons>();

        var baseUrl = "https://pokeapi.co/api/v2/pokemon/";
        while (baseUrl != null)
        {
            RestClient client = new RestClient(baseUrl);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            ListaDePokemons resposta = JsonConvert.DeserializeObject<ListaDePokemons>(response.Content);
            foreach (var pokemon in resposta.Results)
            {
                Console.WriteLine(pokemon.Name);
            }
            todos.Add(resposta);
            baseUrl = resposta.Next;
        }


    }

    

    

}