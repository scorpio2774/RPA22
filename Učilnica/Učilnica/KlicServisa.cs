using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Učilnica
{
    class KlicServisa
    {
        public static async Task PopulatePoglavjaAsync(ObservableCollection<Poglavja> poglavja) {
            string url = "https://ucilnice.scng.si/webservice/rest/server.php?wstoken=cdab3d1b4fa5daac1af768a4e5030dc4&wsfunction=core_course_get_contents&courseid=110&moodlewsrestformat=json";
            List<Poglavja> vsa = new List<Poglavja>();
            //klic
            using (var klient = new HttpClient()) {
                HttpResponseMessage sp = await klient.GetAsync(url);
                vsa = await sp.Content.ReadAsAsync<List<Poglavja>>();
            }
            foreach (var p in vsa) {
                poglavja.Add(p);
            }
        }
    }
}
