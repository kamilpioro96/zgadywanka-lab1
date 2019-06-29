using System;
using System.Collections.Generic;
using System.Text;

namespace ModelGry
{
    public partial class Gra
    {
        private readonly List<Ruch> historia;
        public IReadOnlyList<Ruch> Historia
        {
          get
            {
                return historia;
            }
        }

        // klasa wewnętrzna
        public class Ruch
        {
            public readonly int propozycja;
            public readonly Odp odpowiedz;
            public readonly DateTime kiedy;

            public Ruch( int prop, Odp odp )
            {
                propozycja = prop;
                odpowiedz = odp;
                kiedy = DateTime.Now;
            }

            public override string ToString() => 
                $"({propozycja}, {odpowiedz}, {kiedy})";

        }
    }
}
