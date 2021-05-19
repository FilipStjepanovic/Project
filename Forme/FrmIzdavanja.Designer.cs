namespace Forme
{
    partial class FrmIzdavanja
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
            this.dgvIzdavanja = new System.Windows.Forms.DataGridView();
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.btnDeaktiviraj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzdavanja)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izdavanja";
            // 
            // dgvIzdavanja
            // 
            this.dgvIzdavanja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzdavanja.Location = new System.Drawing.Point(50, 92);
            this.dgvIzdavanja.Name = "dgvIzdavanja";
            this.dgvIzdavanja.ReadOnly = true;
            this.dgvIzdavanja.RowHeadersWidth = 62;
            this.dgvIzdavanja.RowTemplate.Height = 28;
            this.dgvIzdavanja.Size = new System.Drawing.Size(841, 348);
            this.dgvIzdavanja.TabIndex = 1;
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.Location = new System.Drawing.Point(966, 149);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(187, 51);
            this.btnKreiraj.TabIndex = 2;
            this.btnKreiraj.Text = "Kreiraj izdavanje";
            this.btnKreiraj.UseVisualStyleBackColor = true;
            this.btnKreiraj.Click += new System.EventHandler(this.btnKreiraj_Click);
            // 
            // btnDeaktiviraj
            // 
            this.btnDeaktiviraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeaktiviraj.Location = new System.Drawing.Point(966, 261);
            this.btnDeaktiviraj.Name = "btnDeaktiviraj";
            this.btnDeaktiviraj.Size = new System.Drawing.Size(187, 63);
            this.btnDeaktiviraj.TabIndex = 3;
            this.btnDeaktiviraj.Text = "Deaktiviraj izdavanje";
            this.btnDeaktiviraj.UseVisualStyleBackColor = false;
            this.btnDeaktiviraj.Click += new System.EventHandler(this.btnDeaktiviraj_Click);
            // 
            // FrmIzdavanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 488);
            this.Controls.Add(this.btnDeaktiviraj);
            this.Controls.Add(this.btnKreiraj);
            this.Controls.Add(this.dgvIzdavanja);
            this.Controls.Add(this.label1);
            this.Name = "FrmIzdavanja";
            this.Text = "FrmIzdavanja";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzdavanja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvIzdavanja;
        private System.Windows.Forms.Button btnKreiraj;
        private System.Windows.Forms.Button btnDeaktiviraj;
    }
}