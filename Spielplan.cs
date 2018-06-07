using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Spielplan
    {
        public List<Spieltag> Spieltag;

        public Spielplan()
        {
            Spieltag = new List<Spieltag>();
        }

        public void Hinzufuegen(Spieltag spieltag)
        {
            Spieltag.Add(spieltag);
        }

        public bool Abgeschlossen()
        {
            foreach (Spieltag s in Spieltag)
                if (!s.Abgeschlossen()) return false;
            return true;
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach (Spieltag s in this.Spieltag) str += s.ToString() + "\n\n";
            return str;
        }
    }
}
