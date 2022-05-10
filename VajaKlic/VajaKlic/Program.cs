using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VajaKlic
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }

        static async Task RunAsync() {
            using (var klient = new HttpClient()) {
                klient.BaseAddress = new Uri("http://localhost:63221/");
                klient.DefaultRequestHeaders.Accept.Clear();
                klient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage odg = await klient.GetAsync("api/Mentor");
                if (odg.IsSuccessStatusCode) {
                    List<Mentor> seznam = new List<Mentor>();
                    seznam = await odg.Content.ReadAsAsync<List<Mentor>>();
                    foreach (var m in seznam)
                    {
                        Console.WriteLine("Ime: " + m.MenIme + " Priimek: " + m.MenPriimek);
                    }

                }
            }
        }
    }
}
