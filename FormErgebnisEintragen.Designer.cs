namespace Turniermanager
{
    partial class FormErgebnisEintragen
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TeamA = new System.Windows.Forms.Label();
            this.gegen = new System.Windows.Forms.Label();
            this.TeamB = new System.Windows.Forms.Label();
            this.ErgebnisA = new System.Windows.Forms.TextBox();
            this.ErgebnisB = new System.Windows.Forms.TextBox();
            this.Eintragen = new System.Windows.Forms.Button();
            this.Nummer = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
            this.tableLayoutPanel1.Controls.Add(this.TeamA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gegen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TeamB, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ErgebnisA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ErgebnisB, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TeamA
            // 
            this.TeamA.AutoSize = true;
            this.TeamA.Location = new System.Drawing.Point(3, 0);
            this.TeamA.Name = "TeamA";
            this.TeamA.Size = new System.Drawing.Size(41, 13);
            this.TeamA.TabIndex = 0;
            this.TeamA.Text = "TeamA";
            // 
            // gegen
            // 
            this.gegen.AutoSize = true;
            this.gegen.Location = new System.Drawing.Point(98, 0);
            this.gegen.Name = "gegen";
            this.gegen.Size = new System.Drawing.Size(37, 13);
            this.gegen.TabIndex = 1;
            this.gegen.Text = "gegen";
            // 
            // TeamB
            // 
            this.TeamB.AutoSize = true;
            this.TeamB.Location = new System.Drawing.Point(166, 0);
            this.TeamB.Name = "TeamB";
            this.TeamB.Size = new System.Drawing.Size(41, 13);
            this.TeamB.TabIndex = 2;
            this.TeamB.Text = "TeamB";
            // 
            // ErgebnisA
            // 
            this.ErgebnisA.Location = new System.Drawing.Point(3, 33);
            this.ErgebnisA.Name = "ErgebnisA";
            this.ErgebnisA.Size = new System.Drawing.Size(67, 20);
            this.ErgebnisA.TabIndex = 3;
            // 
            // ErgebnisB
            // 
            this.ErgebnisB.Location = new System.Drawing.Point(166, 33);
            this.ErgebnisB.Name = "ErgebnisB";
            this.ErgebnisB.Size = new System.Drawing.Size(69, 20);
            this.ErgebnisB.TabIndex = 4;
            // 
            // Eintragen
            // 
            this.Eintragen.Location = new System.Drawing.Point(146, 129);
            this.Eintragen.Name = "Eintragen";
            this.Eintragen.Size = new System.Drawing.Size(126, 23);
            this.Eintragen.TabIndex = 1;
            this.Eintragen.Text = "Ergebnis Eintragen";
            this.Eintragen.UseVisualStyleBackColor = true;
            this.Eintragen.Click += new System.EventHandler(this.Eintragen_Click);
            // 
            // Nummer
            // 
            this.Nummer.AutoSize = true;
            this.Nummer.Location = new System.Drawing.Point(107, 9);
            this.Nummer.Name = "Nummer";
            this.Nummer.Size = new System.Drawing.Size(70, 13);
            this.Nummer.TabIndex = 2;
            this.Nummer.Text = "Spielnummer:";
            this.Nummer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormErgebnisEintragen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.Nummer);
            this.Controls.Add(this.Eintragen);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormErgebnisEintragen";
            this.Text = "FormErgebnisEintragen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TeamA;
        private System.Windows.Forms.Label gegen;
        private System.Windows.Forms.Label TeamB;
        private System.Windows.Forms.TextBox ErgebnisA;
        private System.Windows.Forms.TextBox ErgebnisB;
        private System.Windows.Forms.Button Eintragen;
        private System.Windows.Forms.Label Nummer;
    }
}