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
        private string fileName;
        private string listText;
        private List<string> kayitliOgrenci = new List<string>();

        public DataSet result { get; set; }

        private MainYukleModel model = new MainYukleModel();

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
                    fileName = openFileDialog.FileName;
                    try
                    {
                        using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
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
            if (fileName is null)
            {
                Console.Beep();
                MessageBox.Show("Lutfen dosya seçmeyi unutmayın", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dosyaSecme.FlatAppearance.BorderColor = Color.Red;
                this.dosyaSecme.FlatAppearance.BorderSize = 6; // İsteğe bağlı olarak kenarlık kalınlığını ayarlayabilirsiniz
            }
            else
            {
                try
                {
                    DataTable dataTable = result.Tables[0];

                    using (var dbContext = new SeciciContext())
                    {
                        //var model = new MainYukleModel()
                        //{ 
                        //    Egitim = dbContext.Egitims.Where(x => x.Donem.donemIDad == donemCmb.SelectedItem.ToString() && x.ders.ad == dersCmb.SelectedItem.ToString() && x.grup.ad == grupCmb.SelectedItem.ToString()).FirstOrDefault()

                        //}
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Excel'den gelen verileri al
                            string ad = row["Name"]?.ToString();
                            string ogrenciNo = row["Okul No"]?.ToString() ?? null;
                            if (ogrenciNo == "" || ogrenciNo is null) continue;

                            // Veritabanına öğrenci ekle
                            if (dbContext.Ogrencis.Where(x => x.ogrenciNo == ogrenciNo).FirstOrDefault() == null)
                            {
                                dbContext.Ogrencis.Add(new Ogrenci { ad = ad, ogrenciNo = ogrenciNo });
                                dbContext.SaveChanges();

                                dbContext.Egitims.Add(new Egitim
                                {
                                    dersID = model.Egitim.dersID,
                                    donemID = model.Egitim.donemID,
                                    grupID = model.Egitim.grupID,
                                    ogrenciID = dbContext.Ogrencis.Where(x => x.ogrenciNo == ogrenciNo).FirstOrDefault().ogrenciID,
                                    kullaniciID = 1
                                });

                            }
                            else
                            {
                                model.Ogrenci.ogrenciID = dbContext.Ogrencis.Where(x => x.ogrenciNo == ogrenciNo).FirstOrDefault().ogrenciID;
                                if (dbContext.DonemDers.Where(x => x.donemID == model.Egitim.donemID && x.dersID == model.Egitim.dersID && x.ogrenciID == model.Ogrenci.ogrenciID).FirstOrDefault() == null)
                                {
                                    kayitliOgrenci.Add(ad);
                                    listText = string.Join(Environment.NewLine, kayitliOgrenci);
                                }
                            }

                            // Değişiklikleri kaydet
                        }
                        MessageBox.Show($"{listText}\n Bu öğrenci/öğrenciler zaten bu doneme/derse kayıtlı", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show("İşlem Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
