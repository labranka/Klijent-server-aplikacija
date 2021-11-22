
namespace Klijent
{
	partial class PromeniTermine
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromeniTermine));
			this.cmbSlucaj = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSacuvajIzmene = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.lbl1 = new System.Windows.Forms.Label();
			this.btnIzmeni = new System.Windows.Forms.Button();
			this.btnObrisi = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbSlucaj
			// 
			this.cmbSlucaj.FormattingEnabled = true;
			this.cmbSlucaj.Location = new System.Drawing.Point(12, 12);
			this.cmbSlucaj.Name = "cmbSlucaj";
			this.cmbSlucaj.Size = new System.Drawing.Size(422, 21);
			this.cmbSlucaj.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 107);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Definisani termini";
			// 
			// btnSacuvajIzmene
			// 
			this.btnSacuvajIzmene.Location = new System.Drawing.Point(12, 261);
			this.btnSacuvajIzmene.Name = "btnSacuvajIzmene";
			this.btnSacuvajIzmene.Size = new System.Drawing.Size(425, 39);
			this.btnSacuvajIzmene.TabIndex = 7;
			this.btnSacuvajIzmene.Text = "Sacuvaj izmene";
			this.btnSacuvajIzmene.UseVisualStyleBackColor = true;
			this.btnSacuvajIzmene.Click += new System.EventHandler(this.btnSacuvajIzmene_Click);
			// 
			// dataGridView1
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOliveGreen;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 123);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(425, 104);
			this.dataGridView1.TabIndex = 5;
			// 
			// lbl1
			// 
			this.lbl1.AutoSize = true;
			this.lbl1.Location = new System.Drawing.Point(12, 36);
			this.lbl1.Name = "lbl1";
			this.lbl1.Size = new System.Drawing.Size(44, 13);
			this.lbl1.TabIndex = 10;
			this.lbl1.Text = "Korisnik";
			// 
			// btnIzmeni
			// 
			this.btnIzmeni.Location = new System.Drawing.Point(318, 39);
			this.btnIzmeni.Name = "btnIzmeni";
			this.btnIzmeni.Size = new System.Drawing.Size(116, 23);
			this.btnIzmeni.TabIndex = 12;
			this.btnIzmeni.Text = "Prikazi termine";
			this.btnIzmeni.UseVisualStyleBackColor = true;
			this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
			// 
			// btnObrisi
			// 
			this.btnObrisi.Location = new System.Drawing.Point(12, 232);
			this.btnObrisi.Name = "btnObrisi";
			this.btnObrisi.Size = new System.Drawing.Size(425, 23);
			this.btnObrisi.TabIndex = 13;
			this.btnObrisi.Text = "Obrisi termin";
			this.btnObrisi.UseVisualStyleBackColor = true;
			this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
			// 
			// PromeniTermine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 300);
			this.Controls.Add(this.btnObrisi);
			this.Controls.Add(this.btnIzmeni);
			this.Controls.Add(this.lbl1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSacuvajIzmene);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.cmbSlucaj);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PromeniTermine";
			this.Text = "PromeniTermine";
			this.Load += new System.EventHandler(this.PromeniTermine_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbSlucaj;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSacuvajIzmene;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.Button btnIzmeni;
		private System.Windows.Forms.Button btnObrisi;
	}
}