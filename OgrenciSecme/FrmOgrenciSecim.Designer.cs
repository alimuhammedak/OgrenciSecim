namespace OgrenciSecme
{
    partial class FrmOgrenciSecim
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
            this.lstGorunenOgr = new System.Windows.Forms.ListBox();
            this.lstSecilenOgr = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRasgeleOgr = new System.Windows.Forms.Button();
            this.btnSecilenSirala = new System.Windows.Forms.Button();
            this.btnSecilenTemizle = new System.Windows.Forms.Button();
            this.btnGorunenTemizle = new System.Windows.Forms.Button();
            this.tlpKayitDonem = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDonem = new System.Windows.Forms.ComboBox();
            this.cmbDers = new System.Windows.Forms.ComboBox();
            this.cmbBolognaYil = new System.Windows.Forms.ComboBox();
            this.cmbGrup = new System.Windows.Forms.ComboBox();
            this.btnTumSirala = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpKayitDonem.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGorunenOgr
            // 
            this.lstGorunenOgr.FormattingEnabled = true;
            this.lstGorunenOgr.Location = new System.Drawing.Point(89, 56);
            this.lstGorunenOgr.Name = "lstGorunenOgr";
            this.lstGorunenOgr.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstGorunenOgr.Size = new System.Drawing.Size(312, 446);
            this.lstGorunenOgr.TabIndex = 0;
            // 
            // lstSecilenOgr
            // 
            this.lstSecilenOgr.FormattingEnabled = true;
            this.lstSecilenOgr.Location = new System.Drawing.Point(718, 56);
            this.lstSecilenOgr.Name = "lstSecilenOgr";
            this.lstSecilenOgr.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstSecilenOgr.Size = new System.Drawing.Size(312, 446);
            this.lstSecilenOgr.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(462, 56);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 33);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Öğrenci Seçim";
            // 
            // btnRasgeleOgr
            // 
            this.btnRasgeleOgr.Location = new System.Drawing.Point(3, 123);
            this.btnRasgeleOgr.Name = "btnRasgeleOgr";
            this.btnRasgeleOgr.Size = new System.Drawing.Size(196, 39);
            this.btnRasgeleOgr.TabIndex = 9;
            this.btnRasgeleOgr.Text = "Rastgele Seç";
            this.btnRasgeleOgr.UseVisualStyleBackColor = true;
            // 
            // btnSecilenSirala
            // 
            this.btnSecilenSirala.Location = new System.Drawing.Point(3, 3);
            this.btnSecilenSirala.Name = "btnSecilenSirala";
            this.btnSecilenSirala.Size = new System.Drawing.Size(196, 39);
            this.btnSecilenSirala.TabIndex = 10;
            this.btnSecilenSirala.Text = "Secilen Sırala";
            this.btnSecilenSirala.UseVisualStyleBackColor = true;
            this.btnSecilenSirala.Click += new System.EventHandler(this.btnGetirOgr_Click);
            // 
            // btnSecilenTemizle
            // 
            this.btnSecilenTemizle.Location = new System.Drawing.Point(769, 530);
            this.btnSecilenTemizle.Name = "btnSecilenTemizle";
            this.btnSecilenTemizle.Size = new System.Drawing.Size(202, 39);
            this.btnSecilenTemizle.TabIndex = 11;
            this.btnSecilenTemizle.Text = "Temizle";
            this.btnSecilenTemizle.UseVisualStyleBackColor = true;
            this.btnSecilenTemizle.Click += new System.EventHandler(this.btnSecilenTemizle_Click);
            // 
            // btnGorunenTemizle
            // 
            this.btnGorunenTemizle.Location = new System.Drawing.Point(133, 530);
            this.btnGorunenTemizle.Name = "btnGorunenTemizle";
            this.btnGorunenTemizle.Size = new System.Drawing.Size(202, 39);
            this.btnGorunenTemizle.TabIndex = 12;
            this.btnGorunenTemizle.Text = "Temizle";
            this.btnGorunenTemizle.UseVisualStyleBackColor = true;
            this.btnGorunenTemizle.Click += new System.EventHandler(this.btnGorunenTemizle_Click);
            // 
            // tlpKayitDonem
            // 
            this.tlpKayitDonem.ColumnCount = 1;
            this.tlpKayitDonem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKayitDonem.Controls.Add(this.cmbDonem, 0, 1);
            this.tlpKayitDonem.Controls.Add(this.cmbDers, 0, 2);
            this.tlpKayitDonem.Controls.Add(this.cmbBolognaYil, 0, 0);
            this.tlpKayitDonem.Controls.Add(this.cmbGrup, 0, 3);
            this.tlpKayitDonem.Location = new System.Drawing.Point(454, 113);
            this.tlpKayitDonem.Name = "tlpKayitDonem";
            this.tlpKayitDonem.RowCount = 4;
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKayitDonem.Size = new System.Drawing.Size(229, 244);
            this.tlpKayitDonem.TabIndex = 13;
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
            // btnTumSirala
            // 
            this.btnTumSirala.Location = new System.Drawing.Point(3, 63);
            this.btnTumSirala.Name = "btnTumSirala";
            this.btnTumSirala.Size = new System.Drawing.Size(196, 39);
            this.btnTumSirala.TabIndex = 14;
            this.btnTumSirala.Text = "Tümünü Sırala";
            this.btnTumSirala.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSecilenSirala, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTumSirala, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRasgeleOgr, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(468, 402);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(202, 167);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // FrmOgrenciSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpKayitDonem);
            this.Controls.Add(this.btnGorunenTemizle);
            this.Controls.Add(this.btnSecilenTemizle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstSecilenOgr);
            this.Controls.Add(this.lstGorunenOgr);
            this.Name = "FrmOgrenciSecim";
            this.Text = "FrmOgrenciSecim";
            this.Load += new System.EventHandler(this.FrmOgrenciSecim_Load);
            this.tlpKayitDonem.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private const string title = "Öğrenci Secim";
        private System.Windows.Forms.ListBox lstGorunenOgr;
        private System.Windows.Forms.ListBox lstSecilenOgr;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRasgeleOgr;
        private System.Windows.Forms.Button btnSecilenSirala;
        private System.Windows.Forms.Button btnSecilenTemizle;
        private System.Windows.Forms.Button btnGorunenTemizle;
        private System.Windows.Forms.TableLayoutPanel tlpKayitDonem;
        private System.Windows.Forms.ComboBox cmbDonem;
        private System.Windows.Forms.ComboBox cmbDers;
        private System.Windows.Forms.ComboBox cmbBolognaYil;
        private System.Windows.Forms.ComboBox cmbGrup;
        private System.Windows.Forms.Button btnTumSirala;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}