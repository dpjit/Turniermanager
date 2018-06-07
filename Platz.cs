using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Platz
    {
        public Mannschaft Team;
        public int Siege = 0;
        public int Unentschieden = 0;
        public int Niederlagen = 0;
        public int Punkte = 0;
        public int Torverhaeltnis = 0;


        public Platz(Mannschaft team)
        {
            Team = team;
        }

        public override string ToString()
        {
            return Team.Bezeichnung.PadRight(30) + "\t" + Siege + "/" + Unentschieden + "/" + Niederlagen + "\t" + Torverhaeltnis + "\t" + Punkte;
        }
    }
}
