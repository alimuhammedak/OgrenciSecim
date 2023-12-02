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

namespace OgrenciSecme
{
    public partial class FrmOgrenciKayit : Form
    {

        private string excelFile; //Excel dosyasının yolu
        private DialogResult rMessage; //Mesaj kutusu cevabı
        private string kayitliOgrencis; //Kayıtlı öğrencileri tutar
        private List<string> kayitliOgrenci = new List<string>(); //Kayıtlı öğrencilerin listesini tutar
        private YukleMethodModel model = new YukleMethodModel();
        public DataSet result { get; set; }
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }

        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            this.Text = title;
            this.gostermeDgv.Hide();
            this.cmbGrup.Hide();
            this.cmbDers.Hide();
            this.cmbDonem.Hide();
            using (var dbContext = new SeciciContext())
            {
                //BolognaYil ve Grup combobox'larına veri çekme
                cmbBolognaYil.DataSource = dbContext.BolognaYils.ToList();
                cmbBolognaYil.DisplayMember = "ad";

                cmbGrup.DataSource = dbContext.Grups.ToList();
                cmbGrup.DisplayMember = "ad";

            }
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

        private void yukle_Click(object sender, EventArgs e)
        {

            if (excelFile is null)  //Dosyanin secilip secilmediği
            {
                ShowMessageBox("Lutfen dosya seçmeyi unutmayın", "Dikkat", MessageBoxIcon.Error);
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

                            //Yeni öğrenci ise ekle
                            if (dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).FirstOrDefault() == null)
                            {
                                dbContext.Ogrencis.Add(new Ogrenci { ad = model.Ogrenci.ad, ogrenciNo = model.Ogrenci.ogrenciNo });
                                dbContext.SaveChanges();

                                dbContext.Egitims.Add(new Egitim //Egitim tablosuna ekle
                                {
                                    dersID = model.Egitim.dersID,
                                    grupID = model.Egitim.grupID,
                                    ogrenciID = dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).FirstOrDefault().ogrenciID,
                                    kullaniciID = Guid.Parse("16370B08-3591-EE11-BFAE-3003C89EE5A0")
                                });

                            }
                            else //Öğrenci varsa
                            {
                                model.Ogrenci.ogrenciID = dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).FirstOrDefault().ogrenciID;

                                if (dbContext.Egitims.Where(x =>
                                    x.dersID == model.Egitim.dersID &&
                                    x.ogrenciID == model.Ogrenci.ogrenciID &&
                                    x.grupID == model.Egitim.grupID).
                                    SingleOrDefault() != null)
                                {
                                    //kayitliOgrenci.Add(model.Ogrenci.ad);
                                    //kayitliOgrencis = string.Join(Environment.NewLine, kayitliOgrenci);
                                    kayitliOgrencis += model.Ogrenci.ad + "\n";
                                }
                                else
                                {
                                    dbContext.Egitims.Add(new Egitim
                                    {
                                        dersID = model.Egitim.dersID,
                                        grupID = model.Egitim.grupID,
                                        ogrenciID = model.Ogrenci.ogrenciID,
                                        kullaniciID = Guid.Parse("16370B08-3591-EE11-BFAE-3003C89EE5A0")
                                    });
                                }

                            }
                            dbContext.SaveChanges();// Değişiklikleri kaydet
                        }
                    }

                    if (kayitliOgrencis == "" || kayitliOgrencis is null)
                    {
                        ShowMessageBox("İşlem Başarılı", "Başarılı", MessageBoxIcon.Information);
                    }
                    else
                    {
                        ShowMessageBox($"{kayitliOgrencis}\n Bu öğrenci/öğrenciler zaten bu döneme/derse kayıtlı", "Dikkat", MessageBoxIcon.Error);
                        kayitliOgrenci.RemoveAll(x => true);
                        kayitliOgrencis = "";
                    }

                }
                catch (Exception ex)
                {
                    ShowMessageBox(ex.Message, "Mesaj", MessageBoxIcon.Error);
                }


            }

        }

        private void cmbBolognaYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDonem.SelectedItem != null)
            {
                BolognaYil bolognaYil = (BolognaYil)cmbDonem.SelectedItem;
                model.BolognaYil.bolognaYilID = bolognaYil.bolognaYilID;
                Debug.WriteLine(model.BolognaYil.bolognaYilID);

                using (var context = new SeciciContext())
                {
                    cmbDonem.DataSource = context.BolognaYils.Where(x => x.bolognaYilID == bolognaYil.bolognaYilID);
                    cmbDonem.DisplayMember = "ad";
                }

                cmbDonem.Show(); //BolognaYil seçildiğinde donem seçimi aktif olur
            }
        }

        private void donemCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDonem.SelectedItem != null)
            {
                Donem donem = (Donem)cmbDonem.SelectedItem;
                model.Donem.donemID = donem.donemID;
                Debug.WriteLine(model.Donem.donemID);  

                using (var context = new SeciciContext())
                {
                    cmbDers.DataSource = context.Ders.Where(x => x.donemID == donem.donemID);
                    cmbDers.DisplayMember = "ad";
                }

                cmbDers.Show(); //Dönem seçildiğinde ders seçimi aktif olur
            }

        }

        private void dersCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDers.SelectedItem != null)
            {
                Ders ders = (Ders)cmbDers.SelectedItem;
                model.Egitim.dersID = ders.dersID;
                Debug.WriteLine(model.Egitim.dersID);

                cmbGrup.Show(); //Ders seçildiğinde grup seçimi aktif olur
            }
        }

        private void grupCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrup.SelectedItem != null)
            {
                Grup grup = (Grup)cmbGrup.SelectedItem;
                model.Egitim.grupID = grup.grupID;
                Debug.WriteLine(model.Egitim.grupID);
            }

        }
        

        private void ShowMessageBox(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

    }
}
