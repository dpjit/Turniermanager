using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turniermanager
{
    class AnzeigeSpiel : Panel
    {
        Label Nummer = new Label();
        Label A = new Label();
        Label B = new Label();
        Label Erg = new Label();
        Button ErgebnisEintragen = new Button();
        Spiel spiel;
        string Bezeichnung = string.Empty;
        //bez + "\n
        public AnzeigeSpiel(string bez, Spiel s, Form p, int x, int y, int breite)
        {
            Bezeichnung = bez;
            spiel = s;
            this.Parent = p;
            Nummer.Parent = this;
            A.Parent = this;
            B.Parent = this;
            Erg.Parent = this;
            ErgebnisEintragen.Parent = this;

            Nummer.Text = "#" + spiel.Nummer;
            A.Text = spiel.TeamA.Bezeichnung;
            B.Text = spiel.TeamB.Bezeichnung;
            LabelAktualisieren();

            Nummer.AutoSize = true;
            A.AutoSize = true;
            B.AutoSize = true;
            Erg.AutoSize = true;
            ErgebnisEintragen.AutoSize = true;


            Location = new Point(x, y);
            Size = new Size(breite, 26);
            BorderStyle = BorderStyle.Fixed3D;

            Nummer.Location = new Point(0, 4);
            A.Location = new Point(50, 4);
            B.Location = new Point(((breite - ErgebnisEintragen.Width) / 2) + 50, 4);
            Erg.Location = new Point((breite - ErgebnisEintragen.Width) / 2, 4);
            ErgebnisEintragen.Location = new Point(breite - ErgebnisEintragen.Width - 5, 0);

            if (spiel.Status) ErgebnisEintragen.Text = "Abgeschlossen";
            else ErgebnisEintragen.Click += ErgebnisEintragenCLick;

        }

        private void ErgebnisEintragenCLick(object sender, EventArgs e)
        {            
            FormErgebnisEintragen o = new FormErgebnisEintragen(Bezeichnung,spiel.Nummer,spiel.TeamA.Bezeichnung,spiel.TeamB.Bezeichnung);
            o.ShowDialog();
            try { spiel.ErgebnisEintragen(o.GetErgebnis()[0], o.GetErgebnis()[1]);o.Dispose(); }
            catch(Exception Ex) { MessageBox.Show(Ex.Message); }
            LabelAktualisieren();
        }

        private void LabelAktualisieren()
        {
            Erg.Text = spiel.Status ? spiel.Ergebnis[0].ToString() + ":" + spiel.Ergebnis[1].ToString() : " : ";
            ErgebnisEintragen.Text = spiel.Status ? "Ergebnis ändern": "Ergebnis eintragen";
        }
    }
}
