using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Mannschaft
    {       
        public string Bezeichnung;        

        public Mannschaft()
        {
            Bezeichnung = "BYE";            
        }

        public Mannschaft(string bezeichnung)
        {            
            Bezeichnung = bezeichnung;
        }
    }
}
