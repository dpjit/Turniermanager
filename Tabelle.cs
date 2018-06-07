using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Tabelle
    {
        public List<Platz> Platzierung = new List<Platz>();
        Gruppe Gruppe;

        public Tabelle(Gruppe g)
        {
            Gruppe = g;
        }

        public void Aktualisieren()
        {
            Platzierung.Clear();
            foreach (Mannschaft i in Gruppe.Teams)
            {
                if (i.Bezeichnung != "BYE")
                {
                    Platz p = new Platz(i);
                    Platzierung.Add(p);

                    foreach (Spieltag tag in Gruppe.Spielplan.Spieltag)
                        foreach (Spiel spiel in tag.Spiel)
                        {
                            if (spiel.Status)
                            {
                                if (i.Bezeichnung == spiel.TeamA.Bezeichnung)
                                {
                                    if (spiel.Ergebnis[0] > spiel.Ergebnis[1]) { p.Siege += 1; p.Punkte += 3; }
                                    if (spiel.Ergebnis[0] == spiel.Ergebnis[1]) { p.Unentschieden += 1; p.Punkte += 1; }
                                    if (spiel.Ergebnis[0] < spiel.Ergebnis[1]) { p.Niederlagen += 1; }
                                    p.Torverhaeltnis += spiel.Ergebnis[0];
                                    p.Torverhaeltnis -= spiel.Ergebnis[1];
                                }
                                if (i.Bezeichnung == spiel.TeamB.Bezeichnung)
                                {
                                    if (spiel.Ergebnis[0] < spiel.Ergebnis[1]) { p.Siege += 1; p.Punkte += 3; }
                                    if (spiel.Ergebnis[0] == spiel.Ergebnis[1]) { p.Unentschieden += 1; p.Punkte += 1; }
                                    if (spiel.Ergebnis[0] > spiel.Ergebnis[1]) { p.Niederlagen += 1; }
                                    p.Torverhaeltnis += spiel.Ergebnis[1];
                                    p.Torverhaeltnis -= spiel.Ergebnis[0];
                                }
                            }
                        }
                }
            }
            Platzierung = Platzierung.OrderByDescending(i => i.Torverhaeltnis).ToList();
            Platzierung = Platzierung.OrderByDescending(i => i.Punkte).ToList();
        }

        public override string ToString()
        {
            string str = string.Empty; int nr = 1; int l = 0;
            foreach (Platz i in Platzierung)
                if (i.Team.Bezeichnung.Length > l) l = i.Team.Bezeichnung.Length;

            str += "# Team".PadRight(l + 10) + "\t" + "S/U/N" + "\t" + "TD" + "\t" + "Pkte\n";
            foreach (Platz i in Platzierung)
            {
                str += (nr + ". " + i.Team.Bezeichnung).PadRight(l + 10) + "\t" + i.Siege + "/" + i.Unentschieden + "/" + i.Niederlagen + "\t" + i.Torverhaeltnis + "\t" + i.Punkte + "\n";
                nr++;
            }
            return str;
        }


    }
}
