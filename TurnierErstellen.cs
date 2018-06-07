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
    public partial class TurnierErstellen : Form
    {
        string bezeichnung = "";

        public TurnierErstellen()
        {
            InitializeComponent();
        }

        private void ButtonTurnierErstellen_Click(object sender, EventArgs e)
        {
            Bezeichnung.Text = "";
            TeilnehmerString.Text = "";

        }

        public string GetBezeichnung() { return Bezeichnung.Text; }

        public int GetTurnierform() { return Turnierform.SelectedIndex + 1; }

        public string GetTeilnehmerString() { return TeilnehmerString.Text; }

        public int GetAnzahlGruppen()
        {
            if (Turnierform.SelectedIndex == 2) return Convert.ToInt32(AnzahlGruppen.Text);
            else return 1;
        }

        private void Turnierform_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnzahlGruppen.Enabled = Turnierform.SelectedIndex == 2 ? true : false;
        }
    }
}
