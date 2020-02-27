using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flußbeobachter_simple {
    class Stadt {
        public string Name { get; set; }

        public void WasserschutzwandErrichten ( object sender, EventArgs e ) {
            Thread.Sleep ( 2000 );
            Console.WriteLine ("Wasserschutzwand wurde soeben errichtet");
        }

        public void WasserschutzwandAbbauen ( object sender, EventArgs e ) {
            Thread.Sleep (1000);
            Console.WriteLine ( "Wasserschutzwand wurde soeben abgebaut!" );
        }
    }
}
