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
using System.Data.Entity.Validation;

namespace OgrenciSecme
{
    public partial class FrmOgrenciKayit : Form
    {
        #region Tanımlamalar

        private string _excelFile; //Excel dosyasının yolu
        private DialogResult _rMessage; //Mesaj kutusu cevabı
        private string _kayitliOgrencis; //Kayıtlı öğrencileri tutar
        private Egitim egitim;
        private readonly List<string> _kayitliOgrenci = new List<string>(); //Kayıtlı öğrencilerin listesini tutar
        private readonly YukleMethodModel _model = new YukleMethodModel();
        public DataSet Result { get; set; }

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

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Excel Dosyaları 97-2003|*.xls|Excel Dosyaları|*.xlsx";
                openFileDialog.Title = @"Excel Dosyaları";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _excelFile = openFileDialog.FileName;
                    try
                    {
                        using (var stream = File.Open(_excelFile, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(stream))
                            {
                                Result = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                            }
                        }
                        gostermeDgv.Show();
                        gostermeDgv.DataSource = Result.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void Yukle_Click(object sender, EventArgs e)
        {

            if (_excelFile is null)  //Dosyanin secilip secilmediği
            {
                MessageBox.Show("Lutfen dosya seçmeyi unutmayın", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dosyaSecme.FlatAppearance.BorderColor = Color.Red;
                this.dosyaSecme.FlatAppearance.BorderSize = 6;
            }
            else { _rMessage = MessageBox.Show(@"Dosyalar kayedilecek emin misiniz?", @"Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); }
            if (_rMessage == DialogResult.Yes)
            {
                try
                {
                    DataTable dataTable = Result.Tables[0]; //Excel Kitap Seçimi

                    using (var dbContext = new SeciciContext())
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Excel'den gelen verileri al
                            string ad = row["Name"]?.ToString();
                            string no = row["Okul No"]?.ToString() ?? null;

                            if (string.IsNullOrEmpty(no))
                                continue; //Ogrenci numarası yoksa atla

                            Ogrenci ogrenci = dbContext.Ogrencis.Where(x => x.ogrenciNo == no).FirstOrDefault(); //Öğrenci var mı?

                            //Yeni öğrenci ise ekle
                            if (ogrenci == null)
                            {
                                dbContext.Ogrencis.Add(new Ogrenci { ad = ad, ogrenciNo = no });
                                dbContext.SaveChanges();
                                ogrenci = dbContext.Ogrencis.Where(x => x.ogrenciNo == no).FirstOrDefault();
                            }

                            egitim = dbContext.Egitims.Where(x => x.ogrenciID == ogrenci.ogrenciID && x.dersID == _model.Egitim.Ders.dersID && x.grupID == _model.Egitim.Grup.grupID).FirstOrDefault(); //Öğrenci bu eğitime kayıtlı mı?   

                            if (egitim != null) //Öğrenci bu eğitime kayıtlı mı?
                                _kayitliOgrencis += ad + "\n";
                            //kayitliOgrenci.Add(model.Ogrenci.ad);
                            //kayitliOgrencis = string.Join(Environment.NewLine, kayitliOgrenci);

                            else
                            {
                                dbContext.Egitims.Add(new Egitim
                                {
                                    dersID = _model.Egitim.Ders.dersID,
                                    grupID = _model.Egitim.Grup.grupID,
                                    ogrenciID = ogrenci.ogrenciID,
                                    kullaniciID = Guid.Parse("16370B08-3591-EE11-BFAE-3003C89EE5A0")
                                });
                                dbContext.SaveChanges();// Değişiklikleri kaydet
                            }

                        }
                    }

                    #region Kayitli Ogrenci Liste Gösterme

                    if (!string.IsNullOrEmpty(_kayitliOgrencis))
                    {
                        MessageBox.Show($"{_kayitliOgrencis}\n Bu öğrenci/öğrenciler zaten bu döneme/derse kayıtlı",
                            "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _kayitliOgrenci.RemoveAll(x => true); _kayitliOgrencis = "";
                    }
                    else
                    {
                        MessageBox.Show("İşlem Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    #endregion

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine(
                            @"Entity of type ""{0}"" in state ""{1}"" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine(@"- Property: ""{0}"", Error: ""{1}""",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    throw;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Peki", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbBolognaYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Dönem seçimi aktif olmalı
            _model.BolognaYil = (BolognaYil)cmbBolognaYil.SelectedItem;
            if (!string.IsNullOrEmpty(_model.BolognaYil?.ad))
            {
                cmbDonem.DataSource = null; //Dönem combobox'ını temizle
                Debug.Write("cmbBolognaYil_SelectedIndexChanged : "); //BolognaYil seçildiğinde id'sini yazdır
                Debug.WriteLine(_model.BolognaYil.bolognaYilID);

                using (var context = new SeciciContext()) //BolognaYil seçildiğinde donem combobox'ına veri çekme
                {
                    //var deneme = Guid.Parse("894963BE-5391-EE11-BFAE-3003C89EE5A0");
                    //var deneme2 = new Guid();

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
