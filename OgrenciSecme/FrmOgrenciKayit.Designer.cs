﻿namespace OgrenciSecme
{
    partial class FrmOgrenciKayit
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
            this.cmbDonem = new System.Windows.Forms.ComboBox();
            this.cmbDers = new System.Windows.Forms.ComboBox();
            this.cmbGrup = new System.Windows.Forms.ComboBox();
            this.yukle = new System.Windows.Forms.Button();
            this.dosyaSecme = new System.Windows.Forms.Button();
            this.gostermeDgv = new System.Windows.Forms.DataGridView();
            this.kayitLbl = new System.Windows.Forms.Label();
            this.cmbBolognaYil = new System.Windows.Forms.ComboBox();
            this.tlpKayitDonem = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gostermeDgv)).BeginInit();
            this.tlpKayitDonem.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDonem
            // 
            this.cmbDonem.FormattingEnabled = true;
            this.cmbDonem.Location = new System.Drawing.Point(3, 64);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Size = new System.Drawing.Size(223, 21);
            this.cmbDonem.TabIndex = 0;
            this.cmbDonem.SelectedIndexChanged += new System.EventHandler(this.donemCmb_SelectedIndexChanged);
            // 
            // cmbDers
            // 
            this.cmbDers.FormattingEnabled = true;
            this.cmbDers.Location = new System.Drawing.Point(3, 125);
            this.cmbDers.Name = "cmbDers";
            this.cmbDers.Size = new System.Drawing.Size(223, 21);
            this.cmbDers.TabIndex = 1;
            this.cmbDers.SelectedIndexChanged += new System.EventHandler(this.dersCmb_SelectedIndexChanged);
            // 
            // cmbGrup
            // 
            this.cmbGrup.FormattingEnabled = true;
            this.cmbGrup.Location = new System.Drawing.Point(3, 186);
            this.cmbGrup.Name = "cmbGrup";
            this.cmbGrup.Size = new System.Drawing.Size(223, 21);
            this.cmbGrup.TabIndex = 3;
            this.cmbGrup.SelectedIndexChanged += new System.EventHandler(this.grupCmb_SelectedIndexChanged);
            // 
            // yukle
            // 
            this.yukle.Location = new System.Drawing.Point(123, 391);
            this.yukle.Name = "yukle";
            this.yukle.Size = new System.Drawing.Size(134, 33);
            this.yukle.TabIndex = 4;
            this.yukle.Text = "YÜKLE";
            this.yukle.UseVisualStyleBackColor = true;
            this.yukle.Click += new System.EventHandler(this.yukle_Click);
            // 
            // dosyaSecme
            // 
            this.dosyaSecme.Location = new System.Drawing.Point(78, 354);
            this.dosyaSecme.Name = "dosyaSecme";
            this.dosyaSecme.Size = new System.Drawing.Size(229, 31);
            this.dosyaSecme.TabIndex = 5;
            this.dosyaSecme.Text = "Dosya Sec";
            this.dosyaSecme.UseVisualStyleBackColor = true;
            this.dosyaSecme.Click += new System.EventHandler(this.DosyaSecme_Click);
            // 
            // gostermeDgv
            // 
            this.gostermeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gostermeDgv.Location = new System.Drawing.Point(414, 64);
            this.gostermeDgv.Name = "gostermeDgv";
            this.gostermeDgv.Size = new System.Drawing.Size(484, 343);
            this.gostermeDgv.TabIndex = 6;
            // 
            // kayitLbl
            // 
            this.kayitLbl.AutoSize = true;
            this.kayitLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayitLbl.Location = new System.Drawing.Point(95, 27);
            this.kayitLbl.Name = "kayitLbl";
            this.kayitLbl.Size = new System.Drawing.Size(191, 33);
            this.kayitLbl.TabIndex = 7;
            this.kayitLbl.Text = "Öğrenci Kayıt";
            // 
            // cmbBolognaYil
            // 
            this.cmbBolognaYil.FormattingEnabled = true;
            this.cmbBolognaYil.Location = new System.Drawing.Point(3, 3);
            this.cmbBolognaYil.Name = "cmbBolognaYil";
            this.cmbBolognaYil.Size = new System.Drawing.Size(223, 21);
            this.cmbBolognaYil.TabIndex = 8;
            this.cmbBolognaYil.SelectedIndexChanged += new System.EventHandler(this.cmbBolognaYil_SelectedIndexChanged);
            // 
            // tlpKayitDonem
            // 
            this.tlpKayitDonem.ColumnCount = 1;
            this.tlpKayitDonem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKayitDonem.Controls.Add(this.cmbDonem, 0, 1);
            this.tlpKayitDonem.Controls.Add(this.cmbBolognaYil, 0, 0);
            this.tlpKayitDonem.Controls.Add(this.cmbDers, 0, 2);
            this.tlpKayitDonem.Controls.Add(this.cmbGrup, 0, 3);
            this.tlpKayitDonem.Location = new System.Drawing.Point(78, 89);
            this.tlpKayitDonem.Name = "tlpKayitDonem";
            this.tlpKayitDonem.RowCount = 4;
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.Size = new System.Drawing.Size(229, 244);
            this.tlpKayitDonem.TabIndex = 9;
            // 
            // FrmOgrenciKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 484);
            this.Controls.Add(this.tlpKayitDonem);
            this.Controls.Add(this.kayitLbl);
            this.Controls.Add(this.gostermeDgv);
            this.Controls.Add(this.dosyaSecme);
            this.Controls.Add(this.yukle);
            this.Name = "FrmOgrenciKayit";
            this.Text = "title";
            this.Load += new System.EventHandler(this.FrmOgrenciKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gostermeDgv)).EndInit();
            this.tlpKayitDonem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private const string title = "Öğrenci Kayıt";
        private System.Windows.Forms.ComboBox cmbDonem;
        private System.Windows.Forms.ComboBox cmbDers;
        private System.Windows.Forms.ComboBox cmbGrup;
        private System.Windows.Forms.Button yukle;
        private System.Windows.Forms.Button dosyaSecme;
        private System.Windows.Forms.DataGridView gostermeDgv;
        private System.Windows.Forms.Label kayitLbl;
        private System.Windows.Forms.ComboBox cmbBolognaYil;
        private System.Windows.Forms.TableLayoutPanel tlpKayitDonem;
    }
}

