using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Spiel
    {
        public int Nummer;
        public Mannschaft TeamA;
        public Mannschaft TeamB;
        public int[] Ergebnis;
        public bool Status;
        public int Form;

        public Spiel(int nummer, Mannschaft a, Mannschaft b, int form)
        {
            Form = form;
            Nummer = nummer; TeamA = a; TeamB = b;
            if (TeamA.Bezeichnung == "BYE") ErgebnisEintragen(0, 1);
            else if (TeamB.Bezeichnung == "BYE") ErgebnisEintragen(1, 0);
            else Status = false;
        }

        public Spiel(int nummer, string a, string b, string erg, int form)
        {
            Form = form;
            Nummer = nummer; TeamA = new Mannschaft(a); TeamB = new Mannschaft(b);
            if (erg == ":") Status = false;
            else ErgebnisEintragen(Convert.ToInt32(erg.Split(':')[0]), Convert.ToInt32(erg.Split(':')[1]));
        }

        public Mannschaft GetGewinner()
        {
            return Ergebnis[0] > Ergebnis[1] ? TeamA : TeamB;
        }

        public void ErgebnisEintragen(int a, int b)
        {
            if (Form == 2)
            {
                if (a == b) System.Windows.Forms.MessageBox.Show("Ergebnisform falsch! Unentschieden bei ausgewählter Tunierform nicht möglich!");
                else Abschliessen(a, b);                
            }
            else Abschliessen(a, b);            
        }

        private void Abschliessen(int a, int b)
        {
            Ergebnis = new int[2];
            Ergebnis[0] = a;
            Ergebnis[1] = b;
            Status = true;
        }

        public override string ToString()
        {
            return this.Nummer + "\t" + this.TeamA.Bezeichnung + "\tgegen\t" + this.TeamB.Bezeichnung;
        }
    }
}
