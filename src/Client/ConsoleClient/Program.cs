namespace Apep.ConsoleApp
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using static Apep.ConsoleApp.Models;

    class Program
    {
        static readonly string baseUrl = "http://localhost:57800";
        static HttpClient client = new HttpClient();

        static async Task<SecurityToken> Authenticate(Login login)
        {
            var response = await client.PostAsJsonAsync($"/user/authenticate", new { Username = login.UserName, Password = login.Password });
            var token = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SecurityToken>(token);
        }

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Logging in media service");

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var login = ReadLoginDetails();
                var accessToken = await Authenticate(login);
                if (accessToken.auth_token != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.auth_token);
                    Console.WriteLine("\n Login Successfull.");
                }
                else
                {
                    Console.WriteLine("\n Login Unsuccessfull.");
                }                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("App interrupted.");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("App closed.");
            }

            Console.ReadLine();
        }

        static Login ReadLoginDetails()
        {
            Console.WriteLine();
            Console.Write("Enter the user name: ");
            var username = Console.ReadLine();
            Console.Write("Enter the password: ");
            var password = Console.ReadLine();
            return new Login() { UserName = username, Password = password };
        }
        
    }
}
