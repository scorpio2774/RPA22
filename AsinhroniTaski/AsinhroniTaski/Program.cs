using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsinhroniTaski
{
    class Coffee { }
    class Bacon { }
    class Egg { }
    class Toast { }
    class Juice { }
    class Program
    {
        static async Task Main(string[] args)
        {
            //1. sinhrono => končaj eno delo, nato začni novo
            //Coffee cup = KuhajKavo();
            //Console.WriteLine("Kfe je skuhano.");
            //Egg eggs = CvriJajca(2);
            //Console.WriteLine("Jajca so cvrta");
            //Bacon bacon = CvriSlanino(3);
            //Console.WriteLine("Slanina je pripravljena");
            //Toast toast = PeciKruh(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("Toasti so pripravljeni");
            //Juice juice = StisniSok();
            //Console.WriteLine("Sok je Pripravljen");
            //Console.WriteLine("Zajtrk je Pripravljen");

            //2. asinhrono => ob istem času
            Coffee cup = KuhajKavo();
            Console.WriteLine("Kfe je skuhano.");
            //Egg eggs = await CvriJajca(2);
            Task<Egg> eggs = CvriJajca(2);
            //Bacon bacon = await CvriSlanino(3);
            Task<Bacon> bacon = CvriSlanino(3);
            Toast toast = await PeciKruh(2);
            //Task<Toast> toast = PeciKruh(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toasti so pripravljeni");
            Juice juice = StisniSok();
            Console.WriteLine("Sok je Pripravljen");
            Egg egg = await eggs;
            Console.WriteLine("Jajca so cvrta");
            Bacon b = await bacon;
            Console.WriteLine("Slanina je pripravljena");
            Console.WriteLine("Zajtrk je Pripravljen");

            Console.ReadLine();
        }

        private static Juice StisniSok()
        {
            Console.WriteLine("Stiskanje soka iz pomaranc");
            Task.Delay(3000).Wait();
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Dodajanje marmelade na toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Dodajanje masla na toast");
        }

        private async static Task<Toast> PeciKruh(int v)
        {
            for (int k = 0; k < v; k++) {
                Console.WriteLine("Dodajanje toasta v toaster");
            }
            Console.WriteLine("Peka toasta");
            await Task.Delay(3000);
            Console.WriteLine("Odstrani toast  iz toasterja");
            return new Toast();
        }

        private async static Task<Bacon> CvriSlanino(int v)
        {
            Console.WriteLine("Dodajanje " + v+" kosov slanine v ponev");
            Console.WriteLine("Pecenje na eni strani");
            Task.Delay(3000).Wait();
            for (int k = 0; k < v; k++) {
                Console.WriteLine("Obracanje sanine");
            }
            await Task.Delay(3000);
            Console.WriteLine("Slanina n kroznik");
            return new Bacon();
        }

        private async static Task<Egg> CvriJajca(int v)
        {
            Console.WriteLine("Segrevanje ponve.......");
            await Task.Delay(3000);
            Console.WriteLine("Razbijanje " + v + " jajc");
            Console.WriteLine("Cvrtje jajc..........");
            await Task.Delay(3000);
            Console.WriteLine("Jajca n kroznik");
            return new Egg();
        }

        private static Coffee KuhajKavo()
        {
            Console.WriteLine("Kuhanje kfeta");
            Task.Delay(3000).Wait();
            return new Coffee();
        }
    }
}
