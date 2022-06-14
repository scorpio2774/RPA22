using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace UWPseminarska
{
    class KlicServisa
    {
        public static async Task PopulateCats(ObservableCollection<Muce> muce)
        {
            string url = "https://api.thecatapi.com/v1/breeds";
            List<Muce> vseMuce = new List<Muce>();
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                vseMuce= await sp.Content.ReadAsStringAsync()
            }
        }
    }
}
