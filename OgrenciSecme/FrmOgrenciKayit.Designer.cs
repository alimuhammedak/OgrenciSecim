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
            this.donemCmb = new System.Windows.Forms.ComboBox();
            this.dersCmb = new System.Windows.Forms.ComboBox();
            this.grupCmb = new System.Windows.Forms.ComboBox();
            this.yukle = new System.Windows.Forms.Button();
            this.dosyaSecme = new System.Windows.Forms.Button();
            this.gostermeDgv = new System.Windows.Forms.DataGridView();
            this.kayitLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gostermeDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // donemCmb
            // 
            this.donemCmb.FormattingEnabled = true;
            this.donemCmb.Location = new System.Drawing.Point(78, 124);
            this.donemCmb.Name = "donemCmb";
            this.donemCmb.Size = new System.Drawing.Size(229, 21);
            this.donemCmb.TabIndex = 0;
            this.donemCmb.SelectedIndexChanged += new System.EventHandler(this.donemCmb_SelectedIndexChanged);
            // 
            // dersCmb
            // 
            this.dersCmb.FormattingEnabled = true;
            this.dersCmb.Location = new System.Drawing.Point(78, 191);
            this.dersCmb.Name = "dersCmb";
            this.dersCmb.Size = new System.Drawing.Size(229, 21);
            this.dersCmb.TabIndex = 1;
            this.dersCmb.SelectedIndexChanged += new System.EventHandler(this.dersCmb_SelectedIndexChanged);
            // 
            // grupCmb
            // 
            this.grupCmb.FormattingEnabled = true;
            this.grupCmb.Location = new System.Drawing.Point(78, 249);
            this.grupCmb.Name = "grupCmb";
            this.grupCmb.Size = new System.Drawing.Size(229, 21);
            this.grupCmb.TabIndex = 3;
            this.grupCmb.SelectedIndexChanged += new System.EventHandler(this.grupCmb_SelectedIndexChanged);
            // 
            // yukle
            // 
            this.yukle.Location = new System.Drawing.Point(117, 374);
            this.yukle.Name = "yukle";
            this.yukle.Size = new System.Drawing.Size(134, 33);
            this.yukle.TabIndex = 4;
            this.yukle.Text = "YÜKLE";
            this.yukle.UseVisualStyleBackColor = true;
            this.yukle.Click += new System.EventHandler(this.yukle_Click);
            // 
            // dosyaSecme
            // 
            this.dosyaSecme.Location = new System.Drawing.Point(78, 306);
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
            this.kayitLbl.Location = new System.Drawing.Point(95, 64);
            this.kayitLbl.Name = "kayitLbl";
            this.kayitLbl.Size = new System.Drawing.Size(191, 33);
            this.kayitLbl.TabIndex = 7;
            this.kayitLbl.Text = "Öğrenci Kayıt";
            // 
            // FrmOgrenciKayit 
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 484);
            this.Controls.Add(this.kayitLbl);
            this.Controls.Add(this.gostermeDgv);
            this.Controls.Add(this.dosyaSecme);
            this.Controls.Add(this.yukle);
            this.Controls.Add(this.grupCmb);
            this.Controls.Add(this.dersCmb);
            this.Controls.Add(this.donemCmb);
            this.Name = "FrmOgrenciKayit";
            this.Text = "title"; 
            this.Load += new System.EventHandler(this.FrmOgrenciKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gostermeDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private const string title = "Öğrenci Kayıt";
        private System.Windows.Forms.ComboBox donemCmb;
        private System.Windows.Forms.ComboBox dersCmb;
        private System.Windows.Forms.ComboBox grupCmb;
        private System.Windows.Forms.Button yukle;
        private System.Windows.Forms.Button dosyaSecme;
        private System.Windows.Forms.DataGridView gostermeDgv;
        private System.Windows.Forms.Label kayitLbl;
    }
}

