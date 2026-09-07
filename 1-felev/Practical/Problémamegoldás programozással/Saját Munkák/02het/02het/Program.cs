using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02het
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // if-else
            int kor = 21;
            if (kor >= 18)
            {
                Console.WriteLine("Nagykorú");
            } 
            else if (kor >= 14)
            {
                Console.WriteLine("Fiatalkorú");
            }
            else
            {
                Console.WriteLine("Kiskorú");
            }

            Console.WriteLine("----------------------------------------------------");

            // switch case
            int nap = 1;
            switch (nap)
            {
                case 1:
                    Console.WriteLine("Hétfő");
                    break;
                case 2:
                    Console.WriteLine("Kedd");
                    break;
                default: 
                    Console.WriteLine("Ismeretlen nap");
                    break;
            }

            Console.WriteLine("----------------------------------------------------");

            string napNeve;
            switch (nap)
            {
                case 1:
                    napNeve = "Hétfő";
                    break;
                case 2:
                    napNeve = "Kedd";
                    break;
                case 3:
                    napNeve = "Szerda";
                    break;
                default:
                    napNeve = "Ismeretlen nap";
                    break;
            }
            Console.WriteLine(napNeve);

            Console.WriteLine("----------------------------------------------------");

            // for - pontosan mint Java-ban
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            
            // while
            int k = 0;
            
            Console.WriteLine("----------------------------------------------------");

            while (k < 10)
            {
                Console.WriteLine(k);
                k++;
            }

            Console.WriteLine("----------------------------------------------------");

            // do-while
            int j = 0;
            do
            {
                Console.WriteLine(j);
                j++;
            } while (j < 10);

            Console.WriteLine("----------------------------------------------------");

            // foreach - ez a Java "enhanced for" (for-each) megfelelője
            int[] szamok = { 1, 2, 3, 4, 5 };
            foreach (int szam in szamok)
            {
                Console.WriteLine(szam);
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Feladatok:");
            Console.WriteLine("----------------------------------------------------");

            int choice = -1;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Válassz egy feladatot:");
                Console.WriteLine("1 - BMI kalkulátor");
                Console.WriteLine("2 - Számjegyek összege");
                Console.WriteLine("3 - FizzBuzz (1-50)");
                Console.WriteLine("4 - Páros/páratlan döntő");
                Console.WriteLine("5 - Nullable példa");
                Console.WriteLine("6 - Nap neve (classic switch)");
                Console.WriteLine("7 - Prímszám eldöntő");
                Console.WriteLine("8 - Legnagyobb közös osztó (Euklidesz)");
                Console.WriteLine("9 - Egyszerű kamatszámítás (decimal)");
                Console.WriteLine("10 - Hónap napjainak száma");
                Console.WriteLine("11 - Számkitaláló játék (1-100)");
                Console.WriteLine("12 - Karakter osztályozó");
                Console.WriteLine("0 - Kilépés");
                Console.Write("Választás: ");

                string choiceInput = Console.ReadLine();
                int parsedChoice;
                if (!int.TryParse(choiceInput, out parsedChoice))
                {
                    Console.WriteLine("Érvénytelen választás.");
                    continue;
                }

                choice = parsedChoice;

                switch (choice)
                {
                    case 1:
                        Console.Write("Testsúly (kg): ");
                        double weight;
                        if (!double.TryParse(Console.ReadLine(), out weight))
                        {
                            Console.WriteLine("Érvénytelen testsúly.");
                            break;
                        }

                        Console.Write("Magasság (m): ");
                        double height;
                        if (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
                        {
                            Console.WriteLine("Érvénytelen magasság.");
                            break;
                        }

                        double bmi = weight / (height * height);
                        Console.WriteLine("BMI: " + bmi.ToString("F2"));
                        if (bmi < 18.5)
                        {
                            Console.WriteLine("Sovány");
                        }
                        else if (bmi < 25)
                        {
                            Console.WriteLine("Normál");
                        }
                        else if (bmi < 30)
                        {
                            Console.WriteLine("Túlsúlyos");
                        }
                        else
                        {
                            Console.WriteLine("Elhízott");
                        }
                        break;

                    case 2:
                        Console.Write("Adj meg egy nemnegatív egész számot: ");
                        long n;
                        if (!long.TryParse(Console.ReadLine(), out n) || n < 0)
                        {
                            Console.WriteLine("Érvénytelen szám.");
                            break;
                        }

                        long sum = 0;
                        if (n == 0)
                        {
                            sum = 0;
                        }
                        else
                        {
                            while (n > 0)
                            {
                                sum += n % 10;
                                n /= 10;
                            }
                        }
                        Console.WriteLine("A számjegyek összege: " + sum);
                        break;

                    case 3:
                        for (int i = 1; i <= 50; i++)
                        {
                            if (i % 15 == 0)
                            {
                                Console.WriteLine("FizzBuzz");
                            }
                            else if (i % 3 == 0)
                            {
                                Console.WriteLine("Fizz");
                            }
                            else if (i % 5 == 0)
                            {
                                Console.WriteLine("Buzz");
                            }
                            else
                            {
                                Console.WriteLine(i);
                            }
                        }
                        break;

                    case 4:
                        Console.Write("Adj meg egy egész számot: ");
                        int szam;
                        if (int.TryParse(Console.ReadLine(), out szam))
                        {
                            if (szam % 2 == 0)
                            {
                                Console.WriteLine("A szám páros.");
                            }
                            else
                            {
                                Console.WriteLine("A szám páratlan.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen szám.");
                        }
                        break;

                    case 5:
                        int? val = null;
                        Console.Write("Szeretnél értéket adni neki? (i/n): ");
                        string yn = Console.ReadLine();
                        if (!string.IsNullOrEmpty(yn) && (yn.ToLower().StartsWith("i") || yn.ToLower().StartsWith("y")))
                        {
                            Console.Write("Adj meg egy egész számot: ");
                            int parsed;
                            if (int.TryParse(Console.ReadLine(), out parsed))
                            {
                                val = parsed;
                            }
                        }
                        int displayed = val ?? -1;
                        Console.WriteLine("Az érték: " + displayed);
                        break;

                    case 6:
                        Console.Write("Adj meg egy nap számot (1-7): ");
                        int napSzam;
                        if (!int.TryParse(Console.ReadLine(), out napSzam))
                        {
                            Console.WriteLine("Érvénytelen nap szám.");
                            break;
                        }

                        string menuNapNeve;
                        switch (napSzam)
                        {
                            case 1:
                                menuNapNeve = "Hétfő";
                                break;
                            case 2:
                                menuNapNeve = "Kedd";
                                break;
                            case 3:
                                menuNapNeve = "Szerda";
                                break;
                            default:
                                menuNapNeve = "Ismeretlen nap";
                                break;
                        }
                        Console.WriteLine("A nap neve: " + menuNapNeve);
                        break;

                    case 7:
                        // Prímszám eldöntő
                        Console.Write("Adj meg egy egész számot: ");
                        int p;
                        if (!int.TryParse(Console.ReadLine(), out p))
                        {
                            Console.WriteLine("Érvénytelen szám.");
                            break;
                        }
                        if (p < 2)
                        {
                            Console.WriteLine("Nem prím");
                            break;
                        }
                        bool isPrime = true;
                        int limit = (int)Math.Floor(Math.Sqrt(p));
                        for (int d = 2; d <= limit; d++)
                        {
                            if (p % d == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        Console.WriteLine(isPrime ? "Prím" : "Nem prím");
                        break;

                    case 8:
                        // Legnagyobb közös osztó (Euklidesz)
                        Console.Write("Első egész szám: ");
                        int a;
                        if (!int.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("Érvénytelen szám.");
                            break;
                        }
                        Console.Write("Második egész szám: ");
                        int b;
                        if (!int.TryParse(Console.ReadLine(), out b))
                        {
                            Console.WriteLine("Érvénytelen szám.");
                            break;
                        }
                        a = Math.Abs(a);
                        b = Math.Abs(b);
                        if (a == 0 && b == 0)
                        {
                            Console.WriteLine("LNKO nem definiált (mindkettő 0).");
                            break;
                        }
                        while (b != 0)
                        {
                            int r = a % b;
                            a = b;
                            b = r;
                        }
                        Console.WriteLine("LNKO: " + a);
                        break;

                    case 9:
                        // Egyszerű kamatszámítás decimal-lal
                        Console.Write("Kezdőtőke (pl. 1000.00): ");
                        decimal principal;
                        if (!decimal.TryParse(Console.ReadLine(), out principal))
                        {
                            Console.WriteLine("Érvénytelen összeg.");
                            break;
                        }
                        Console.Write("Éves kamatláb (pl. 0.05): ");
                        decimal rate;
                        if (!decimal.TryParse(Console.ReadLine(), out rate))
                        {
                            Console.WriteLine("Érvénytelen kamatláb.");
                            break;
                        }
                        Console.Write("Évek száma: ");
                        int years;
                        if (!int.TryParse(Console.ReadLine(), out years) || years < 0)
                        {
                            Console.WriteLine("Érvénytelen évek száma.");
                            break;
                        }
                        for (int y = 0; y < years; y++)
                        {
                            principal = principal * (1 + rate);
                        }
                        Console.WriteLine("Végösszeg: " + principal.ToString("F2"));
                        break;

                    case 10:
                        // Hónap napjainak száma (classic switch)
                        Console.Write("Hónap száma (1-12): ");
                        int month;
                        if (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
                        {
                            Console.WriteLine("Érvénytelen hónap.");
                            break;
                        }
                        Console.Write("Év: ");
                        int year;
                        if (!int.TryParse(Console.ReadLine(), out year))
                        {
                            Console.WriteLine("Érvénytelen év.");
                            break;
                        }
                        bool isLeap = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
                        int daysInMonth;
                        switch (month)
                        {
                            case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                                daysInMonth = 31; break;
                            case 4: case 6: case 9: case 11:
                                daysInMonth = 30; break;
                            case 2:
                                daysInMonth = isLeap ? 29 : 28; break;
                            default:
                                daysInMonth = 0; break;
                        }
                        Console.WriteLine("A hónap napjainak száma: " + daysInMonth);
                        break;

                    case 11:
                        // Számkitaláló játék
                        Random rnd = new Random();
                        int target = rnd.Next(1, 101);
                        int guess;
                        do
                        {
                            Console.Write("Tipp (1-100): ");
                            if (!int.TryParse(Console.ReadLine(), out guess))
                            {
                                Console.WriteLine("Érvénytelen tipp.");
                                continue;
                            }
                            if (guess < target) Console.WriteLine("Nagyobb");
                            else if (guess > target) Console.WriteLine("Kisebb");
                            else Console.WriteLine("Eltaláltad!");
                        } while (guess != target);
                        break;

                    case 12:
                        // Karakter osztályozó
                        Console.Write("Adj meg egy karaktert: ");
                        string cs = Console.ReadLine();
                        if (string.IsNullOrEmpty(cs))
                        {
                            Console.WriteLine("Nincs karakter.");
                            break;
                        }
                        char c = cs[0];
                        if (char.IsDigit(c))
                        {
                            Console.WriteLine("Számjegy");
                        }
                        else if (char.IsLetter(c))
                        {
                            string vowels = "aáeéiíoóöőuúüűAÁEÉIÍOÓÖŐUÚÜŰ";
                            if (vowels.IndexOf(c) >= 0) Console.WriteLine("Magánhangzó");
                            else Console.WriteLine("Mássalhangzó");
                        }
                        else
                        {
                            Console.WriteLine("Egyéb karakter");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Kilépés...");
                        break;

                    default:
                        Console.WriteLine("Ismeretlen választás.");
                        break;
                }
            } while (choice != 0);

            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();

        }
    }
}