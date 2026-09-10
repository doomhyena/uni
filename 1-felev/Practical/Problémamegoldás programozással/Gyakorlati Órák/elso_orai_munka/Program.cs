namespace elso_orai_munka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*

            2. Bővítsük ki az előbbi programot: helyezzünk el néhányat az alábbi utasításokból a szöveg megjelenítését
                végző utasítás elé vagy után. Az utasítások a kurzor és a parancssori ablak jellemzőit módosítják.
                * Console.Clear()
                * Console.WindowHeight
                * Console.WindowWidth
                * Console.BackgroundColor
                * Console.ForegroundColor
                * Console.SetCursorPosition()
                * Console.CursorVisible

             */

            Console.Clear();
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;

            Console.WriteLine("Hello, World!");
            Console.ReadLine();

            /*
             
            3 Készítsünk programot, amely elkéri a felhasználó nevét, majd név szerint köszönti őt.
             
             */

            Console.Write("Kérem adja meg a nevét: ");
            string name = Console.ReadLine();
            Console.WriteLine("Üdvözlöm, " + name + "!");

            /*
             
            4 Készítsünk programot, amely elkéri a felhasználó születési évét, ez alapján pedig kiszámítja és kiírja az
                életkorát. A program írja ki azt is, hány éves lesz a felhasználó a következő évben.


             */

            Console.Write("Kérem adja meg a születési évét: ");
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear))
            {
                Console.Write("Érvénytelen érték. Kérem adja meg a születési évét számként: ");
            }
            int age = DateTime.Now.Year - birthYear;
            Console.WriteLine("Ön {0} éves.", age);
            Console.WriteLine("Továbbiakban {0} éves lesz.", age + 1);


            /*
             
            5 Készítsünk programot, amely elkéri a felhasználó testmagasságát 
                (h, méterben) és testtömegét (m, kilogrammban),  majd kiszámítja és kiírja a felhasználó testtömegindexét (BMI). 
                A számításhoz használt formula:
                BMI = m / (h * h)
             
             */

            Console.WriteLine("Kérem adja meg a testmagasságát méterben: ");
            double height;
            while (!double.TryParse(Console.ReadLine(), out height))
            {
                Console.Write("Érvénytelen érték. Kérem adja meg a testmagasságát (pl. 1.75): ");
            }
            Console.WriteLine("Kérem adja meg a testtömegét kilogrammban: ");
            double weight;
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.Write("Érvénytelen érték. Kérem adja meg a testtömegét (pl. 70.5): ");
            }
            double bmi = weight / (height * height);
            Console.WriteLine("A testtömegindexe: {0:F2}", bmi);

            /*
             
            6 Kérjünk el a felhasználótól egy másodpercben megadott időtartamot, majd írjuk ki azt perc:másodperc formátumban.
                Példa
                    Az időtartam másodpercben: 123
                    Az időtartam formázva: 2:03
             
             */

            Console.WriteLine("Kérem adja meg az időtartamot másodpercben: ");
            int seconds;
            while (!int.TryParse(Console.ReadLine(), out seconds))
            {
                Console.Write("Érvénytelen érték. Kérem adja meg az időtartamot egész másodpercben: ");
            }
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            Console.WriteLine("Az időtartam formázva: {0}:{1:00}", minutes, remainingSeconds);


            /*
             
             7 Kérjük el a felhasználótól a jelszavát, majd kérjük el még egyszer megerősítésképp. Ha egyezik a két megadott
                jelszó, nyugtázzuk egy zöld színnel kiírt üzenettel, ellenkező esetben jelenítsünk meg egy piros színű hibaüzenetet
             
             */

            Console.WriteLine("Kérem adja meg a jelszavát: ");
            string password1 = Console.ReadLine();
            Console.WriteLine("Kérem adja meg a jelszavát újra megerősítésképp: ");
            string password2 = Console.ReadLine();
            if (password1 == password2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A jelszó megerősítve.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A jelszó nem egyezik meg.");
            }
            Console.ResetColor();

            /*
             
             8 Alakítsuk át úgy az előző programot, hogy a jelszó beírásakor a karakterek helyett csak *-ok jelenjenek meg.
                Legyen lehetőség tévesen bevitt karakter törlésére is a Backspace billentyűvel
             
             */

            Console.WriteLine("Kérem adja meg a jelszavát: ");
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.WriteLine("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            /*
             
            9. Kérjünk el a felhasználótól kettő számot és egy műveleti jelet, majd írjuk ki a képernyőre az adott művelet
                eredményét a két szám között elvégezve.
            
            */

            Console.WriteLine("Kérem az első számot: ");
            int elsoszam = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a második számot: ");
            int masodikszam = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a műveletet: ");
            string muvelet = Console.ReadLine();
            switch (muvelet)
            {
                case "+":
                    Console.WriteLine("Az eredmény: " + (elsoszam + masodikszam));
                    break;
                case "-":
                    Console.WriteLine("Az eredmény: " + (elsoszam - masodikszam));
                    break;
                case "*":
                    Console.WriteLine("Az eredmény: " + (elsoszam * masodikszam));
                    break;
                case "/":
                    if (masodikszam != 0)
                    {
                        Console.WriteLine("Az eredmény: " + (elsoszam / masodikszam));
                    }
                    else
                    {
                        Console.WriteLine("Hiba: nullával való osztás!");
                    }
                    break;
                default:
                    Console.WriteLine("Hiba: érvénytelen művelet!");
                    break;
            }

            /*
            
            11. Kérjünk egy a felhasználótól egy 0 és 9 közötti értéket, majd írjuk ki a számot szövegesen. Ha a tartományon kívüli értéket ad meg, tájékoztassuk hibaüzenettel.
            Példa
                Adj meg egy számot:
                9
                Az általad megadott szám:
                kilenc
             
             */

            Console.WriteLine("Kérem adjon meg egy számot 0 és 9 között: ");
            int szam = int.Parse(Console.ReadLine());
            switch (szam)
            {
                case 0:
                    Console.WriteLine("Az általad megadott szám: nulla");
                    break;
                case 1:
                    Console.WriteLine("Az általad megadott szám: egy");
                    break;
                case 2:
                    Console.WriteLine("Az általad megadott szám: kettő");
                    break;
                case 3:
                    Console.WriteLine("Az általad megadott szám: három");
                    break;
                case 4:
                    Console.WriteLine("Az általad megadott szám: négy");
                    break;
                case 5:
                    Console.WriteLine("Az általad megadott szám: öt");
                    break;
                case 6:
                    Console.WriteLine("Az általad megadott szám: hat");
                    break;
                case 7:
                    Console.WriteLine("Az általad megadott szám: hét");
                    break;
                case 8:
                    Console.WriteLine("Az általad megadott szám: nyolc");
                    break;
                case 9:
                    Console.WriteLine("Az általad megadott szám: kilenc");
                    break;
                default:
                    Console.WriteLine("Hiba: érvénytelen szám!");
                    break;
            }

            // 12. Kérjünk egy a felhasználótól egy betűt, majd írjuk ki, hogy magánhangzót vagy mássalhangzót adott-e meg.

            Console.WriteLine("Kérem adjon meg egy betűt: ");
            char betu = char.Parse(Console.ReadLine());
            switch (betu)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("Az általad megadott betű: magánhangzó");
                    break;
                default:
                    Console.WriteLine("Az általad megadott betű: mássalhangzó");
                    break;
            } 
            Console.WriteLine("Az általad megadott betű: " + betu);

            /*
             
             13. Adott egy V térfogatú tartály, amit két csővezetéken keresztül töltünk fel fel. Ismerjük a vezetékekben a
                térfogatáramot (az egy óra alatt átfolyó térfogatot). A két vezetéket egyszerre nyitjuk meg, majd T óráig folyni
                hagyjuk. Adjuk meg, hogy az időtartam végén mennyire telt meg a tartály
             
             */

            Console.WriteLine("Kérem adja meg a tartály térfogatát (V): ");
            int V = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg az első csővezeték térfogatáramát (m1): ");
            int m1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg a második csővezeték térfogatáramát (m2): ");
            int m2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg az időtartamot (T): ");
            int T = int.Parse(Console.ReadLine());
            Console.WriteLine("A tartály a megadott időtartam végén {0:F2}%-ban telt meg.", (m1 + m2) * T / V * 100);
        }
    }
}
