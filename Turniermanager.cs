using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turniermanager
{
    public partial class Turniermanager : Form
    {
        TurnierErstellen NeuesTurnier = new TurnierErstellen();
        Turnier t;
        List<AnzeigeSpiel> s = new List<AnzeigeSpiel>();
        List<Button> Start = new List<Button>();
        List<Button> Tabelle = new List<Button>();
        List<Label> GruppenLabel = new List<Label>();
        public Turniermanager()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void erstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeuesTurnier = new TurnierErstellen();
            Button b = new Button
            {
                Location = new Point(91, 188),
                Size = new Size(200, 23),
                Text = "Turnier Erstellen",
                Parent = NeuesTurnier
            };
            b.Click += ButtonTurnierErstellen_Click;
            NeuesTurnier.ShowDialog();
        }

        private void ButtonTurnierErstellen_Click(object sender, EventArgs e)
        {
            t = new Turnier(NeuesTurnier.GetBezeichnung(), NeuesTurnier.GetTurnierform(), NeuesTurnier.GetTeilnehmerString(), NeuesTurnier.GetAnzahlGruppen());
            NeuesTurnier.Dispose();
            SpielplanAnzeigen();
        }

        private void SpielplanAnzeigen()
        {
            label1.Text = t.Bezeichnung;
            foreach (AnzeigeSpiel i in s) i.Dispose();
            foreach (Button i in Start) i.Dispose();
            foreach (Label i in GruppenLabel) i.Dispose();
            s.Clear();
            int index = -1;
            int x = 10; int y = 100; int breite = this.ClientSize.Width - 30;
            foreach (Gruppe g in t.Gruppen)
            {
                index++;
                Label l = new Label
                {
                    Name = index.ToString(),
                    Location = new Point(x, y + 5),
                    Text = g.Phase != 2 ? "Gruppe " + Convert.ToChar('A' + index) : "Playoffs",
                    AutoSize = true,
                    Parent = this,
                };
                GruppenLabel.Add(l);
                foreach (Spieltag i in g.Spielplan.Spieltag)
                {
                    y += 27;
                    foreach (Spiel j in i.Spiel)
                    {
                        string bez = g.Phase != 2 ? "Gruppe " + Convert.ToChar('A' + index) : "Playoffs";
                        s.Add(new AnzeigeSpiel(bez,j, this, x, y, breite));
                        y += 27;
                    }
                }
                //Nächste KO-Runde Button
                if (g.Form == 2)
                {
                    Button b = new Button
                    {
                        Name = index.ToString(),
                        Location = new Point(x, y),
                        Text = "Nächste Runde Starten",
                        AutoSize = true,
                        Parent = this,
                    };
                    b.Click += StartClick;
                    Start.Add(b);
                    y += 27;
                }
                //Tabelle anzeigen Button
                if (g.Form == 1 || g.Form == 3 && g.Phase != 2)
                {
                    Button b = new Button
                    {
                        Name = index.ToString(),
                        Location = new Point(x, y),
                        Text = "Tabelle " + l.Text,
                        AutoSize = true,
                        Parent = this,
                    };
                    b.Click += TabelleAnzeigenClick;
                    Start.Add(b);
                    y += 27 * 2;
                }
            }
            //Playoffs starten Button
            if (t.Form == 3 && t.Gruppen.Last().Phase != 2)
            {
                Button b = new Button
                {
                    Name = "-1",
                    Location = new Point(x, y),
                    Text = "Nächste Runde Starten (Playoffs)",
                    AutoSize = true,
                    Parent = this,
                };
                b.Click += StartClick;
                Start.Add(b);
                y += 27;
            }
        }

        private void TabelleAnzeigenClick(object sender, EventArgs e)
        {
            //Tabelle Anzeigen ButtonClick
            Button index = (Button)sender;
            int tt = Convert.ToInt32(index.Name);
            t.Gruppen[Convert.ToInt32(index.Name)].Tabelle.Aktualisieren();
            MessageBox.Show("Tabelle Gruppe " + Convert.ToChar('A' + Convert.ToInt32(index.Name)) + "\n\n" + t.Gruppen[Convert.ToInt32(index.Name)].Tabelle.ToString());
        }



        private void StartClick(object sender, EventArgs e)
        {
            //Nächste Runde starten ButtonClick
            Button index = (Button)sender;
            try
            {
                if (Convert.ToInt32(index.Name) == -1)
                {

                    bool abges = true;
                    foreach (Gruppe i in t.Gruppen) if (!i.IstAbgeschlossen()) abges = false;
                    if (abges) { t.NaechsteRunde(); SpielplanAnzeigen(); }
                    else MessageBox.Show("Letzte Runde ist noch nicht abgeschlossen! Bitte alle Ergebnisse eintragen.");
                }
                else
                {
                    t.Gruppen[Convert.ToInt32(index.Name)].Start();
                    SpielplanAnzeigen();
                }
            }
            catch (Exception Ex)
            {
                if (t.Gruppen[Convert.ToInt32(index.Name)].Spielplan.Spieltag.Last().Abgeschlossen()) MessageBox.Show(Ex.Message);
                else MessageBox.Show("Letzte Runde ist noch nicht abgeschlossen! Bitte alle Ergebnisse eintragen.");
            }
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Import Turnier                      
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "turnier files (*.turnier)|*.turnier|All files (*.*)|*.*"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                t = new Turnier(openFileDialog1.FileName);
            SpielplanAnzeigen();
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export Turnier
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "turnier files (*.turnier)|*.turnier|All files (*.*)|*.*",
                FileName = t.Bezeichnung,
                Title = "Turnier speichern"
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                t.ExportXML(saveFileDialog1.FileName);
        }
    }
}
