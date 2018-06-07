namespace Turniermanager
{
    partial class TurnierErstellen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Turnierform = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TeilnehmerString = new System.Windows.Forms.RichTextBox();
            this.Bezeichnung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AnzahlGruppen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Turnierform
            // 
            this.Turnierform.FormattingEnabled = true;
            this.Turnierform.Items.AddRange(new object[] {
            "Liga",
            "K.O.-System",
            "Kombi"});
            this.Turnierform.Location = new System.Drawing.Point(130, 134);
            this.Turnierform.Name = "Turnierform";
            this.Turnierform.Size = new System.Drawing.Size(121, 21);
            this.Turnierform.TabIndex = 12;
            this.Turnierform.SelectedIndexChanged += new System.EventHandler(this.Turnierform_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Turnierform";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Team/Spieler";
            // 
            // TeilnehmerString
            // 
            this.TeilnehmerString.Location = new System.Drawing.Point(91, 48);
            this.TeilnehmerString.Name = "TeilnehmerString";
            this.TeilnehmerString.Size = new System.Drawing.Size(200, 80);
            this.TeilnehmerString.TabIndex = 9;
            this.TeilnehmerString.Text = "";
            // 
            // Bezeichnung
            // 
            this.Bezeichnung.Location = new System.Drawing.Point(91, 22);
            this.Bezeichnung.Name = "Bezeichnung";
            this.Bezeichnung.Size = new System.Drawing.Size(200, 20);
            this.Bezeichnung.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bezeichnung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anzahl Gruppen";
            // 
            // AnzahlGruppen
            // 
            this.AnzahlGruppen.Enabled = false;
            this.AnzahlGruppen.FormattingEnabled = true;
            this.AnzahlGruppen.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.AnzahlGruppen.Location = new System.Drawing.Point(130, 159);
            this.AnzahlGruppen.Name = "AnzahlGruppen";
            this.AnzahlGruppen.Size = new System.Drawing.Size(121, 21);
            this.AnzahlGruppen.TabIndex = 14;
            // 
            // TurnierErstellen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 231);
            this.Controls.Add(this.AnzahlGruppen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Turnierform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TeilnehmerString);
            this.Controls.Add(this.Bezeichnung);
            this.Controls.Add(this.label1);
            this.Name = "TurnierErstellen";
            this.Text = "TurnierErstellen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox Turnierform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TeilnehmerString;
        private System.Windows.Forms.TextBox Bezeichnung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AnzahlGruppen;
    }
}