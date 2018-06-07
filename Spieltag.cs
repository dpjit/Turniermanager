using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Spieltag
    {
        public List<Spiel> Spiel;

        public Spieltag()
        {
            Spiel = new List<Spiel>();
        }

        public List<Mannschaft> GetGewinner()
        {
            List<Mannschaft> Gewinner = new List<Mannschaft>();
            foreach (Spiel s in Spiel)
                Gewinner.Add(s.GetGewinner());
            return Gewinner;
        }

        public bool Abgeschlossen()
        {
            foreach (Spiel s in Spiel)
                if (!s.Status) return false;
            return true;
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach (Spiel s in this.Spiel) str += s.ToString() + "\n";
            return str;
        }
    }
}
