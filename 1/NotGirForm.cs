using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Bilgi_Sistemi
{
    public partial class NotGirForm : Form
    {
        private NotYonetici notYonetici;
        private OgrenciYonetici ogrenciYonetici;
        private DersYonetici dersYonetici;
        private DersKayitYonetici dersKayitYonetici; // Yeni eklenen
        private ComboBox cmbOgrenci;
        private ComboBox cmbDers;
        private TextBox txtVize;
        private TextBox txtFinal;
        private Label lblBaslik;
        private Label lblOgrenci;
        private Label lblDers;
        private Label lblVize;
        private Label lblFinal;
        private Label lblBilgi;
        private Button btnKaydet;
        private Button btnIptal;
        private OgrenciYonetici ogrenciYoneticisi;
        private DersYonetici dersYoneticisi;
        private NotYonetici notYoneticisi;

        
        public NotGirForm(OgrenciYonetici ogrenciYonetici, DersYonetici dersYonetici, NotYonetici notYonetici, DersKayitYonetici dersKayitYonetici)
        {
            this.ogrenciYonetici = ogrenciYonetici;
            this.dersYonetici = dersYonetici;
            this.notYonetici = notYonetici;
            this.dersKayitYonetici = dersKayitYonetici; // Yeni eklenen
            InitializeComponent();
            OgrencileriDoldur();
        }

       
        private void InitializeComponent()
        {
            this.lblBaslik = new Label();
            this.lblOgrenci = new Label();
            this.cmbOgrenci = new ComboBox();
            this.lblDers = new Label();
            this.cmbDers = new ComboBox();
            this.lblVize = new Label();
            this.txtVize = new TextBox();
            this.lblFinal = new Label();
            this.txtFinal = new TextBox();
            this.lblBilgi = new Label();
            this.btnKaydet = new Button();
            this.btnIptal = new Button();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblBaslik.Location = new Point(150, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(150, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "NOT GİRİŞİ";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.Location = new Point(30, 70);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new Size(100, 20);
            this.lblOgrenci.TabIndex = 1;
            this.lblOgrenci.Text = "Öğrenci:";
            // 
            // cmbOgrenci
            // 
            this.cmbOgrenci.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOgrenci.Location = new Point(140, 70);
            this.cmbOgrenci.Name = "cmbOgrenci";
            this.cmbOgrenci.Size = new Size(250, 33);
            this.cmbOgrenci.TabIndex = 2;
            this.cmbOgrenci.SelectedIndexChanged += this.CmbOgrenci_SelectedIndexChanged; // Event eklendi
            // 
            // lblDers
            // 
            this.lblDers.Location = new Point(30, 110);
            this.lblDers.Name = "lblDers";
            this.lblDers.Size = new Size(100, 20);
            this.lblDers.TabIndex = 3;
            this.lblDers.Text = "Ders:";
            // 
            // cmbDers
            // 
            this.cmbDers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDers.Location = new Point(140, 110);
            this.cmbDers.Name = "cmbDers";
            this.cmbDers.Size = new Size(250, 33);
            this.cmbDers.TabIndex = 4;
            // 
            // lblVize
            // 
            this.lblVize.Location = new Point(30, 150);
            this.lblVize.Name = "lblVize";
            this.lblVize.Size = new Size(100, 20);
            this.lblVize.TabIndex = 5;
            this.lblVize.Text = "Vize Notu:";
            // 
            // txtVize
            // 
            this.txtVize.Location = new Point(140, 150);
            this.txtVize.Name = "txtVize";
            this.txtVize.Size = new Size(100, 31);
            this.txtVize.TabIndex = 6;
            // 
            // lblFinal
            // 
            this.lblFinal.Location = new Point(30, 190);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new Size(100, 20);
            this.lblFinal.TabIndex = 7;
            this.lblFinal.Text = "Final Notu:";
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new Point(140, 190);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new Size(100, 31);
            this.txtFinal.TabIndex = 8;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Font = new Font("Arial", 8F, FontStyle.Italic);
            this.lblBilgi.ForeColor = Color.Gray;
            this.lblBilgi.Location = new Point(140, 220);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new Size(200, 15);
            this.lblBilgi.TabIndex = 9;
            this.lblBilgi.Text = "* Notlar 0-100 arasında olmalıdır";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = Color.Green;
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(140, 250);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(100, 30);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Not Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += this.BtnKaydet_Click;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = Color.Gray;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(260, 250);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(80, 30);
            this.btnIptal.TabIndex = 11;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += this.BtnIptal_Click;
            // 
            // NotGirForm
            // 
            ClientSize = new Size(473, 328);
            Controls.Add(this.lblBaslik);
            Controls.Add(this.lblOgrenci);
            Controls.Add(this.cmbOgrenci);
            Controls.Add(this.lblDers);
            Controls.Add(this.cmbDers);
            Controls.Add(this.lblVize);
            Controls.Add(this.txtVize);
            Controls.Add(this.lblFinal);
            Controls.Add(this.txtFinal);
            Controls.Add(this.lblBilgi);
            Controls.Add(this.btnKaydet);
            Controls.Add(this.btnIptal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotGirForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Not Girişi";
            ResumeLayout(false);
            PerformLayout();
        }

        // Sadece öğrencileri doldur
        private void OgrencileriDoldur()
        {
            try
            {
                // Öğrencileri combobox'a ekle
                cmbOgrenci.Items.Clear();
                var ogrenciler = ogrenciYonetici.TumOgrenciler();
                foreach (var ogrenci in ogrenciler)
                {
                    cmbOgrenci.Items.Add($"{ogrenci.OgrenciNo} - {ogrenci.Ad} {ogrenci.Soyad}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Öğrenci seçildiğinde sadece o öğrencinin kayıtlı olduğu dersleri göster
        private void CmbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbDers.Items.Clear();

                if (cmbOgrenci.SelectedIndex == -1)
                    return;

                // Seçilen öğrencinin numarasını al
                string ogrenciNo = cmbOgrenci.Text.Split('-')[0].Trim();

                // Öğrencinin kayıtlı olduğu dersleri al
                var ogrencininDersleri = dersKayitYonetici.OgrencininDersleri(ogrenciNo);

                // Dersleri combobox'a ekle
                foreach (var kayit in ogrencininDersleri)
                {
                    var ders = dersYonetici.DersGetir(kayit.DersKodu);
                    if (ders != null)
                    {
                        cmbDers.Items.Add($"{ders.Kod} - {ders.Ad}");
                    }
                }

                // Eğer öğrencinin hiç kayıtlı dersi yoksa bilgi ver
                if (cmbDers.Items.Count == 0)
                {
                    MessageBox.Show("Bu öğrencinin kayıtlı olduğu ders bulunmamaktadır.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dersler yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eski ComboBoxlariDoldur metodunu kaldırdık

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Doğrulama
                if (cmbOgrenci.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbOgrenci.Focus();
                    return;
                }

                if (cmbDers.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir ders seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDers.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtVize.Text) || !double.TryParse(txtVize.Text, out double vize) || vize < 0 || vize > 100)
                {
                    MessageBox.Show("Geçerli bir vize notu giriniz (0-100)!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVize.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFinal.Text) || !double.TryParse(txtFinal.Text, out double final) || final < 0 || final > 100)
                {
                    MessageBox.Show("Geçerli bir final notu giriniz (0-100)!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFinal.Focus();
                    return;
                }

                // Seçilen öğrenci ve ders bilgilerini al
                string ogrenciNo = cmbOgrenci.Text.Split('-')[0].Trim();
                string dersKodu = cmbDers.Text.Split('-')[0].Trim();

                // Önceden not var mı kontrol et
                if (notYonetici.NotGetir(ogrenciNo, dersKodu) != null)
                {
                    DialogResult result = MessageBox.Show("Bu öğrenci için bu derste zaten not kaydı var. Güncellemek istiyor musunuz?",
                        "Not Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;

                    // Notu güncelle
                    if (notYonetici.NotGuncelle(ogrenciNo, new Not(ogrenciNo, dersKodu, vize, final)))
                    {
                        MessageBox.Show("Not başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Not güncellenirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Yeni not ekle
                    var yeniNot = new Not(ogrenciNo, dersKodu, vize, final);

                    if (notYonetici.NotEkle(yeniNot))
                    {
                        MessageBox.Show("Not başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Not kaydedilirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydet işlemi sırasında hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}