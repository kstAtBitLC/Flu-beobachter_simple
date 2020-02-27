using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flußbeobachter_simple {
    class Program {
        static void Main ( string [] args ) {
            Fluß rhein = new Fluß () { Name = "Rhein"};
            Fluß donau = new Fluß () { Name="Donau"};

            rhein.AddStadt (new Stadt () { Name = "Düsseldorf"} );
            rhein.AddStadt (new Stadt () { Name = "Köln"} );
            rhein.AddSchiff (new Schiff () { Name = "Rheingold"} );
            rhein.AddSchiff (new Schiff () { Name = "Lorelei"} );

            donau.AddStadt (new Stadt () { Name="Ulm"} );
            donau.AddSchiff(new Schiff () { Name = "Xaver"} );
            donau.AddSchiff(new Schiff () { Name = "Franz"} );
            donau.AddKlärwerk (new Klärwerk () { Name="Strauß 1"} );

            for ( int i = 0 ; i < 50 ; i++ ) {
                rhein.OnWasserstandsÄnderung ();
                donau.OnWasserstandsÄnderung ();
            }

            Console.Read ();
        }
    }
}
