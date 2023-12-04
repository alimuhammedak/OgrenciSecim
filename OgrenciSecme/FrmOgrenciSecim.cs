using OgrenciSecme.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciSecme.Models.OgrenciSecimModel;
using OgrenciSecme.Models.Validation;
using System.Diagnostics;
using OgrenciSecme.Models.Entities;

namespace OgrenciSecme
{
    public partial class FrmOgrenciSecim : Form
    {
        private SecimMethodModel _model = new SecimMethodModel();
        public FrmOgrenciSecim()
        {
            InitializeComponent();
            using (var dbContext = new SeciciContext())
            {
                //BolognaYil ve Grup combobox'larına veri çekme

                cmbBolognaYil.DataSource = dbContext.BolognaYils.ToList();
                cmbBolognaYil.DisplayMember = "ad";
                //cmbBolognaYil.SelectedIndex = -1;

                cmbGrup.DataSource = dbContext.Grups.ToList();
                cmbGrup.DisplayMember = "ad";

            }
        }

        private void FrmOgrenciSecim_Load(object sender, EventArgs e)
        {
            this.Text = title;
            this.cmbGrup.Hide();
            this.cmbDers.Hide();
            this.cmbDonem.Hide();
        }

        private void btnGorunenTemizle_Click(object sender, EventArgs e)
        {
            lstGorunenOgr.Items.Clear();
        }

        private void btnSecilenTemizle_Click(object sender, EventArgs e)
        {
            lstSecilenOgr.Items.Clear();
        }

        private void btnGetirOgr_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbBolognaYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Dönem seçimi aktif olmalı
            _model.BolognaYil = (BolognaYil)cmbBolognaYil.SelectedItem;
            if (!string.IsNullOrEmpty(_model.BolognaYil.ad))
            {
                cmbDonem.DataSource = null; //Dönem combobox'ını temizle
                Debug.Write("cmbBolognaYil_SelectedIndexChanged : "); //BolognaYil seçildiğinde id'sini yazdır
                Debug.WriteLine(_model.BolognaYil.bolognaYilID);

                using (var context = new SeciciContext()) //BolognaYil seçildiğinde donem combobox'ına veri çekme
                {
                    cmbDonem.DataSource = context.Donems.Where(donem => donem.yilID == _model.BolognaYil.bolognaYilID).ToList();
                    cmbDonem.DisplayMember = "ad";
                    //cmbDonem.SelectedIndex = -1;
                    cmbDonem.SelectedItem = null;
                }

            }
            if (cmbDonem.Items.Count > 0)
            {
                cmbDonem.Show(); //BolognaYil seçildiğinde donem seçimi aktif olur
                cmbDonem.Text = "Dönem Seçiniz";
            }
            else
            {
                cmbDonem.Hide(); cmbDers.Hide(); cmbGrup.Hide();
            }

        }

        private void cmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            _model.Donem = (Donem)cmbDonem.SelectedItem;
            if (_model.Donem?.ad != null)
            {
                cmbDers.DataSource = null; //Ders combobox'ını temizle
                Debug.Write("donemCmb_SelectedIndexChanged : ");
                Debug.WriteLine(_model.Donem.donemID);

                using (var context = new SeciciContext())
                {
                    cmbDers.DataSource = context.Ders.Where(x => x.donemID == _model.Donem.donemID).ToList();
                    cmbDers.DisplayMember = "ad";
                    cmbDers.SelectedItem = null;
                }
            }

            if (cmbDers.Items.Count > 0)
            {
                cmbDers.Show(); //Donem seçildiğinde ders seçimi aktif olur
                cmbDers.Text = @"Ders Seçiniz";
                cmbGrup.Text = @"Grup Seçiniz";
            }
            else
            {
                cmbDers.Hide();
                cmbGrup.Hide();
            }

        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDers.SelectedItem != null)
            {
                _model.Egitim.Ders = (Ders)cmbDers.SelectedItem;
                Debug.Write("dersCmb_SelectedIndexChanged : ");
                Debug.WriteLine(_model.Egitim.Ders.dersID);
                cmbGrup.Show(); //Ders seçildiğinde grup seçimi aktif olur
            }
        }

        private void cmbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrup.SelectedItem != null)
            {
                _model.Egitim.Grup = (Grup)cmbGrup.SelectedItem;
                Debug.WriteLine(_model.Egitim.Grup.grupID);
            }

        }
    }
}
