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
        private SecimMethodModel model = new SecimMethodModel();
        public FrmOgrenciSecim()
        {
            InitializeComponent();
        }

        private void FrmOgrenciSecim_Load(object sender, EventArgs e)
        {
            this.Text = title;
            using (var dbContext = new SeciciContext())
            {
                cmbDonem.DataSource = dbContext.Donems.ToList();
                cmbDonem.DisplayMember = "ad";
                cmbDonem.SelectedItem = null;
                cmbDonem.Text = "Donem Seçiniz";

                cmbDers.DataSource = dbContext.Ders.ToList();
                cmbDers.DisplayMember = "ad";
                cmbDers.SelectedItem = null;
                cmbDers.Text = "Ders Seçiniz";

                cmbGrup.DataSource = dbContext.Grups.ToList();
                cmbGrup.DisplayMember = "ad";
                cmbGrup.SelectedItem = null;
                cmbGrup.Text = "Grup Seçiniz";
            }
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
            EgitimValidation validation = new EgitimValidation();
            var result = validation.Validate(new Egitim());

            if (result.IsValid)
            {
                model.Donem.donemID = Guid.Parse(cmbDonem.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
        }

        private void cmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Assert(cmbDonem != null, nameof(cmbDonem) + " != null");
            if (cmbDonem.SelectedItem != null)
            {
                model.Donem.donemID = ((Donem)cmbDonem.SelectedItem).donemID;
                Debug.WriteLine(model.Egitim.dersID);
            }
        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDers.SelectedItem != null)
            {
                model.Egitim.dersID = ((Ders)cmbDers.SelectedItem).dersID;
                Debug.WriteLine(model.Egitim.dersID);
            }

        }

        private void cmbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrup.SelectedItem != null)
            {
                model.Egitim.grupID = ((Grup)cmbGrup.SelectedItem).grupID;
                Debug.WriteLine(model.Egitim.grupID);
            }
        }
    }
}
