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
    public partial class FormErgebnisEintragen : Form
    {
        public FormErgebnisEintragen(string bez, int nr, string a, string b)
        {
            InitializeComponent();
            TeamA.Text = a;
            TeamB.Text = b;
            Nummer.Text = bez + "\nSpielnummer: " + nr;
        }

        public int[] GetErgebnis()
        {
            int[] Erg = new int[2];
            Erg[0] = Convert.ToInt32(ErgebnisA.Text);
            Erg[1] = Convert.ToInt32(ErgebnisB.Text);
            return Erg;
        }

        private void Eintragen_Click(object sender, EventArgs e)
        {
            try { Convert.ToInt32(ErgebnisA.Text); Convert.ToInt32(ErgebnisB.Text); this.Hide(); }
            catch { MessageBox.Show("Bitte Ergebnis eintragen"); }
        }
    }
}
