using OgrenciSecme.Models.Entities;
using OgrenciSecme.Models.OgrenciSecimModel;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace OgrenciSecme
{
    partial class FrmOgrenciSecim : Form
    {
        private SecimMethodModel _model = new SecimMethodModel();

        public FrmOgrenciSecim()
        {
            InitializeComponent();


        }

        private void FrmOgrenciSecim_Load(object sender, EventArgs e)
        {
            using (var dbContext = new SeciciContext())
            {
                //BolognaYil ve Grup combobox'larına veri çekme

                cmbBolognaYil.DataSource = dbContext.BolognaYils.ToList();
                cmbBolognaYil.DisplayMember = "ad";
                //cmbBolognaYil.SelectedIndex = -1;

                cmbGrup.DataSource = dbContext.Grups.ToList();
                cmbGrup.DisplayMember = "ad";

            }

            this.Text = title;
            this.cmbGrup.Hide();
            this.cmbDers.Hide();
            this.cmbDonem.Hide();

            this.cmbBolognaYil.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cmbBolognaYil.AutoCompleteSource = AutoCompleteSource.None;

        }

        private void btnGorunenTemizle_Click(object sender, EventArgs e)
        {
            lstGorunenOgr.Items.Clear();
        }

        private void btnSecilenTemizle_Click(object sender, EventArgs e)
        {
            lstSecilenOgr.Items.Clear();
        }

        private void btnSecilenSirala_Click(object sender, EventArgs e)
        {
            lstGorunenOgr.Items.Clear(); //Önceki kayıtların silinme işlemi.
            var SecilenOgrenci = lstSecilenOgr.Items.Cast<Ogrenci>().ToList();

            using (var context = new SeciciContext())
            {
                var egitims = context.Egitims.Where(egitim =>
                    egitim.grupID == _model.Egitim.Grup.grupID &&
                    egitim.dersID == _model.Egitim.Ders.dersID).ToList();

                // Egitim listesindeki her bir egitim için aşağıdaki işlemleri yap
                egitims.ToList().ForEach(egitim =>
                {
                    // Eğitimdeki ogrenciID'ye sahip olan ogrenciyi bulun
                    var gorunenOgrenci = context.Ogrencis.Where(ogrenci => ogrenci.ogrenciID == egitim.ogrenciID).SingleOrDefault();

                    // Listbox'a siraliOgrenci'yi ekle
                    lstGorunenOgr.Items.Add(gorunenOgrenci);
                });
                //TODO: lstGorunenOgr'ye veri eklemeden once lstSecilenOgr'de olup olmadığını kontrol et

                foreach (var secilenOgrenci in SecilenOgrenci)
                {
                    lstGorunenOgr.Items.Cast<Ogrenci>()
                        .Where(x => x.adSoyad.IndexOf(secilenOgrenci.adSoyad,
                            StringComparison.CurrentCultureIgnoreCase) >= 0)
                        .ToList()
                        .ForEach(x => lstGorunenOgr.Items.Remove(x));
                }
            }
        }

        private void btnTumSirala_Click(object sender, EventArgs e)
        {
            var SecilenOgrenci = lstSecilenOgr.Items.Cast<Ogrenci>().ToList();
            lstGorunenOgr.Items.Clear();
            using (var context = new SeciciContext())
            {
                var tumOgrenci = context.Ogrencis.ToList();
                lstGorunenOgr.Items.AddRange(tumOgrenci.ToArray());

            }

            foreach (var secilenOgrenci in SecilenOgrenci)
            {
                lstGorunenOgr.Items.Cast<Ogrenci>()
                    .Where(x => x.adSoyad.IndexOf(secilenOgrenci.adSoyad,
                        StringComparison.CurrentCultureIgnoreCase) >= 0)
                    .ToList()
                    .ForEach(x => lstGorunenOgr.Items.Remove(x));
            }
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

        private void yeniPencereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Yeni pencere açarken limit konulacak(Sayaç hep 1)
            //int acikPencereSayisi = Application.OpenForms.OfType<Form>().Count(form => form.Visible);
            //if (acikPencereSayisi < 2)
            //{
            //    Process.Start(Application.CompanyName);
            //}
            //else
            //{
            //    MessageBox.Show("Zaten bir pencere açık!");
            //}

        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Kaydetme işlemi
        }

        private void öğrenciKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit frmOgrenciKayit = new FrmOgrenciKayit();
            //this.Hide();
            frmOgrenciKayit.ShowDialog();
        }

        private void öğrenciSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRasgeleOgr_Click(object sender, EventArgs e)
        {
            if (lstGorunenOgr.Items.Count > 0)
            {
                var rnd = new Random();
                int bekleme = 300;
                var ogrList = lstGorunenOgr.Items.Count;
                //for (int i = 1; i < 50; i++)
                //{
                //    var rastgeleSayi = rnd.Next(0, ogrList);
                //    lstGorunenOgr.SelectedIndex = rastgeleSayi;
                //    Thread.Sleep(bekleme = (i * 7 < 200) ? 160 : 250);
                //}
                var rastgeleSayi = rnd.Next(0, ogrList);
                lstGorunenOgr.SelectedIndex = rastgeleSayi;
                Thread.Sleep(bekleme);
                lstSecilenOgr.Items.Add(lstGorunenOgr.SelectedItem);
                lstGorunenOgr.Items.Remove(lstGorunenOgr.SelectedItem);
            }
            else
            {
                MessageBox.Show("Öğrenci seçilebilmesi için bir öğrenci listesi sıralayın. Gerekli kutucukların doldurulduğundan emin olunuz!", "Secilecek Öğrenci Bulunmamaktadır", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdbOgrenciEksiltme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckbPuanVer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckbHepsiniGetir_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
