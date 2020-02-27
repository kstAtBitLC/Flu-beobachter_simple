using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flußbeobachter_simple {
    class Schiff {
        public string Name { get; set; }

        public void Anhalten ( object sender, EventArgs e ) {
            Thread.Sleep (1000);
            Console.WriteLine ("Schiff mit dem Namen: {0} wurde angehalten", Name);
        }

        public void Weiterfahen ( object sender, EventArgs e ) {
            Thread.Sleep ( 1000 );
            Console.WriteLine ( "Schiff mit dem Namen: {0} fährt weiter", Name );
        }
    }
}
