using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Turniermanager
{
    class Turnier
    {
        public string Bezeichnung;
        //public Turnierform Turnierform;
        public List<Mannschaft> Teilnehmer = new List<Mannschaft>();
        public List<Gruppe> Gruppen;
        public int Form = 0;

        public Turnier(string bezeichnung, int form, string teilnehmerstring, int anzahlGruppen)
        {
            Bezeichnung = bezeichnung;
            Form = form;
            string[] teilnehmer = teilnehmerstring.Split(',');
            foreach (string s in teilnehmer) Teilnehmer.Add(new Mannschaft(s));

            Tunierform(Form, anzahlGruppen);
            foreach (Gruppe g in Gruppen) g.Start();
        }

        public Turnier(string dateipfad)
        {
            Gruppen = new List<Gruppe>();
            ImportXML(dateipfad);
        }

        private void Tunierform(int form, int anzahlGruppen)
        {
            Gruppen = new List<Gruppe>();
            switch (form)
            {
                case 1:
                    FuelleTeilnehmerBisUngrade();
                    TeilnehmerInGruppen(1, form, 1);
                    break;
                case 2:
                    FuelleTeilnehmerBisZweierpotenz();
                    TeilnehmerInGruppen(1, form, 1);
                    break;
                case 3:
                    FuelleTeilnehmerBisZweierpotenz();
                    TeilnehmerInGruppen(anzahlGruppen, 1, (Teilnehmer.Count / anzahlGruppen) / 2);
                    break;
            }
        }

        public void ExportXML(string dateipfad)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlAttribute attribute;

            XmlNode TurnierNode = xmlDoc.CreateElement("Turnier");
            xmlDoc.AppendChild(TurnierNode);
            attribute = xmlDoc.CreateAttribute("Bezeichnung");
            attribute.Value = Bezeichnung;
            TurnierNode.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("Form");
            attribute.Value = Form.ToString();
            TurnierNode.Attributes.Append(attribute);
            int z = 0;
            foreach (Mannschaft m in Teilnehmer)
            {
                attribute = xmlDoc.CreateAttribute("Teilnehmer" + z);
                attribute.Value = Teilnehmer[z].Bezeichnung;
                TurnierNode.Attributes.Append(attribute);
                z++;
            }
            foreach (Gruppe a in Gruppen)
            {
                XmlNode GruppeNode = xmlDoc.CreateElement("Gruppe");
                TurnierNode.AppendChild(GruppeNode);

                attribute = xmlDoc.CreateAttribute("Phase");
                attribute.Value = a.Phase.ToString();
                GruppeNode.Attributes.Append(attribute);

                foreach (Mannschaft m in a.Teams)
                {
                    XmlNode TeilnehmerNode = xmlDoc.CreateElement("Teilnehmer");
                    GruppeNode.AppendChild(TeilnehmerNode);
                    attribute = xmlDoc.CreateAttribute("Mannschaft");
                    attribute.Value = m.Bezeichnung;
                    TeilnehmerNode.Attributes.Append(attribute);
                }
                foreach (Spieltag i in a.Spielplan.Spieltag)
                {
                    XmlNode SpieltagNode = xmlDoc.CreateElement("Spieltag");
                    GruppeNode.AppendChild(SpieltagNode);
                    foreach (Spiel j in i.Spiel)
                    {
                        XmlNode SpielNode = xmlDoc.CreateElement("Spiel");
                        SpieltagNode.AppendChild(SpielNode);
                        attribute = xmlDoc.CreateAttribute("Nummer");
                        attribute.Value = j.Nummer.ToString();
                        SpielNode.Attributes.Append(attribute);
                        attribute = xmlDoc.CreateAttribute("TeamA");
                        attribute.Value = j.TeamA.Bezeichnung;
                        SpielNode.Attributes.Append(attribute);
                        attribute = xmlDoc.CreateAttribute("TeamB");
                        attribute.Value = j.TeamB.Bezeichnung;
                        SpielNode.Attributes.Append(attribute);
                        attribute = xmlDoc.CreateAttribute("Ergebnis");
                        attribute.Value = j.Status ? j.Ergebnis[0].ToString() + ":" + j.Ergebnis[1].ToString() : ":";
                        SpielNode.Attributes.Append(attribute);
                    }
                }
            }
            xmlDoc.Save(dateipfad);
        }

        public void ImportXML(string dateipfad)
        {
            XmlReader reader = XmlReader.Create(dateipfad);
            Gruppe g = null;
            int form = 0;
            int phase = 0;
            int AnzahlGewinner = new int();
            Spieltag tag = new Spieltag();
            Spielplan plan = new Spielplan();

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Turnier":
                            Bezeichnung = reader.GetAttribute("Bezeichnung");
                            form = Convert.ToInt32(reader.GetAttribute("Form"));
                            for (int i = 0; i < reader.AttributeCount - 2; i++)
                            {
                                Teilnehmer.Add(new Mannschaft(reader.GetAttribute("Teilnehmer" + i)));
                            }
                            Form = form;
                            break;
                        case "Teilnehmer":
                            //g.Team.Add(new Mannschaft(reader.GetAttribute("Mannschaft")));
                            g.Teams.Add(Teilnehmer.Find(x => x.Bezeichnung.Contains(reader.GetAttribute("Mannschaft"))));
                            break;
                        case "Gruppe":
                            AnzahlGewinner = Convert.ToInt32(reader.GetAttribute("AnzahlGewinner"));
                            phase = Convert.ToInt32(reader.GetAttribute("Phase"));
                            plan = new Spielplan();
                            g = new Gruppe(form, AnzahlGewinner, phase)
                            {
                                Spielplan = plan
                            };
                            break;
                        case "Spieltag":
                            tag = new Spieltag();
                            break;
                        case "Spiel":
                            tag.Spiel.Add(new Spiel(
                                Convert.ToInt32(reader.GetAttribute("Nummer")),
                                reader.GetAttribute("TeamA"),
                                reader.GetAttribute("TeamB"),
                                reader.GetAttribute("Ergebnis"),
                                form));
                            break;
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "Turnier":
                            break;
                        case "Teilnehmer":

                            break;
                        case "Gruppe":
                            Gruppen.Add(g);
                            break;
                        case "Spieltag":
                            plan.Hinzufuegen(tag);
                            break;
                        case "Spiel":
                            break;
                    }
                }
            }
        }

        private void FuelleTeilnehmerBisUngrade()
        {
            if (Teilnehmer.Count % 2 != 0)
                Teilnehmer.Add(new Mannschaft());
        }
        private void FuelleTeilnehmerBisZweierpotenz()
        {
            int ZweierPotenz = NaechsteZweierPotenz(Teilnehmer.Count);
            for (int i = ZweierPotenz - Teilnehmer.Count; i > 0; i--)
                Teilnehmer.Add(new Mannschaft());
        }

        public void NaechsteRunde()
        {
            if (GruppenAbgeschlossen())
            {
                int zaehler = 0;
                List<Mannschaft> GewinnerLetzteRunde = new List<Mannschaft>();
                Mannschaft[] temp = new Mannschaft[Teilnehmer.Count / 2];

                for (int i = 0; i < Gruppen.Count; i += 2)
                {
                    List<Mannschaft> Temp1 = Gruppen[i].GetGewinner();
                    List<Mannschaft> Temp2 = Gruppen[i + 1].GetGewinner();
                    int gew = (Teilnehmer.Count / Gruppen.Count) / 2;
                    for (int j = 0; j < gew; j++)
                    {
                        temp[zaehler] = Temp1[j];
                        temp[(temp.Length - 1) - zaehler] = Temp2[(gew - 1) - j];
                        zaehler++;
                    }
                }
                GewinnerLetzteRunde.Clear(); GewinnerLetzteRunde.AddRange(temp);
                TeilnehmerInGruppen(GewinnerLetzteRunde, 1, 2, 1);
            }
        }

        private void TeilnehmerInGruppen(int anzahlGruppen, int form, int anzahlGewinner)
        {
            for (int i = 0; i <= anzahlGruppen - 1; i++)
            {
                Gruppe g = new Gruppe(form, anzahlGewinner, 1);
                for (int j = 0; j < Teilnehmer.Count / anzahlGruppen; j++) g.Teams.Add(Teilnehmer[i + j * anzahlGruppen]);
                Gruppen.Add(g);
            }
        }

        private bool GruppenAbgeschlossen()
        {
            foreach (Gruppe g in Gruppen) if (!g.IstAbgeschlossen()) return false;
            return true;
        }

        private void TeilnehmerInGruppen(List<Mannschaft> gewinner, int anzahlGruppen, int form, int anzahlGewinner)
        {
            for (int i = 0; i <= anzahlGruppen - 1; i++)
            {
                Gruppe g = new Gruppe(form, anzahlGewinner, 2);
                for (int j = 0; j < gewinner.Count / anzahlGruppen; j++) g.Teams.Add(gewinner[i + j * anzahlGruppen]);
                g.Start();
                Gruppen.Add(g);
            }
        }

        private bool IstZweierPotenz(int x)
        {
            if (x == 0 || x == 1) return false;
            while ((x & 0x01) != 1) x = x >> 0x01;
            if (x == 1) return true;
            return false;
        }

        private int NaechsteZweierPotenz(int x)
        {
            if (x == 0 || x == 1) return 2;
            else
            {
                int ZweierPotenz = 2;
                while (ZweierPotenz < x) ZweierPotenz *= 2;
                return ZweierPotenz;
            }
        }



    }


}
