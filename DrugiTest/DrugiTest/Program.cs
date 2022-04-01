using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BazaZaVajeEntities context = new BazaZaVajeEntities();
            //vsi dobavitelji
            var x1 = from a in context.DOBAVITELJ
                     select a;
            //foreach (var y in x1) {
            //    Console.WriteLine(y.D_IME + " " + y.D_KONTAKT);
            //}


            DateTime datum = DateTime.Parse("20.1.2004");
            var x2 = from a in context.PRODUKT
                     where a.P_DATUM < datum
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_MIN, Cena = a.P_CENA };
            //foreach (var y in x2) {
            //    Console.WriteLine(y.Opis + " " + y.Cena);
            //}
            DateTime danes = DateTime.Now;
            danes = danes.AddDays(365);
            var x3 = from a in context.PRODUKT
                     where a.P_DATUM < datum
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_MIN, Cena = a.P_CENA, Zapadlost=danes };
           
            //foreach (var y in x3)
            //{
            //    Console.WriteLine(y.Opis + " " + y.Zapadlost);
            //}

            var x4 = from a in context.DOBAVITELJ
                     where a.D_KONTAKT.StartsWith("Smith")
                     select a;

            //foreach (var y in x4)
            //{
            //    Console.WriteLine(y.D_KONTAKT);
            //}
            //
            var x5 = (from a in context.PRODUKT
                     select a.D_KODA).Distinct();


            //foreach (var y in x5)
            //{
            //    Console.WriteLine(y);
            //}

            var x6 = context.DOBAVITELJ.Where(a => !x5.Any(p => p == a.D_KODA));

            //foreach (var y in x6)
            //{
            //    Console.WriteLine(y.D_KODA);
            //}

            var x7 = context.KUPEC.Sum(e => e.KUP_STANJE);

            Console.WriteLine(x7);




            Console.ReadLine();

        }
    }
}
