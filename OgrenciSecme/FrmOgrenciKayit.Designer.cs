namespace OgrenciSecme
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gostermeDgv)).BeginInit();
            this.tlpKayitDonem.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBolognaYil
            // 
            this.cmbBolognaYil.FormattingEnabled = true;
            this.cmbBolognaYil.Location = new System.Drawing.Point(3, 3);
            this.cmbBolognaYil.Name = "cmbBolognaYil";
            this.cmbBolognaYil.Size = new System.Drawing.Size(223, 21);
            this.cmbBolognaYil.TabIndex = 8;
            this.cmbBolognaYil.Text = "Bologna Yıl Seçiniz";
            this.cmbBolognaYil.SelectedIndexChanged += new System.EventHandler(this.cmbBolognaYil_SelectedIndexChanged);
            // 
            // cmbDonem
            // 
            this.cmbDonem.FormattingEnabled = true;
            this.cmbDonem.Location = new System.Drawing.Point(3, 64);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDonem.Size = new System.Drawing.Size(223, 21);
            this.cmbDonem.TabIndex = 0;
            this.cmbDonem.Text = "Donem Seçiniz";
            this.cmbDonem.SelectedIndexChanged += new System.EventHandler(this.cmbDonem_SelectedIndexChanged);
            // 
            // cmbDers
            // 
            this.cmbDers.FormattingEnabled = true;
            this.cmbDers.Location = new System.Drawing.Point(3, 125);
            this.cmbDers.Name = "cmbDers";
            this.cmbDers.Size = new System.Drawing.Size(223, 21);
            this.cmbDers.TabIndex = 1;
            this.cmbDers.Text = "Ders Seçiniz";
            this.cmbDers.SelectedIndexChanged += new System.EventHandler(this.cmbDers_SelectedIndexChanged);
            // 
            // cmbGrup
            // 
            this.cmbGrup.FormattingEnabled = true;
            this.cmbGrup.Location = new System.Drawing.Point(3, 186);
            this.cmbGrup.Name = "cmbGrup";
            this.cmbGrup.Size = new System.Drawing.Size(223, 21);
            this.cmbGrup.TabIndex = 3;
            this.cmbGrup.Text = "Grup Seçiniz";
            this.cmbGrup.SelectedIndexChanged += new System.EventHandler(this.cmbGrup_SelectedIndexChanged);
            // 
            // yukle
            // 
            this.yukle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yukle.Location = new System.Drawing.Point(39, 53);
            this.yukle.Name = "yukle";
            this.yukle.Size = new System.Drawing.Size(106, 33);
            this.yukle.TabIndex = 4;
            this.yukle.Text = "YÜKLE";
            this.yukle.UseVisualStyleBackColor = true;
            this.yukle.Click += new System.EventHandler(this.Yukle_Click);
            // 
            // dosyaSecme
            // 
            this.dosyaSecme.Location = new System.Drawing.Point(3, 3);
            this.dosyaSecme.Name = "dosyaSecme";
            this.dosyaSecme.Size = new System.Drawing.Size(179, 31);
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
            this.kayitLbl.Location = new System.Drawing.Point(92, 24);
            this.kayitLbl.Name = "kayitLbl";
            this.kayitLbl.Size = new System.Drawing.Size(191, 33);
            this.kayitLbl.TabIndex = 7;
            this.kayitLbl.Text = "Öğrenci Kayıt";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.yukle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dosyaSecme, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(98, 353);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 100);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // FrmOgrenciKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 484);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpKayitDonem);
            this.Controls.Add(this.kayitLbl);
            this.Controls.Add(this.gostermeDgv);
            this.Name = "FrmOgrenciKayit";
            this.Text = "title";
            this.Load += new System.EventHandler(this.FrmOgrenciKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gostermeDgv)).EndInit();
            this.tlpKayitDonem.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

