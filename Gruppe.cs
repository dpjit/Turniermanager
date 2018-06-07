using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniermanager
{
    class Gruppe
    {
        public List<Mannschaft> Teams;
        public Tabelle Tabelle;
        public Spielplan Spielplan;
        public int Form;
        public int Phase;
        int AnzahlGewinner;

        public Gruppe(int form, int anzahlGewinner, int phase)
        {
            Tabelle = new Tabelle(this);
            Spielplan = new Spielplan();
            Teams = new List<Mannschaft>();
            Form = form;
            Phase = phase;
            AnzahlGewinner = anzahlGewinner;
        }

        public Gruppe(int form, List<Mannschaft> teams, int phase)
        {
            Tabelle = new Tabelle(this);
            Spielplan = new Spielplan();
            Teams = new List<Mannschaft>();
            foreach (Mannschaft m in teams) Teams.Add(m);
            Form = form;
            Phase = phase;
            Start();
        }

        public void Start()
        {
            switch (Form)
            {
                case 1: Liga(); break;
                case 2: KoRunde(); break;
            }
        }

        private void Liga()
        {
            int Spielnummer = 1;
            int AnzahlTeams = Teams.Count;

            //Teams in Zwischencontainer, Letztes Team zu Joker
            Mannschaft Joker = Teams.Last();
            Mannschaft[] TeamsOhneJoker = new Mannschaft[AnzahlTeams - 1];
            for (int i = 0; i < AnzahlTeams - 1; i++)
                TeamsOhneJoker[i] = Teams[i];

            //Spielplan Liga erstellen
            for (int n = 1; n < AnzahlTeams; n++)
            {
                //Spieltag Liga erstellen
                Spieltag PaarungenSpieltag = new Spieltag();
                Mannschaft[] ContainerA = new Mannschaft[AnzahlTeams / 2];
                Mannschaft[] ContainerB = new Mannschaft[AnzahlTeams / 2];
                int offset = (AnzahlTeams / 2) - 1;
                //Zwei Array füllen mit Joker an fester Stelle
                for (int i = 0; i < AnzahlTeams / 2; i++)
                {
                    if (i == 0) ContainerB[i] = Joker;
                    else ContainerB[i] = TeamsOhneJoker[AnzahlTeams - 1 - i];
                    ContainerA[i] = TeamsOhneJoker[i];
                }
                //Spiele des Spieltag erstellen
                for (int i = 0; i < AnzahlTeams / 2; i++)
                {
                    if (ContainerA[i].Bezeichnung != "BYE" && ContainerB[i].Bezeichnung != "BYE")
                    {
                        PaarungenSpieltag.Spiel.Add(new Spiel(Spielnummer, ContainerA[i], ContainerB[i], Form));
                        Spielnummer++;
                    }
                }
                Spielplan.Spieltag.Add(PaarungenSpieltag);

                //Container Shift clockwise ohne Joker
                Mannschaft Temp = new Mannschaft();
                for (int i = 0; i < TeamsOhneJoker.Length; i++)
                {
                    if (i == 0) Temp = TeamsOhneJoker[i];
                    else TeamsOhneJoker[i - 1] = TeamsOhneJoker[i];
                    if (i == TeamsOhneJoker.Length - 1) TeamsOhneJoker[i] = Temp;
                }
            }
        }

        private void KoRunde()
        {
            int Spielnummer = (Spielplan.Spieltag.Count == 0) ? 1 : Spielplan.Spieltag.Last().Spiel.Last().Nummer + 1;
            int AnzahlTeams = Spielplan.Spieltag.Count > 0 ? Spielplan.Spieltag.Last().GetGewinner().Count : Teams.Count;

            try
            {
                Spieltag s = new Spieltag();
                if (Spielnummer <= 1) //Erste KO-Runde
                {
                    for (int i = 0; i < AnzahlTeams / 2; i++)
                    {
                        if (Teams[AnzahlTeams - i - 1].Bezeichnung != "BYE" || Teams[i].Bezeichnung != "BYE")
                        {
                            s.Spiel.Add(new Spiel(Spielnummer, Teams[AnzahlTeams - i - 1], Teams[i], Form));
                            Spielnummer++;
                        }
                    }
                }
                else //n-te KO-Runde
                {
                    List<Mannschaft> Gewinner = Spielplan.Spieltag.Last().GetGewinner();
                    for (int i = 0; i < Gewinner.Count / 2; i++)
                    {
                        //Nur Spiel erstellen wenn beide Teams nicht BYE
                        if (Gewinner[i].Bezeichnung != "BYE" && Gewinner[AnzahlTeams - i - 1].Bezeichnung != "BYE")
                        {
                            s.Spiel.Add(new Spiel(Spielnummer, Gewinner[i], Gewinner[AnzahlTeams - i - 1], Form));
                            Spielnummer++;
                        }
                    }
                }
                Spielplan.Hinzufuegen(s);
            }
            catch (Exception e)
            {
                string FehlerString = AnzahlTeams == 1 ? "Gewinner steht fest" : e.Message;
            }
        }

        public List<Mannschaft> GetGewinner()
        {
            if (Form == 1)
            {
                if (IstAbgeschlossen())
                {
                    Tabelle.Aktualisieren();
                    List<Mannschaft> gewinner = new List<Mannschaft>();
                    for (int i = 0; i < AnzahlGewinner; i++) gewinner.Add(Tabelle.Platzierung[i].Team);
                    return gewinner;
                }
            }
            else if (IstAbgeschlossen()) return Spielplan.Spieltag.Last().GetGewinner();
            return new List<Mannschaft>();
        }

        public bool IstAbgeschlossen()
        {
            bool Abgeschlossen = false;
            if (Form == 1 || Form == 3)
            {
                Abgeschlossen = Spielplan.Abgeschlossen() ? true : false;
            }
            if (Form == 2)
            {
                Abgeschlossen = Spielplan.Spieltag.Last().GetGewinner().Count == AnzahlGewinner ? true : false;
            }
            return Abgeschlossen;
        }        
    }
}
