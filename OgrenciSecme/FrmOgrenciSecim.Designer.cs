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
            this.cmbDers = new System.Windows.Forms.ComboBox();
            this.cmbDonem = new System.Windows.Forms.ComboBox();
            this.cmbGrup = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSecimOgr = new System.Windows.Forms.Button();
            this.btnGetirOgr = new System.Windows.Forms.Button();
            this.btnSecilenTemizle = new System.Windows.Forms.Button();
            this.btnGorunenTemizle = new System.Windows.Forms.Button();
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
            // cmbDers
            // 
            this.cmbDers.FormattingEnabled = true;
            this.cmbDers.Location = new System.Drawing.Point(468, 206);
            this.cmbDers.Name = "cmbDers";
            this.cmbDers.Size = new System.Drawing.Size(202, 21);
            this.cmbDers.TabIndex = 3;
            this.cmbDers.SelectedIndexChanged += new System.EventHandler(this.cmbDers_SelectedIndexChanged);
            // 
            // cmbDonem
            // 
            this.cmbDonem.FormattingEnabled = true;
            this.cmbDonem.Location = new System.Drawing.Point(468, 134);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Size = new System.Drawing.Size(202, 21);
            this.cmbDonem.TabIndex = 6;
            this.cmbDonem.SelectedIndexChanged += new System.EventHandler(this.cmbDonem_SelectedIndexChanged);
            // 
            // cmbGrup
            // 
            this.cmbGrup.FormattingEnabled = true;
            this.cmbGrup.Location = new System.Drawing.Point(468, 279);
            this.cmbGrup.Name = "cmbGrup";
            this.cmbGrup.Size = new System.Drawing.Size(202, 21);
            this.cmbGrup.TabIndex = 4;
            this.cmbGrup.SelectedIndexChanged += new System.EventHandler(this.cmbGrup_SelectedIndexChanged);
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
            // btnSecimOgr
            // 
            this.btnSecimOgr.Location = new System.Drawing.Point(468, 463);
            this.btnSecimOgr.Name = "btnSecimOgr";
            this.btnSecimOgr.Size = new System.Drawing.Size(202, 39);
            this.btnSecimOgr.TabIndex = 9;
            this.btnSecimOgr.Text = "Rastgele Seç";
            this.btnSecimOgr.UseVisualStyleBackColor = true;
            // 
            // btnGetirOgr
            // 
            this.btnGetirOgr.Location = new System.Drawing.Point(468, 381);
            this.btnGetirOgr.Name = "btnGetirOgr";
            this.btnGetirOgr.Size = new System.Drawing.Size(202, 39);
            this.btnGetirOgr.TabIndex = 10;
            this.btnGetirOgr.Text = "Sırala";
            this.btnGetirOgr.UseVisualStyleBackColor = true;
            this.btnGetirOgr.Click += new System.EventHandler(this.btnGetirOgr_Click);
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
            // FrmOgrenciSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 601);
            this.Controls.Add(this.btnGorunenTemizle);
            this.Controls.Add(this.btnSecilenTemizle);
            this.Controls.Add(this.btnGetirOgr);
            this.Controls.Add(this.btnSecimOgr);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbDonem);
            this.Controls.Add(this.cmbGrup);
            this.Controls.Add(this.cmbDers);
            this.Controls.Add(this.lstSecilenOgr);
            this.Controls.Add(this.lstGorunenOgr);
            this.Name = "FrmOgrenciSecim";
            this.Text = "FrmOgrenciSecim";
            this.Load += new System.EventHandler(this.FrmOgrenciSecim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private const string title = "Öğrenci Secim";
        private System.Windows.Forms.ListBox lstGorunenOgr;
        private System.Windows.Forms.ListBox lstSecilenOgr;
        private System.Windows.Forms.ComboBox cmbDers;
        private System.Windows.Forms.ComboBox cmbDonem;
        private System.Windows.Forms.ComboBox cmbGrup;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSecimOgr;
        private System.Windows.Forms.Button btnGetirOgr;
        private System.Windows.Forms.Button btnSecilenTemizle;
        private System.Windows.Forms.Button btnGorunenTemizle;
    }
}