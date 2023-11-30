using ExcelDataReader;
using OgrenciSecme.Models;
using OgrenciSecme.Models.MainModels;
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

namespace OgrenciSecme
{
    public partial class MainFrm : Form
    {
        private string title = "Öğrenci Kayıt";
        private string excelFile;
        private string kayitliOgrencis;
        private List<string> kayitliOgrenci = new List<string>();
        private MainYukleModel model = new MainYukleModel();
        public DataSet result { get; set; }
        public MainFrm()
        {
            InitializeComponent();
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.Text = title;
            this.gostermeDgv.Hide();
            using (var dbContext = new SeciciContext())
            {
                donemCmb.DataSource = dbContext.Donems.ToList();
                donemCmb.DisplayMember = "ad";
                dersCmb.DataSource = dbContext.Ders.ToList();
                dersCmb.DisplayMember = "ad";
                grupCmb.DataSource = dbContext.Grups.ToList();
                grupCmb.DisplayMember = "ad";
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
                MessageBox.Show("Lutfen dosya seçmeyi unutmayın", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dosyaSecme.FlatAppearance.BorderColor = Color.Red;
                this.dosyaSecme.FlatAppearance.BorderSize = 6;
            }
            else
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

                                dbContext.Egitims.Add(new Egitim
                                {
                                    dersID = model.Egitim.dersID,
                                    donemID = model.Egitim.donemID,
                                    grupID = model.Egitim.grupID,
                                    ogrenciID = dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).FirstOrDefault().ogrenciID,
                                    kullaniciID = 1
                                });

                            }
                            else //Öğrenci varsa
                            {
                                model.Ogrenci.ogrenciID = dbContext.Ogrencis.Where(x => x.ogrenciNo == model.Ogrenci.ogrenciNo).FirstOrDefault().ogrenciID;

                                if (dbContext.Egitims.Where(x =>

                                    x.donemID == model.Egitim.donemID &&
                                    x.dersID == model.Egitim.dersID &&
                                    x.ogrenciID == model.Ogrenci.ogrenciID &&
                                    x.grupID == model.Egitim.grupID).
                                    SingleOrDefault() != null)
                                {
                                    kayitliOgrenci.Add(model.Ogrenci.ad);
                                    kayitliOgrencis = string.Join(Environment.NewLine, kayitliOgrenci);
                                }
                                else
                                {
                                    dbContext.Egitims.Add(new Egitim
                                    {
                                        dersID = model.Egitim.dersID,
                                        donemID = model.Egitim.donemID,
                                        grupID = model.Egitim.grupID,
                                        ogrenciID = model.Ogrenci.ogrenciID,
                                        kullaniciID = 1
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
                    MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }
        private void donemCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (donemCmb.SelectedItem != null)
            {
                var sltDonem = (Donem)donemCmb.SelectedItem;
                model.Egitim.donemID = sltDonem.donemID;
                Debug.WriteLine(model.Egitim.donemID);
            }

        }
        private void grupCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grupCmb.SelectedItem != null)
            {
                var sltGrup = (Grup)grupCmb.SelectedItem;
                model.Egitim.grupID = sltGrup.grupID;
                Debug.WriteLine(model.Egitim.grupID);
            }

        }
        private void dersCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dersCmb.SelectedItem != null)
            {
                var sltDers = (Ders)dersCmb.SelectedItem;
                model.Egitim.dersID = sltDers.dersID;
                Debug.WriteLine(model.Egitim.dersID);
            }
        }

        private void ShowMessageBox(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }
    }
}
