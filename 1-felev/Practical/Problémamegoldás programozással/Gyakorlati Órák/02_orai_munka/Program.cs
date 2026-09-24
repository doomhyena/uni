using System;
using System.Text;
using System.Threading;

namespace _02_orai_munka
{
    internal class Program
    {
        /*
         
         1.Készítsünk programot, amely elkér a felhasználótól egy N pozitív egész számot, majd kiírja az egész számokat
         0 és N között. Módosítsuk úgy a programot, hogy az csak a páros számokat írja ki.
         
         */
        public static void Task1()
        {
            Console.Write("N = ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N < 0)
            {
                Console.WriteLine("Érvénytelen N");
                return;
            }
            Console.WriteLine("Az összes szám:");
            for (int i = 0; i <= N; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Páros számok:");
            for (int i = 0; i <= N; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        /*
         
         2.Tároljuk egy változóban a felhasználó jelszavát. Addig kérjük el tőle a jelszót a parancssorról, amíg az nem
         egyezik az eltárolttal. Módosítsuk úgy a programot, hogy a felhasználó három sikertelen próbálkozás után kapjon
         hibaüzenetet.
         
         */

        public static void Task2()
        {
            const string stored = "pablo";
            int attempts = 0;
            while (attempts < 3)
            {
                Console.Write("Jelszó: ");
                string input = Console.ReadLine();
                if (input == stored)
                {
                    Console.WriteLine("Hozzáférés engedélyezve");
                    return;
                }
                attempts++;
                Console.WriteLine("Hibás jelszó ({0}/3)", attempts);
            }
            Console.WriteLine("Túl sok sikertelen próbálkozás");
        }

        /*
         
         3. Írjunk programot, amely addig generál véletlen számokat 1 és 1000 között, amíg az meg nem egyezik a
         program kezdetén a felhasználó által megadott számmal. Számoljuk meg, hány próbálkozás kellett a találathoz.
         
         */
        public static void Task3()
        {
            Console.Write("Válassz célértéket (1-1000): ");
            if (!int.TryParse(Console.ReadLine(), out int target) || target < 1 || target > 1000)
            {
                Console.WriteLine("Érvénytelen cél");
                return;
            }
            var rng = new Random();
            int tries = 0;
            int val;
            do
            {
                val = rng.Next(1, 1001);
                tries++;
            } while (val != target);
            Console.WriteLine($"Megtalálva {target} {tries} próbálkozás után");
        }

        /*
         
         4. Társasjátékoknál gyakori, hogy az kezd, aki először hatos dob. Készítsünk egy alkalmazást, amely eldönti,
         hogy N játékos közül ki kezdjen. Minden játékosnál az Enter leütésére dobjunk egy véletlen számot 1 és 6 között,
         majd ha az nem hatos, ugorjunk a következő játékosra. Ha körbeértünk, a folyamat induljon újra, egészen addig,
         amíg valaki hatost nem dob.
         
         */

        public static void Task4()
        {
            Console.Write("Játékosok száma: ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N < 1) return;
            var rng = new Random();
            int current = 0;
            while (true)
            {
                Console.WriteLine($"Játékos {current + 1}, nyomj Entert a dobáshoz");
                Console.ReadLine();
                int roll = rng.Next(1, 7);
                Console.WriteLine($"Dobás: {roll}");
                if (roll == 6)
                {
                    Console.WriteLine($"A(z) {current + 1}. játékos kezd (6-ost dobott)");
                    
                }
                current = (current + 1) % N;
            }
        }

        /*
         
         5. Írjunk programot, amelynek kezdetén adott egy pozitív egész szám, a „gondolt szám”. A felhasználónak ki
         kell találnia, hogy mi a gondolt szám. Ehhez a felhasználó megadhat számokat, melyekről a program megmondja,
         hogy a gondolt számnál nagyobbak vagy kisebbek-e. A program akkor ér véget, ha a felhasználó kitalálta a gondolt
         számot. A program jelenítse meg a felhasználó próbálkozásainak számát is.
         
         */

        public static void Task5()
        {
            Console.Write("Adj meg titkos számot (pozitív): ");
            if (!int.TryParse(Console.ReadLine(), out int secret) || secret < 0) return;
            int tries = 0;
            while (true)
            {
                Console.Write("Tipp: ");
                if (!int.TryParse(Console.ReadLine(), out int g)) continue;
                tries++;
                if (g == secret) { Console.WriteLine($"Correct in {tries} tries");  }
                Console.WriteLine(g < secret ? "Nagyobb" : "Kisebb");
            }
        }

        /*
         
        6. Kérjünk el a felhasználótól egy N pozitív egész számot, majd írjuk ki az alábbiakat:
            * N páros vagy páratlan
            * N valódi pozitív osztóinak száma (1-et és N-et nem kell beleszámolnunk)
            * N prímszám vagy összetett szám
         
         */

        public static void Task6()
        {
            Console.Write("N = ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0) return;
            Console.WriteLine(N % 2 == 0 ? "Páros" : "Páratlan");
            int divisors = 0;
            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    divisors += (i * i == N) ? 1 : 2;
                }
            }
            Console.WriteLine($"Megfelelő pozitív osztók (1 és N nélkül): {divisors}");
            Console.WriteLine((divisors == 0 && N > 1) ? "Prím" : "Összetett");
        }

        /*
         
        7. Kérjünk el egy pozitív egész számot, majd írjuk ki a faktoriálisát.
         
         */

        public static void Task7()
        {
            Console.Write("N = ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N < 0) return;
            try
            {
                checked
                {
                    long result = 1;
                    for (int i = 2; i <= N; i++) result *= i;
                    Console.WriteLine($"{N}! = {result}");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Eredmény túl nagy Int64-hez");
            }
        }

        /*
         
        8. Készítsük programot, amely kiírja a képernyőre a szorzótáblát az alábbihoz hasonlóan.
         
         */

        public static void Task8()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                    Console.Write($"{i * j,4}");
                Console.WriteLine();
            }
        }

        /*
         
        9. Készítsünk időzítő alkalmazást, amely elkér egy másodpercben megadott időtartamot, majd kiírja azt a
        képernyőre perc:másodperc formátumban, és visszaszámlálást indít. Minden eltelt másodperc után törölje a
        képernyőt, és írja ki a még hátralévő időt.
        A visszaszámlálást végét jelezze a képernyő pirosra váltásával és
        sípolással.
         
         */

        public static void Task9()
        {
            Console.Write("Másodpercek = ");
            if (!int.TryParse(Console.ReadLine(), out int seconds) || seconds < 0) return;
            for (int s = seconds; s >= 0; s--)
            {
                int m = s / 60;
                int r = s % 60;
                Console.Clear();
                Console.WriteLine($"{m}:{r:00}");
                if (s > 0) Thread.Sleep(1000);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Beep();
            Console.WriteLine("Lejárt az idő!");
            Console.ResetColor();
        }

        /*
         
        10. Készítsünk tízes számrendszerből kettes számrendszerbe átváltó alkalmazást. A bemenet legyen egy 32 bites
        előjel nélküli egész (uint), kimenetként pedig jelenítsük meg az érték kettes számrendszerbeli alakját 8 bites
        blokkokban, big endian formátumban.
         
         */

        public static void Task10()
        {
            Console.Write("Adj meg egy unsigned int-et: ");
            if (!uint.TryParse(Console.ReadLine(), out uint v)) return;
            var sb = new StringBuilder();
            for (int byteIndex = 3; byteIndex >= 0; byteIndex--)
            {
                byte b = (byte)((v >> (byteIndex * 8)) & 0xFF);
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                if (byteIndex > 0) sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());
        }

        /*
         
        11. Készítsünk egyszerű félkarú rabló játékot. A játék elején a játékos 100 kredittel rendelkezik, a tét alapesetben
        1 kredit. A Spacebar billentyű lenyomásakor a játék három véletlen számjegyet pörget. Két egyforma szám esetén
        a tét 10-szeresét, három egyforma esetén a tét 50-szeresét nyeri a felhasználó. Pörgetés előtt a tétet a Fel és Le
        kurzorbillentyűkkel lehet módosítani. A játék véget ér Escape nyomáskor, vagy ha a játékosnak elfogy a kreditje.
         
         */

        public static void Task11()
        {
            int credits = 100;
            int bet = 1;
            var rng = new Random();
            ConsoleKey key;
            do
            {
                Console.WriteLine($"Zsetonok: {credits} Tét: {bet}");
                var k = Console.ReadKey(true);
                key = k.Key;
                if (key == ConsoleKey.UpArrow) bet++;
                else if (key == ConsoleKey.DownArrow) bet = Math.Max(1, bet - 1);
                else if (key == ConsoleKey.Spacebar)
                {
                    if (credits < bet) { Console.WriteLine("Nincs elég zseton"); continue; }
                    credits -= bet;
                    int a = rng.Next(0, 10);
                    int b = rng.Next(0, 10);
                    int c = rng.Next(0, 10);
                    Console.WriteLine($"{a} {b} {c}");
                    if (a == b && b == c) credits += bet * 50;
                    else if (a == b || b == c || a == c) credits += bet * 10;
                }
            } while (key != ConsoleKey.Escape && credits > 0);
            Console.WriteLine("Vége a játéknak");
        }

        /*
         
        12. Egészítsük ki az előző félkarú rabló játékot ASCII art grafikai elemekkel: a számok helyett karakterekből
        kialakított színes figurák (pl. pikk, kőr, treff, káró) jelenjenek meg pörgetéskor.
         
         */

        public static void Task12()
        {
            string[] symbols = { "♠", "♥", "♣", "♦" };
            int credits = 100, bet = 1;
            var rng = new Random();
            ConsoleKey key;
            do
            {
                Console.WriteLine($"Pénz: {credits} Tét: {bet}");
                var k = Console.ReadKey(true);
                key = k.Key;
                if (key == ConsoleKey.UpArrow) bet++;
                else if (key == ConsoleKey.DownArrow) bet = Math.Max(1, bet - 1);
                else if (key == ConsoleKey.Spacebar)
                {
                    if (credits < bet) { Console.WriteLine("Nincs elég pénzed!"); continue; }
                    credits -= bet;
                    int i1 = rng.Next(symbols.Length);
                    int i2 = rng.Next(symbols.Length);
                    int i3 = rng.Next(symbols.Length);
                    Console.WriteLine($"{symbols[i1]} {symbols[i2]} {symbols[i3]}");
                    if (i1 == i2 && i2 == i3) credits += bet * 50;
                    else if (i1 == i2 || i2 == i3 || i1 == i3) credits += bet * 10;
                }
            } while (key != ConsoleKey.Escape && credits > 0);
            Console.WriteLine("Game over");
        }

        /*
         
        13. Egy új kriptovaluta árfolyamának alakulását szimuláljuk. Jelölje az aktuális árfolyamot Pt (valós szám). A
        kriptovaluta árfolyamát a következő órában
            
            P^t+1 = r × P^t + εt

        képlettel modellezzük, ahol r egy adott paraméter, ε^t pedig egy véletlen valós szám a [−α, α] intervallumból. Írjuk
        ki a képernyőre az árfolyam alakulását különböző r és α értékekkel a felhasználó által megadott számú órára
         
         */

        public static void Task13()
        {
            Console.Write("Kezdőárfolyam: ");
            if (!double.TryParse(Console.ReadLine(), out double P)) return;
            Console.Write("r (többjátékos): "); if (!double.TryParse(Console.ReadLine(), out double r)) return;
            Console.Write("α (határ): "); if (!double.TryParse(Console.ReadLine(), out double alpha)) return;
            Console.Write("Óra: "); if (!int.TryParse(Console.ReadLine(), out int hours) || hours < 1) return;
            var rng = new Random();
            double pt = P;
            for (int t = 0; t < hours; t++)
            {
                double eps = (rng.NextDouble() * 2.0 - 1.0) * alpha;
                pt = r * pt + eps;
                Console.WriteLine($"t={t + 1}: {pt:F4}");
            }
        }

        static void Main(string[] args)
        {
           
            Task1(); 
            Task2(); 
            Task3(); 
            Task4(); 
            Task5(); 
            Task6(); 
            Task7(); 
            Task8(); 
            Task9(); 
            Task10(); 
            Task11(); 
            Task12(); 
            Task13();
            Console.ReadKey();
        }
    }
}
