namespace _03_orai_munka
{
    internal class Program
    {

        static void feladat(int n)
        {
            Console.WriteLine($"-------------------- {n}. feladat --------------------");
        }
        /*

        1. Készítsünk programot, amely ciklusok használatával felsorolja a francia kártya lapjait egy tömbbe.
            A lehetséges színek: Kőr, Káró, Treff és Pikk. A lapoknak 13 féle magassága lehet: számok 2-től 10-ig, majd
            Jumbó, Dáma, Király és Ász

         */
        static void feladat1()
        {
            string[] szinek = { "Kőr", "Káró", "Treff", "Pikk" };
            string[] lapok = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };
            for (int i = 0; i < szinek.Length; i++)
            {
                for (int j = 0; j < lapok.Length; j++)
                {
                    Console.WriteLine($"{szinek[i]} {lapok[j]}");
                }
            }
        }

        /*
         
        2. Keverjük meg a korábban készített kártyapaklit a Fisher–Yates keveréssel. A módszer lényege, hogy a tömb
            elemein végighaladva mindegyikhez kiválaszt egy véletlen helyen lévő elemet a korábban még nem vizsgáltak közül,
            amelyeket utána megcserél. Az algoritmus pszeudokóddal az alábbi formában adható meg (1-alapú indexelést
            használva).
         
         */

        static void feladat2()
        {
            string[] szinek = { "Kőr", "Káró", "Treff", "Pikk" };
            string[] lapok = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };
            string[] pakli = new string[szinek.Length * lapok.Length];
            int index = 0;
            for (int i = 0; i < szinek.Length; i++)
            {
                for (int j = 0; j < lapok.Length; j++)
                {
                    pakli[index++] = $"{szinek[i]} {lapok[j]}";
                }
            }
            Random rnd = new Random();
            for (int i = pakli.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                string temp = pakli[i];
                pakli[i] = pakli[j];
                pakli[j] = temp;
            }
            foreach (var lap in pakli)
            {
                Console.WriteLine(lap);
            }
        }

        /*
         
         3. Kérjünk el a felhasználótól előre megadott darabszámú szót, amelyeket tároljunk el egy tömbben. Ezután
            kérjünk el a felhasználótól egy további szót, és válaszoljuk meg az alábbiakat.
            • Benne van-e a gyűjteményben a megadott szó?
            • Ha benne van, hol található először?
         
         */

        static void feladat3()
        {
            Console.Write("Hány szót szeretnél megadni? ");
            int n = int.Parse(Console.ReadLine());
            string[] szavak = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Add meg a(z) {i + 1}. szót: ");
                szavak[i] = Console.ReadLine();
            }
            Console.Write("Add meg a keresett szót: ");
            string keresettSzo = Console.ReadLine();
            bool benneVan = false;
            int elsoIndex = -1;
            for (int i = 0; i < szavak.Length; i++)
            {
                if (szavak[i] == keresettSzo)
                {
                    benneVan = true;
                    elsoIndex = i;
                    break;
                }
            }
            if (benneVan)
            {
                Console.WriteLine($"A szó benne van a gyűjteményben, először a(z) {elsoIndex + 1}. helyen található.");
            }
            else
            {
                Console.WriteLine("A szó nincs benne a gyűjteményben.");
            }
        }

        /*
         
        4. Módosítsuk az előző feladat megoldását úgy, hogy a felhasználótól bekért szavakat egy listában tároljuk el,
            és a bekérést a STOP kulcsszó megadásakor fejezzük be. Ha szükséges, módosítsuk a két előbbi lekérdezést is.
            Milyen hasonlóságokat és különbségeket tapasztalunk a tömbök és listák használatában?

         */

        static void feladat4()
        {
            List<string> szavak = new List<string>();
            while (true)
            {
                Console.Write("Add meg a szót (vagy írd be, hogy STOP a befejezéshez): ");
                string szo = Console.ReadLine();
                if (szo.ToUpper() == "STOP")
                {
                    break;
                }
                szavak.Add(szo);
            }
            Console.Write("Add meg a keresett szót: ");
            string keresettSzo = Console.ReadLine();
            bool benneVan = false;
            int elsoIndex = -1;
            for (int i = 0; i < szavak.Count; i++)
            {
                if (szavak[i] == keresettSzo)
                {
                    benneVan = true;
                    elsoIndex = i;
                    break;
                }
            }
            if (benneVan)
            {
                Console.WriteLine($"A szó benne van a gyűjteményben, először a(z) {elsoIndex + 1}. helyen található.");
            }
            else
            {
                Console.WriteLine("A szó nincs benne a gyűjteményben.");
            }
        }

        /*
         
         5. Felmérést végzünk barátaink programozói ismereteiről. Kérjük el az adott személy nevét (string), életkorát
            (int) és hogy rendelkezik-e programozói tapasztalattal (bool). A neveket, életkorokat és tapasztalatokat tároljuk
            három külön listában, amelyeket az kapcsol össze, hogy egy adott indexen egy konkrét személy adatait találjuk.
            A bekérést egy üres név megadásáig folytassuk. Ezt követően határozzuk meg az alábbiakat.
                • Mi az átlagéletkor a teljes adathalmazban? (Használjuk a foreach utasítást a bejáráshoz.)
                • Mi az átlagéletkor a programozói tapasztalat nélküli személyek között?
                • Hány éves a legidősebb, programozó tapasztalattal rendelkező személy és mi a neve?
         
         */

        static void feladat5()
        {
            List<string> nevek = new List<string>();
            List<int> eletkorok = new List<int>();
            List<bool> tapasztalatok = new List<bool>();

            while (true)
            {
                Console.Write("Add meg a nevet (vagy üresen a befejezéshez): ");
                string nev = Console.ReadLine();
                if (string.IsNullOrEmpty(nev))
                {
                    break;
                }
                Console.Write("Add meg az életkort: ");
                int eletkor = int.Parse(Console.ReadLine());
                Console.Write("Rendelkezik programozói tapasztalattal? (Igen/Nem): ");
                bool tapasztalat = Console.ReadLine().ToLower() == "igen";

                nevek.Add(nev);
                eletkorok.Add(eletkor);
                tapasztalatok.Add(tapasztalat);
            }

            double atlagEletkor = 0;
            int osszEletkor = 0;
            int szam = 0;
            foreach (int eletkor in eletkorok)
            {
                osszEletkor += eletkor;
                szam++;
            }
            if (szam > 0)
            {
                atlagEletkor = (double)osszEletkor / szam;
            }
            Console.WriteLine($"Az átlagéletkor a teljes adathalmazban: {atlagEletkor:F2}");

            double atlagEletkorNelkul = 0;
            int osszEletkorNelkul = 0;
            int szamNelkul = 0;
            for (int i = 0; i < nevek.Count; i++)
            {
                if (!tapasztalatok[i])
                {
                    osszEletkorNelkul += eletkorok[i];
                    szamNelkul++;
                }
            }
            if (szamNelkul > 0)
            {
                atlagEletkorNelkul = (double)osszEletkorNelkul / szamNelkul;
            }
            Console.WriteLine($"Az átlagéletkor a programozói tapasztalat nélküli személyek között: {atlagEletkorNelkul:F2}");

            int legidosebbIndex = -1;
            int legidosebbEletkor = -1;
            for (int i = 0; i < nevek.Count; i++)
            {
                if (tapasztalatok[i] && eletkorok[i] > legidosebbEletkor)
                {
                    legidosebbEletkor = eletkorok[i];
                    legidosebbIndex = i;
                }
            }
            if (legidosebbIndex != -1)
            {
                Console.WriteLine($"A legidősebb, programozói tapasztalattal rendelkező személy: {nevek[legidosebbIndex]}, {legidosebbEletkor} éves.");

            }
            else
            {
                Console.WriteLine("Nincs programozói tapasztalattal rendelkező személy az adathalmazban.");
            }
        }


        /*
         
         6. Hozzunk létre egy N × M-es kétdimenziós tömböt (1 < N, M < 10), amit töltsünk fel véletlenszerűen
            0 és 9 közötti értékekkel. Jelenítsük meg a képernyőn ennek a mátrixnak az elemeit.
            Állítsuk elő a mátrix transzponáltját1, vagyis tükrözzük azt a főátlójára.
         
         */

        static void feladat6()
        {
            Random rnd = new Random();
            int N = rnd.Next(2, 10);
            int M = rnd.Next(2, 10);
            int[,] matrix = new int[N, M];
            Console.WriteLine($"Eredeti mátrix ({N}x{M}):");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nTranszponált mátrix ({M}x{N}):");
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /*
         
         7. Egy horgászverseny fogási adatait egy F táblázatban (kétdimenziós tömbben) tároljuk. F(i, j) azt jelenti,
            hogy az i-edik horgász a j-edik halfajtából hány darabot fogott.
                • Generáljuk le véletlenszerűen a táblázat adatait.
                • Jelenítsük meg formázottan a fogási adatokat a képernyőn.
                • Adjuk meg, hogy a horgászok mennyit fogtak az egyes halfajtákból.
                • Melyik horgász fogta a legtöbb halat összesen?
                • Volt-e olyan horgász, aki egyetlen halat sem fogott?
         
         */

        static void feladat7()
        {
            Random rnd = new Random();
            int horgaszokSzama = rnd.Next(2, 10);
            int halfajtakSzama = rnd.Next(2, 10);
            int[,] F = new int[horgaszokSzama, halfajtakSzama];
            for (int i = 0; i < horgaszokSzama; i++)
            {
                for (int j = 0; j < halfajtakSzama; j++)
                {
                    F[i, j] = rnd.Next(0, 11); 
                }
            }

            Console.WriteLine("Fogási adatok:");
            for (int i = 0; i < horgaszokSzama; i++)
            {
                Console.Write($"Horgász {i + 1}: ");
                for (int j = 0; j < halfajtakSzama; j++)
                {
                    Console.Write(F[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nÖsszes fogás halfajtánként:");
            for (int j = 0; j < halfajtakSzama; j++)
            {
                int osszesFogas = 0;
                for (int i = 0; i < horgaszokSzama; i++)
                {
                    osszesFogas += F[i, j];
                }
                Console.WriteLine($"Halfajta {j + 1}: {osszesFogas} darab");
            }

            int legtobbHalatFogottIndex = -1;
            int legtobbHalatFogottOsszeg = -1;
            for (int i = 0; i < horgaszokSzama; i++)
            {
                int osszeg = 0;
                for (int j = 0; j < halfajtakSzama; j++)
                {
                    osszeg += F[i, j];
                }
                if (osszeg > legtobbHalatFogottOsszeg)
                {
                    legtobbHalatFogottOsszeg = osszeg;
                    legtobbHalatFogottIndex = i;
                }
            }
            if (legtobbHalatFogottIndex != -1)
            {
                Console.WriteLine($"\nA legtöbb halat fogó horgász: {legtobbHalatFogottIndex + 1} (összesen: {legtobbHalatFogottOsszeg} darab)");
            }
            else
            {
                Console.WriteLine("\nNem volt olyan horgász, aki halat fogott.");
            }
        }

        /*
         
         8. Kérjünk el a felhasználótól egy N pozitív egész értéket, és adjuk hozzá egy listához első elemként. Vegyük
            a lista utoljára hozzáadott elemét, legyen ez K. Ha K páros, adjuk hozzá a listához K felét, ha páratlan, akkor
            3K + 1-et. Addig ismételjük az előbbieket, amíg 1-et nem kapunk eredményül2.
            Kövessük nyomon a kiszámított érték és a lista állapotának változását hibakereső (debug) módban. Próbáljuk
            meg hibakeresés közben módosítani az aktuálisan kiszámított értéket.
         
         */

        static void feladat8()
        {
            Console.Write("Adj meg egy pozitív egész értéket: ");
            int N = int.Parse(Console.ReadLine());
            List<int> lista = new List<int> { N };
            while (N != 1)
            {
                if (N % 2 == 0)
                {
                    N /= 2;
                }
                else
                {
                    N = 3 * N + 1;
                }
                lista.Add(N);
            }
            Console.WriteLine("A lista állapota:");
            foreach (int elem in lista)
            {
                Console.Write(elem + " ");
            }
        }

        /*
         
         9. Az alábbi algoritmussal szeretnénk az x tömb elemeit fordított sorrendben megkapni. Használjuk a hibakereső
            üzemmódot a hibák felderítésére és javítására.
                int[] x = { 1, 2, 3, 4, 5, 6, 7, 8};
                for (int i = 0; i < x.Length; i++)
                {
                    int tmp = x[i];
                    x[i] = x[x.Length - i - 1];
                    x[x.Length - i] = tmp;
                }
         
         */

        static void feladat9()
        {
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 0; i < x.Length / 2; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                x[x.Length - i - 1] = tmp;
            }
            Console.WriteLine("A tömb elemei fordított sorrendben:");
            foreach (int elem in x)
            {
                Console.Write(elem + " ");
            }
        }

        /*
         
         10. Töltsünk fel egy egydimenziós tömböt megadott számú véletlen értékkel, majd valósítsuk meg az alábbi
            műveleteket, majd oldjuk meg a feladatot listával is.
                • Válogassuk ki a gyűjtemény minden második elemét egy új gyűjteménybe.
                • Fordítsuk meg a gyűjtemény elemeinek sorrendjét.
                • Rendezzük a lehető legkisebb négyzetes mátrixba a gyűjtemény elemeit (az esetlegesen üresen maradó értékek
                helyére nulla kerüljön).
         
         */

        static void feladat10()
        {
            Random rnd = new Random();
            int n = rnd.Next(5, 21);
            int[] tomb = new int[n];
            for (int i = 0; i < n; i++)
            {
                tomb[i] = rnd.Next(1, 101);
            }
            Console.WriteLine("Eredeti tömb:");
            Console.WriteLine(string.Join(", ", tomb));
            List<int> masodikElemek = new List<int>();
            for (int i = 1; i < tomb.Length; i += 2)
            {
                masodikElemek.Add(tomb[i]);
            }
            Console.WriteLine("\nMinden második elem:");
            Console.WriteLine(string.Join(", ", masodikElemek));
            Array.Reverse(tomb);
            Console.WriteLine("\nFordított sorrend:");
            Console.WriteLine(string.Join(", ", tomb));
            int matrixMeret = (int)Math.Ceiling(Math.Sqrt(tomb.Length));
            int[,] matrix = new int[matrixMeret, matrixMeret];
            for (int i = 0; i < tomb.Length; i++)
            {
                matrix[i / matrixMeret, i % matrixMeret] = tomb[i];
            }
            Console.WriteLine($"\nRendezett négyzetes mátrix ({matrixMeret}x{matrixMeret}):");
            for (int i = 0; i < matrixMeret; i++)
            {
                for (int j = 0; j < matrixMeret; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /*
         
        11. Készítsünk algoritmust, amely egy N ×M-es mátrix elemeit az óramutató járásának megfelelően K ×90◦-kal
            "elforgatja", ahol K egész szám. Két példát mutatunk a K = 1 esetre.
         
         */

        static void feladat11()
        {
            Random rnd = new Random();
            int N = rnd.Next(2, 10);
            int M = rnd.Next(2, 10);
            int[,] matrix = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = rnd.Next(1, 101);
                }
            }
            Console.WriteLine($"Eredeti mátrix ({N}x{M}):");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.Write("Add meg az elforgatás mértékét (K): ");
            int K = int.Parse(Console.ReadLine());
            K = K % 4;
            for (int k = 0; k < K; k++)
            {
                int[,] ujMatrix = new int[M, N];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        ujMatrix[j, N - 1 - i] = matrix[i, j];
                    }
                }
                matrix = ujMatrix;
                int temp = N;
                N = M;
                M = temp;
            }
            Console.WriteLine($"\nElforgatott mátrix ({N}x{M}):");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /*
         
        12. Készítsünk egy egyszerű labirintus játékot. Töltsünk fel egy kétdimenziós tömböt véletlenszerűen true és
            false értékekkel. Adjunk meg egy kezdő koordinátát (indexet), majd határozzuk meg, hogy onnan eljuthatunk-e
            bármilyen úton a jobb alsó sarokba mindig csak szomszédos true mezőkre lépve. Egy adott elem szomszédai alatt
            a tőle balra és jobbra, valamint felette és alatta lévő elemeket értjük. A feltételeknek eleget tevő út nem minden
            esetben létezik. Ugyanígy előfordulhat, hogy több megfelelő útvonal is található a labirintusban.
         
         */

        static void feladat12()
        {
            Random rnd = new Random();
            int N = rnd.Next(2, 10);
            int M = rnd.Next(2, 10);
            bool[,] labirintus = new bool[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    labirintus[i, j] = rnd.Next(0, 2) == 1;
                }
            }
            Console.WriteLine($"Labirintus ({N}x{M}):");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(labirintus[i, j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
            Console.Write("Add meg a kezdő koordinátát (sor oszlop): ");
            string[] koordinatak = Console.ReadLine().Split(' ');
            int startSor = int.Parse(koordinatak[0]);
            int startOszlop = int.Parse(koordinatak[1]);
            bool elerheto = Elerheto(labirintus, startSor, startOszlop, N - 1, M - 1);
            if (elerheto)
            {
                Console.WriteLine("Elérhető a jobb alsó sarok.");
            }
            else
            {
                Console.WriteLine("Nem elérhető a jobb alsó sarok.");
            }
        }

        static bool Elerheto(bool[,] lab, int si, int sj, int ti, int tj)
        {
            int n = lab.GetLength(0);
            int m = lab.GetLength(1);
            if (si < 0 || si >= n || sj < 0 || sj >= m) return false;
            if (ti < 0 || ti >= n || tj < 0 || tj >= m) return false;
            if (!lab[si, sj] || !lab[ti, tj]) return false;
            bool[,] visited = new bool[n, m];
            var q = new System.Collections.Generic.Queue<(int, int)>();
            q.Enqueue((si, sj));
            visited[si, sj] = true;
            int[] di = { -1, 1, 0, 0 };
            int[] dj = { 0, 0, -1, 1 };
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                int i = p.Item1, j = p.Item2;
                if (i == ti && j == tj) return true;
                for (int k = 0; k < 4; k++)
                {
                    int ni = i + di[k], nj = j + dj[k];
                    if (ni >= 0 && ni < n && nj >= 0 && nj < m && !visited[ni, nj] && lab[ni, nj])
                    {
                        visited[ni, nj] = true;
                        q.Enqueue((ni, nj));
                    }
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            feladat(1);
            feladat1();
            feladat(2);
            feladat2();
            feladat(3);
            feladat3();
            feladat(4);
            feladat4();
            feladat(5);
            feladat5();
            feladat(6);
            feladat6();
            feladat(7);
            feladat7();
            feladat(8);
            feladat8();
            feladat(9);
            feladat9();
            feladat(10);
            feladat10();
            feladat(11);
            feladat11();
            feladat(12);
            feladat12();
            Console.ReadKey();
        }
    }
}
