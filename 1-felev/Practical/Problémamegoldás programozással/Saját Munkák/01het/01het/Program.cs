using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01het
{
    internal class Program
    {
        readonly DateTime Letrehozva; 

        public Program()
        {
            Letrehozva = DateTime.Now;
        }

        class Pelda
        {
            int mezo; // automatikusan 0 lesz
        }

        void Metodus()
        {
            int x = 0;
            Console.WriteLine(x);
        }
        static void Main(string[] args)
        {
            // konzolra írás
            Console.WriteLine("Helló világ!"); // Ezzel a paranccsal írtuk ki a konzolra a "Helló világ!" szöveget.

            // változók, típusok
            int number = 5;
            double pi = 3.14;
            bool isTrue = true;
            bool isFalse = false;
            char character = 'A';
            string text = "Szia"; // string kisbetűvel = alias a System.String-re
            var auto = 10; // típuskövetkeztetés, ugyanaz mint a Java var-ja
            const double PI = 3.14159; // Java final helyett
            byte b = 255; // 8 bit, előjel nélküli (Java byte-ja előjeles, ez itt más)
            short s = 32000; // 16 bit
            int i = 42; // 32 bit
            long l = 123456789L; // 64 bit
            float f = 3.14f; // 32 bit, lebegőpontos
            double d = 3.14159; // 64 bit, lebegőpontos
            decimal m = 19.99m; // 128 bit, pénzügyi számokhoz (ez Java-ban nincs is ilyen egyszerűen)
            var szam = 5; // int-nek következteti ki
            var szoveg = "hello"; // string
            var lista = new List<int>();
            int? kor = null; // ? teszi nullable-lé az érték típust
            if (kor.HasValue)
            {
                Console.WriteLine(kor.Value);
            }
            int biztos = kor ?? 0; // null-coalescing operátor: ha null, akkor 0
            double n = 9.7;
            int o = (int)n; // explicit, csonkol (nem kerekít!): 9
            int szam2 = 100;
            double d2 = szam2; // implicit, nem kell cast (int -> double biztonságos)
            string szoveg2 = "123";
            int parszolt = int.Parse(szoveg2); // kivételt dob, ha hibás a string
            int.TryParse(szoveg2, out int eredmeny); // biztonságosabb, bool-t ad vissza

            Console.WriteLine($"A program létrehozásának ideje: {new Program().Letrehozva}");
            Console.WriteLine(number);
            Console.WriteLine(pi);
            Console.WriteLine(isTrue);
            Console.WriteLine(isFalse);
            Console.WriteLine(character);
            Console.WriteLine(text);
            Console.WriteLine(auto);
            Console.WriteLine(PI);
            Console.WriteLine(b);
            Console.WriteLine(s);
            Console.WriteLine(i);
            Console.WriteLine(l);
            Console.WriteLine(f);
            Console.WriteLine(d);
            Console.WriteLine(m);
            Console.WriteLine(szam);
            Console.WriteLine(szoveg);
            Console.WriteLine(lista);
            Console.WriteLine(kor);
            Console.WriteLine(biztos);
            Console.WriteLine(n);
            Console.WriteLine(o);
            Console.WriteLine(szam2);
            Console.WriteLine(d2);
            Console.WriteLine(szoveg2);
            Console.WriteLine(parszolt);
            Console.WriteLine(eredmeny);
        }
    }
}
