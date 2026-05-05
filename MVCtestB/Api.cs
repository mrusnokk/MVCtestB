using MVCtestB.Models;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MVCtestB
{
    public class Api
    {
        private string url = "https://csharp.janjanousek.cz/api/cnb/?date=2025-05-12";
        public async Task<Kurzy> getJson() {
            using (HttpClient client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("x-api-key","VSB");

                HttpResponseMessage res = await client.GetAsync(url);
                if (res.StatusCode == System.Net.HttpStatusCode.TooManyRequests) {
                    int x = (int)res.Headers.RetryAfter.Delta.Value.TotalSeconds; 
                    Console.WriteLine($"TooManyRequests waiting {x} sec...");
                    await Task.Delay(x*1000);
                }
                res = await client.GetAsync(url);
                string json = await res.Content.ReadAsStringAsync();
                Kurzy tmp = JsonSerializer.Deserialize<Kurzy>(json);

                Console.WriteLine("Nacteno");
                return tmp;
            } 
        }
    }
}
