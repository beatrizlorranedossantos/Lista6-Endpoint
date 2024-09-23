using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumirApiGitHub
{
    public class UsuarioGitHub
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://api.github.com/user/1";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApp", "1.0"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    UsuarioGitHub usuario = JsonSerializer.Deserialize<UsuarioGitHub>(responseBody, options);

                    Console.WriteLine("Nome: " + usuario.Name);
                    Console.WriteLine("Empresa: " + usuario.Company);
                    Console.WriteLine("Localização: " + usuario.Location);
                    Console.WriteLine("Login: " + usuario.Login);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro na requisição: {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }
    }
}
