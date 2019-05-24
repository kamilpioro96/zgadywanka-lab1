using System;

namespace ModelGry
{
    public class Gra
    {
        // subtypes
        public enum Odp { ZaMalo = -1, Trafiono = 0, ZaDuzo = 1 }
        public enum State { Trwa, Poddana, Odgadnieta }

        // fields
        public readonly int ZakresOd;
        public readonly int ZakresDo;

        public State StanGry { get; private set; }

        private readonly int wylosowana;
        public int? Wylosowana
        {
            get
            {
                if (StanGry == State.Poddana || StanGry == State.Odgadnieta)
                    return wylosowana;
                else
                    return null;
            }
        }

        public int LicznikRuchow { get; private set; }  = 0;

        // historia gry: ToDo

        // constructors
        public Gra(int min, int max)
        {
            ZakresOd = min;
            ZakresDo = max;
            // losowanie
            wylosowana = Losuj(ZakresOd, ZakresDo);
            //LicznikRuchow = 0;
            StanGry = State.Trwa;
        }

        public static int Losuj(int min = 1, int max = 100)
        {
            
            if (min > max)
            { //swap
                int temp = min;
                min = max;
                max = temp;
            }
            Random generator = new Random();
            return generator.Next(min, max + 1);
        }

        // methods
        
        public Odp Ocena( int liczba )
        {
            LicznikRuchow++;
            if (liczba < wylosowana)
                return Odp.ZaMalo;
            else if (liczba > wylosowana)
                return Odp.ZaDuzo;
            else // ==
            {
                StanGry = State.Odgadnieta;
                return Odp.Trafiono;
            }
        }

        public void Poddaj()
        {
            StanGry = State.Poddana;
        }
        
    }
}
