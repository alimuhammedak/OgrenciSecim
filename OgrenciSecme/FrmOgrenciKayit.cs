using ExcelDataReader;
using OgrenciSecme.Models;
using OgrenciSecme.Models.OgrenciKayitModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciSecme.Models.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OgrenciSecme
{
    public partial class FrmOgrenciKayit : Form
    {
        #region Tanımlamalar

        private string excelFile; //Excel dosyasının yolu
        private DialogResult rMessage; //Mesaj kutusu cevabı
        private string kayitliOgrencis; //Kayıtlı öğrencileri tutar
        private List<string> kayitliOgrenci = new List<string>(); //Kayıtlı öğrencilerin listesini tutar
        private YukleMethodModel model = new YukleMethodModel();
        public DataSet result { get; set; }

        #endregion

        public FrmOgrenciKayit()
        {
            InitializeComponent();
            using (var dbContext = new SeciciContext())
            {
                //BolognaYil ve Grup combobox'larına veri çekme
                cmbBolognaYil.DataSource = dbContext.BolognaYils.ToList();
                cmbBolognaYil.DisplayMember = "ad";
                //cmbBolognaYil.SelectedIndex = -1;
                cmbBolognaYil.SelectedItem = null;

                cmbGrup.DataSource = dbContext.Grups.ToList();
                cmbGrup.DisplayMember = "ad";

            }
        }

        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            this.Text = title;
            this.gostermeDgv.Hide();
            this.cmbGrup.Hide();
            this.cmbDers.Hide();
            this.cmbDonem.Hide();

        }

        private void DosyaSecme_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Dosyaları 97-2003|*.xls|Excel Dosyaları|*.xlsx", Title = "Excel Dosyaları" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelFile = openFileDialog.FileName;
                    try
                    {
                        using (var stream = File.Open(excelFile, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(stream))
                            {
                                result = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                            }
                        }
                        gostermeDgv.Show();
                        gostermeDgv.DataSource = result.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void Yukle_Click(object sender, EventArgs e)
        {

            if (excelFile is null)  //Dosyanin secilip secilmediği
            {
                ShowMessageBox("Lutfen dosya seçmeyi unutmayın", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dosyaSecme.FlatAppearance.BorderColor = Color.Red;
                this.dosyaSecme.FlatAppearance.BorderSize = 6;
            }
            else { rMessage = MessageBox.Show("Dosyalar kayedilecek emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); }
            if (rMessage == DialogResult.Yes)
            {
                try
                {
                    DataTable dataTable = result.Tables[0]; //Excel Kitap Seçimi

                    using (var dbContext = new SeciciContext())
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Excel'den gelen verileri al
                            model.Ogrenci.ad = row["Name"]?.ToString();
                            model.Ogrenci.ogrenciNo = row["Okul No"]?.ToString() ?? null;

                            if (model.Ogrenci.ogrenciNo == "" || model.Ogrenci.ogrenciNo is null) continue; //Ogrenci numarası yoksa atla

                            Ogrenci ogrenci = dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).SingleOrDefault();

                            //Yeni öğrenci ise ekle
                            if (ogrenci == null)
                            {
                                dbContext.Ogrencis.Add(new Ogrenci { ad = model.Ogrenci.ad, ogrenciNo = model.Ogrenci.ogrenciNo });
                                dbContext.SaveChanges();
                            }
                            
                            model.Ogrenci = dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).SingleOrDefault();

                            var egitim = dbContext.Egitims.Where(x =>
                                x.dersID == model.Egitim.dersID &&
                                x.ogrenciID == model.Ogrenci.ogrenciID &&
                                x.grupID == model.Egitim.grupID).SingleOrDefault();

                            if (egitim != null) //Öğrenci bu eğitime kayıtlı mı?
                            {
                                //kayitliOgrenci.Add(model.Ogrenci.ad);
                                //kayitliOgrencis = string.Join(Environment.NewLine, kayitliOgrenci);
                                kayitliOgrencis += model.Ogrenci.ad + "\n";
                            }
                            else
                            {
                                dbContext.Egitims.Add(new Egitim
                                {
                                    dersID = model.Egitim.Ders.dersID,
                                    grupID = model.Egitim.Grup.grupID,
                                    ogrenciID = model.Ogrenci.ogrenciID,
                                    kullaniciID = Guid.Parse("16370B08-3591-EE11-BFAE-3003C89EE5A0")
                                });
                                dbContext.SaveChanges();// Değişiklikleri kaydet
                            }
                        }
                    }

                    if (kayitliOgrencis == "" || kayitliOgrencis is null)
                    {
                        ShowMessageBox("İşlem Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ShowMessageBox($"{kayitliOgrencis}\n Bu öğrenci/öğrenciler zaten bu döneme/derse kayıtlı", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kayitliOgrenci.RemoveAll(x => true);
                        kayitliOgrencis = "";
                    }

                }
                catch (Exception ex)
                {
                    ShowMessageBox(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbBolognaYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Dönem seçimi aktif olmalı

            if (cmbBolognaYil.SelectedItem != null)
            {
                cmbDonem.DataSource = null; //Dönem combobox'ını temizle
                model.BolognaYil = (BolognaYil)cmbBolognaYil.SelectedItem; //BolognaYil seçildiğinde model'e aktar
                Debug.WriteLine("cmbBolognaYil_SelectedIndexChanged"); //BolognaYil seçildiğinde id'sini yazdır

                using (var context = new SeciciContext()) //BolognaYil seçildiğinde donem combobox'ına veri çekme
                {
                    //var deneme = Guid.Parse("894963BE-5391-EE11-BFAE-3003C89EE5A0");

                    cmbDonem.DataSource = context.Donems.Where(donem => donem.yilID == model.BolognaYil.bolognaYilID).ToList();
                    cmbDonem.DisplayMember = "ad";
                    //cmbDonem.SelectedIndex = -1;
                    cmbDonem.SelectedItem = null;
                }

                if (cmbDonem.Items.Count > 0)
                {
                    cmbDonem.Show(); //BolognaYil seçildiğinde donem seçimi aktif olur
                    cmbDonem.Text = "Dönem Seçiniz";
                }

            }
        }

        private void cmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDonem.SelectedItem != null)
            {
                model.Donem = (Donem)cmbDonem.SelectedItem;
                Debug.Write("donemCmb_SelectedIndexChanged : ");
                Debug.WriteLine(model.Donem.donemID);

                using (var context = new SeciciContext())
                {
                    cmbDers.DataSource = context.Ders.Where(x => x.donemID == model.Donem.donemID).ToList();
                    cmbDers.DisplayMember = "ad";
                    cmbDers.SelectedItem = null;
                }

                if (cmbDers.Items.Count > 0)
                {
                    cmbDers.Show(); //Donem seçildiğinde ders seçimi aktif olur
                    cmbDers.Text = "Ders Seçiniz";
                    cmbGrup.Text = "Grup Seçiniz";
                }
                else
                {
                    cmbDers.Hide();
                    cmbGrup.Hide();
                }
            }

        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDers.SelectedItem != null)
            {
                model.Egitim.Ders = (Ders)cmbDers.SelectedItem;
                Debug.Write("dersCmb_SelectedIndexChanged : ");
                Debug.WriteLine(model.Egitim.Ders.dersID);
                cmbGrup.Show(); //Ders seçildiğinde grup seçimi aktif olur
            }
        }

        private void cmbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrup.SelectedItem != null)
            {
                model.Egitim.Grup = (Grup)cmbGrup.SelectedItem;
                Debug.WriteLine(model.Egitim.Grup.grupID);
            }

        }

        private void ShowMessageBox(string message, string caption, MessageBoxButtons button, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, button, icon);
        }

        //private void cmbBolognaYil_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("cmbBolognaYil_SelectedValueChanged");
        //}
    }
}
