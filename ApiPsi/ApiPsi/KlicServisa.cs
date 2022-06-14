using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiPsi
{
    class KlicServisa
    {
        public static async Task PopulatePsi(ObservableCollection<Slika> poti)
        {
            string url = "https://dog.ceo/api/breed/shiba/images";
            Odgovor p = new Odgovor();
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                p = await sp.Content.ReadAsAsync<Odgovor>();
            }
            foreach(var x in p.message)
            {
                Slika s = new Slika();
                s.Pot = x;
                poti.Add(s);
            }
        }
    }
}
