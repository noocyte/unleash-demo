using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var rnd = new Random();
            var client = new HttpClient();
            var address = "http://localhost:5000/Sum?";
            do
            {
                try
                {
                    var num1 = rnd.Next(0, 10);
                    var num2 = rnd.Next(0, 10);
                    var finalAddress = $"{address}num1={num1}&num2={num2}";
                    var response = await client.GetAsync(finalAddress);
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Sum: {content}");


                    await Task.Delay(1500);
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed - waiting to retry");
                    await Task.Delay(2000);
                }
               
            } while (true);
        }
    }
}
