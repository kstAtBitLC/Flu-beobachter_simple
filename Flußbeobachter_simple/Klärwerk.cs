using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flußbeobachter_simple {
    class Klärwerk {
        public string Name { get; set; }

        public void EinleitungStoppen ( object sender, EventArgs e ) {
            Thread.Sleep (2000);
            Console.WriteLine ("Das Klärwerk stoppt die Einleitung");
        }

        public void EinleitungStarten (object sender, EventArgs e) {
            Thread.Sleep ( 2000 );
            Console.WriteLine ("Das Klärwerk startet die Einleitung");
        }
    }
}
