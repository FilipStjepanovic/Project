namespace Forme
{
    partial class FrmKreirajIzdavanje
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAktivno = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.cmbPrimerak = new System.Windows.Forms.ComboBox();
            this.cmbAutomobil = new System.Windows.Forms.ComboBox();
            this.cmbKorisnik = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Automobil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Primerak";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Datum kreiranja";
            // 
            // checkBoxAktivno
            // 
            this.checkBoxAktivno.AutoSize = true;
            this.checkBoxAktivno.Location = new System.Drawing.Point(281, 337);
            this.checkBoxAktivno.Name = "checkBoxAktivno";
            this.checkBoxAktivno.Size = new System.Drawing.Size(87, 24);
            this.checkBoxAktivno.TabIndex = 4;
            this.checkBoxAktivno.Text = "Aktivno";
            this.checkBoxAktivno.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Sacuvaj izdavanje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(248, 267);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(174, 26);
            this.txtDatum.TabIndex = 6;
            // 
            // cmbPrimerak
            // 
            this.cmbPrimerak.FormattingEnabled = true;
            this.cmbPrimerak.Location = new System.Drawing.Point(247, 199);
            this.cmbPrimerak.Name = "cmbPrimerak";
            this.cmbPrimerak.Size = new System.Drawing.Size(175, 28);
            this.cmbPrimerak.TabIndex = 7;
            // 
            // cmbAutomobil
            // 
            this.cmbAutomobil.FormattingEnabled = true;
            this.cmbAutomobil.Location = new System.Drawing.Point(248, 127);
            this.cmbAutomobil.Name = "cmbAutomobil";
            this.cmbAutomobil.Size = new System.Drawing.Size(175, 28);
            this.cmbAutomobil.TabIndex = 8;
            this.cmbAutomobil.SelectedIndexChanged += new System.EventHandler(this.cmbAutomobil_SelectedIndexChanged);
            // 
            // cmbKorisnik
            // 
            this.cmbKorisnik.FormattingEnabled = true;
            this.cmbKorisnik.Location = new System.Drawing.Point(248, 55);
            this.cmbKorisnik.Name = "cmbKorisnik";
            this.cmbKorisnik.Size = new System.Drawing.Size(175, 28);
            this.cmbKorisnik.TabIndex = 9;
            // 
            // FrmKreirajIzdavanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 472);
            this.Controls.Add(this.cmbKorisnik);
            this.Controls.Add(this.cmbAutomobil);
            this.Controls.Add(this.cmbPrimerak);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxAktivno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmKreirajIzdavanje";
            this.Text = "FrmKreirajIzdavanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAktivno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.ComboBox cmbPrimerak;
        private System.Windows.Forms.ComboBox cmbAutomobil;
        private System.Windows.Forms.ComboBox cmbKorisnik;
    }
}