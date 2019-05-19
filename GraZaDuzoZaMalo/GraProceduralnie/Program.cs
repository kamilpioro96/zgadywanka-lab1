using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    class Program
    {
        /// <summary>
        /// Generuje wartość pseudolosową z podanego zakresu
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>wartość losowa z zakresu min..max włącznie</returns>
        static int Losuj(int min = 1, int max = 100)
        {
            if( min > max )
            { //swap
                int temp = min;
                min = max;
                max = temp;
            }
            Random generator = new Random();
            return generator.Next(min, max+1);
        }

        static int WczytajLiczbe( string prompt = "Podaj liczbę (X aby zakończyć): " )
        {
            int liczba = 0;
            while (true)
            {
                Console.Write( prompt );
                string tekst = Console.ReadLine();
                if (tekst.ToLower() == "x")
                    throw new OperationCanceledException("wybrano X");
                
                try
                {
                    liczba = Convert.ToInt32(tekst);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby! Spróbuj jeszcze raz.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze! Spróbuj jeszcze raz.");
                    continue;
                }
            }

            return liczba;
        }

        static string Ocena(int propozycja)
        {
            if (propozycja < wylosowana)
                return "za mało";
            else if (propozycja > wylosowana)
                return "za dużo";
            else
                return "trafiono";
        }

        static int wylosowana;

        static void Main(string[] args)
        {
            int min = WczytajLiczbe("Podaj zakres od: ");
            int max = WczytajLiczbe("Podaj zakres do: ");
            wylosowana = Losuj(min, max);
            Console.WriteLine($"Wylosowałem liczbę od {min} do {max}. \n Odgadnij ją");

#if(DEBUG)
            Console.WriteLine(wylosowana);
#endif

            do
            {
                int propozycja = 0;
                try
                {
                    propozycja = WczytajLiczbe("Podaj swoją propozycję (X aby się poddać): ");
                }
                catch(OperationCanceledException)
                {
                    Console.WriteLine("Wyjście awaryjne. Poddałeś się.");
                    break;
                }

                Console.WriteLine($"Przyjąłem wartość {propozycja}");

                string wynik = Ocena(propozycja);
                Console.WriteLine(wynik);
                if (wynik == "trafiono")
                    break;
            }
            while (true);

            Console.WriteLine("Koniec gry");
        }
    }
}
