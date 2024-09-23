using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://api.github.com/users/mojombo";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);

            Console.WriteLine("Nome: " + json["name"]);
            Console.WriteLine("Empresa: " + json["company"]);
            Console.WriteLine("Localização: " + json["location"]);
            Console.WriteLine("Login: " + json["login"]);
        }
    }
}
