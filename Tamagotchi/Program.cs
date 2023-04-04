using RestSharp;

internal class Program
{
    private static void Main(string[] args)
    {

        var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        RestRequest request = new RestRequest("",Method.Get);
        var response = client.Execute(request);

        Console.WriteLine(response.Content);
        Console.ReadLine();


    }

}