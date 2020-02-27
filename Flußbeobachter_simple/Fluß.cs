using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flußbeobachter_simple {
    class Fluß {
        public string Name { get; set; }
        public int Wasserstand { get; set; }
        private Random zzG = new Random ();  // Zufallsgenerator
        private int neuerWasserstand;

        // unsere events
        public event EventHandler<EventArgs> SchiffsEvent_wenig_Wasser;
        public event EventHandler<EventArgs> SchiffsEvent_viel_Wasser;
        public event EventHandler<EventArgs> SchiffsEvent_alles_wieder_normal;
        public event EventHandler<EventArgs > StadtEvent_viel_Wasser;
        public event EventHandler<EventArgs > StadtEvent_alles_wieder_normal;
        public event EventHandler<EventArgs> Klärwerk_wenig_Wasser;
        public event EventHandler<EventArgs> Klärwerk_viel_Wasser;

        
        // Listen von Städten, Schiffen und Klärwerken
        private List<Stadt> städte = new List<Stadt> ();
        private List<Schiff> schiffe = new List<Schiff> ();
        private List<Klärwerk> klärwerke = new List<Klärwerk> (); 
        

        // Einfügen einer Stadt vom Hauptprogramm und Aufnahme in die Liste
        internal void AddStadt ( Stadt stadt ) {
            //  Events zeigen auf Methoden
            this.StadtEvent_viel_Wasser += stadt.WasserschutzwandErrichten;
            this.StadtEvent_alles_wieder_normal += stadt.WasserschutzwandAbbauen;
            // nimm die Standt in die Liste auf
            städte.Add(stadt);
        }

        // Einfügen eines Schiffs für die Aufnahme in die Liste + Event-Methoden-Zuweisung
        internal void AddSchiff ( Schiff schiff ) {
            this.SchiffsEvent_viel_Wasser += schiff.Anhalten;
            this.SchiffsEvent_wenig_Wasser += schiff.Anhalten;
            this.SchiffsEvent_alles_wieder_normal += schiff.Weiterfahen;
            schiffe.Add ( schiff );
        }

        // s.o.
        internal void AddKlärwerk ( Klärwerk klärwerk ) {
            this.Klärwerk_viel_Wasser += klärwerk.EinleitungStoppen;
            this.Klärwerk_wenig_Wasser += klärwerk.EinleitungStarten;

            klärwerke.Add ( klärwerk );
        }

        public void OnWasserstandsÄnderung () {
            neuerWasserstand = zzG.Next (100, 10001);  // zufälliger Wert
            Thread.Sleep ( 100 );  // warte ...
            var alterWasserstand = this.Wasserstand;  // Merker
            Wasserstand = neuerWasserstand;  // Der Fluß erhält den neuen Wasserstand
            Console.WriteLine ("Alter Wasserstand: {0}  Neuer Wasserstand: {1}", alterWasserstand,neuerWasserstand);

            // Abhängig vom Wasserstand wird für jedes Element der Liste
            // das Event ausgelöst und die korrekte Methode aufgerufen
            if ( Wasserstand < 250 ) {
                foreach ( var einSchiff in this.schiffe ) {
                    SchiffsEvent_wenig_Wasser ( this, EventArgs.Empty );
                }
            }
            if ( Wasserstand < 3000  ) {
                foreach ( var einKlärwert in klärwerke ) {
                    Klärwerk_wenig_Wasser (this, EventArgs.Empty);
                }
            }

            if ( Wasserstand > 8000 ) {
                foreach ( var einSchiff in this.schiffe ) {
                    SchiffsEvent_viel_Wasser ( this, EventArgs.Empty );
                }
                foreach ( var einKlärwerk in this.klärwerke ) {
                    Klärwerk_viel_Wasser ( this, EventArgs.Empty );
                }
            }
            if ( Wasserstand >=250 && Wasserstand <=8000 ) {
                foreach ( var einSchiff in schiffe ) {
                    SchiffsEvent_alles_wieder_normal (this, EventArgs.Empty);
                }
            }
            if ( Wasserstand > 8200 ) {
                foreach ( var EineStadt in städte ) {
                    StadtEvent_viel_Wasser (this, EventArgs.Empty);
                }
            } else {
                foreach ( var EineStadt in städte ) {
                    StadtEvent_alles_wieder_normal ( this, EventArgs.Empty );
                }
            }
        }
    }
}
