using SKL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKL.ViewModel
{
    class LigaViewModel
    {
        public EkipaViewModel EkipaJimmy { get; set; }
        public EkipaViewModel EkipaJanez { get; set; }
        public LigaViewModel()
        {
            Ekipa j = new Ekipa("Bomberji", DobiBomberje());
            EkipaJanez = new EkipaViewModel(j);
            Ekipa m = new Ekipa("Fantastic", DobiFantastice());
            EkipaJimmy = new EkipaViewModel(m);
        }

        private IEnumerable<Igralec> DobiFantastice()
        {
            List<Igralec> i = new List<Igralec>() { 
            new Igralec("Jimmy",true,42),
            new Igralec("Bonny",true,41),
            new Igralec("Clover",true,15),
            new Igralec("Duke",true,9),
            new Igralec("Dragan",true,22),
            new Igralec("Sokol",true,37),
            new Igralec("Jacket",false,19),
            new Igralec("Jiro",false,66)
            };
            return i;
        }

        private IEnumerable<Igralec> DobiBomberje()
        {
            List<Igralec> i = new List<Igralec>() {
            new Igralec("Dallas",true,4),
            new Igralec("Wolf",true,11),
            new Igralec("Chains",true,16),
            new Igralec("Huston",true,99),
            new Igralec("Hoxton",true,44),
            new Igralec("Sidney",true,35),
            new Igralec("Sangres",false,86),
            new Igralec("Rust",false,21)
            };
            return i;
        }
    }
}
