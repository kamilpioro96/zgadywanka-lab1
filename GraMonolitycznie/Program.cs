using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace GraMonolitycznie
{
    class Program
    {

        static void Main(string[] args)
        {
            Random generator = new Random();
            int blef = generator.Next(0, 10);
            int ilosc_krokow = 0;

            bool czy_jest_blef = true; //wartownik (zwany czasami flagą)

            Console.WriteLine("Witaj!");
            Console.Write("Podaj swoje imię: ");
            string x = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Witaj, {x}");
            Console.WriteLine("Podaj zakres liczb z których mam losować");

            Console.WriteLine("Podaj liczbę a");

            int a = 0;
        Ponow:
            
            try
            {

                a = int.Parse(Console.ReadLine());
                if (a < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podaj liczbę dodatnią");
                    Console.ResetColor();
                    goto Ponow;
                }
               
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nie podano liczby!");
                Console.ResetColor();
                goto Ponow;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Wartość jest za duza lub za mała dla bajtu bez znaku.");
                Console.ResetColor();
                goto Ponow;
            }
        



            Console.WriteLine("Podaj liczbę b");
            int b = 0;
        Ponow2:
            try
            {
                b = int.Parse(Console.ReadLine());
                if (b < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podaj liczbę dodatnią");
                    Console.ResetColor();
                    goto Ponow2;
                }
                if (a > b)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Wartość a ,nie może być większa od b");
                    Console.ResetColor();
                    goto Ponow2;
                }
               
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nie podano liczby!");
                Console.ResetColor();
                goto Ponow2;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Wartość jest za duza lub za mała dla bajtu bez znaku.");
                Console.ResetColor();
                goto Ponow2;
            }









            long wylosowana = generator.Next(a, b);

            Console.WriteLine($"Wylosowałem liczbę od {a} do {b}. \n Odgadnij ją.Pamiętaj mogę jeden raz blefować\n Jeśli chcesz poddać grę ,naciśnij x.");

#if (DEBUG)

#endif

            //wykonuj
            bool trafiono = false; //wartownik (zwany czasami flagą)
        blef:
            do
            {
                ilosc_krokow++;

                #region Krok 2. Człowiek proponuje rozwiązanie
                Console.Write("Podaj swoją propozycję: ");
                string tekst = Console.ReadLine();

                if (tekst.ToLower() == "x")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Poddałeś się,wylosowaną liczbą była {wylosowana}");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }





                int propozycja = 0;
                try
                {
                    propozycja = Convert.ToInt32(tekst);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nie podano liczby!");
                    Console.ResetColor();
                    goto blef;
                    //continue;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Wartość jest za duza lub za mała dla bajtu bez znaku.");
                     Console.ResetColor();
                    goto blef;
                }
                if (propozycja > b)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Liczba nie mieści się w przedziale!");
                    Console.ResetColor();
                    goto blef;
                    //continue;
                }
                if (propozycja < a)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Liczba nie mieści się w przedziale!");
                    Console.ResetColor();
                    goto blef;
                    //continue;
                }




                Console.WriteLine($"Przyjąłem wartość {propozycja}");
                #endregion


                #region Krok 3. Komputer ocenia propozycję
                if (propozycja < wylosowana)
                {
                    if (ilosc_krokow == blef && czy_jest_blef == true)
                    {

                        czy_jest_blef = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("za dużo");
                        Console.ResetColor();
                        goto blef;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("za mało");
                    Console.ResetColor();
                }

                else if (propozycja > wylosowana)
                {
                    if (ilosc_krokow == blef)
                    {



                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("za mało");
                        Console.ResetColor();
                        goto blef;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("za dużo");
                    Console.ResetColor();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Trafiono,udało ci się odgadnąć za {ilosc_krokow} razem");
                    Console.ResetColor();
                    trafiono = true;
                    Console.ReadKey();
                }
                #endregion


            }
            while (!trafiono);
            //do momentu trafienia


        }
    }
}
