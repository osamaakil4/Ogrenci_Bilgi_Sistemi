using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ogrenci_Bilgi_Sistemi
{
    public partial class DersKayitForm : Form
    {
        private DersKayitYonetici dersKayitYonetici;
        private OgrenciYonetici ogrenciYonetici;
        private DersYonetici dersYonetici;
        private const int MAKSIMUM_KREDI = 30; // Maksimum kredi limiti
        private const int MAKSIMUM_DERS_SAYISI = 10; // Maksimum ders sayısı

        // Form kontrolleri
        private ComboBox cbOgrenciler;
        private ListBox lbMevcutDersler;
        private ListBox lbKayitliDersler;
        private Button btnDersEkle;
        private Button btnDersCikar;
        private Label lblToplamKredi;
        private Label lblToplamAkts;
        private Label lblDersSayisi;
        private Button btnKapat;

        public DersKayitForm(DersKayitYonetici dersKayitYonetici, OgrenciYonetici ogrenciYonetici, DersYonetici dersYonetici)
        {
            this.dersKayitYonetici = dersKayitYonetici;
            this.ogrenciYonetici = ogrenciYonetici;
            this.dersYonetici = dersYonetici;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            cbOgrenciler = new ComboBox();
            lbMevcutDersler = new ListBox();
            lbKayitliDersler = new ListBox();
            btnDersEkle = new Button();
            btnDersCikar = new Button();
            lblToplamKredi = new Label();
            lblToplamAkts = new Label();
            lblDersSayisi = new Label();
            btnKapat = new Button();
            lblBaslik = new Label();
            lblOgrenci = new Label();
            lblMevcutDersler = new Label();
            lblKayitliDersler = new Label();
            SuspendLayout();
            // 
            // cbOgrenciler
            // 
            cbOgrenciler.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOgrenciler.Location = new Point(140, 70);
            cbOgrenciler.Name = "cbOgrenciler";
            cbOgrenciler.Size = new Size(300, 33);
            cbOgrenciler.TabIndex = 2;
            cbOgrenciler.SelectedIndexChanged += CbOgrenciler_SelectedIndexChanged;
            // 
            // lbMevcutDersler
            // 
            lbMevcutDersler.Location = new Point(46, 145);
            lbMevcutDersler.Name = "lbMevcutDersler";
            lbMevcutDersler.Size = new Size(268, 229);
            lbMevcutDersler.TabIndex = 4;
            lbMevcutDersler.SelectedIndexChanged += LbMevcutDersler_SelectedIndexChanged;
            lbMevcutDersler.DoubleClick += LbMevcutDersler_DoubleClick;
            // 
            // lbKayitliDersler
            // 
            lbKayitliDersler.Location = new Point(429, 145);
            lbKayitliDersler.Name = "lbKayitliDersler";
            lbKayitliDersler.Size = new Size(314, 229);
            lbKayitliDersler.TabIndex = 6;
            lbKayitliDersler.DoubleClick += LbKayitliDersler_DoubleClick;
            // 
            // btnDersEkle
            // 
            btnDersEkle.BackColor = Color.Green;
            btnDersEkle.Enabled = false;
            btnDersEkle.ForeColor = Color.White;
            btnDersEkle.Location = new Point(320, 209);
            btnDersEkle.Name = "btnDersEkle";
            btnDersEkle.Size = new Size(103, 35);
            btnDersEkle.TabIndex = 7;
            btnDersEkle.Text = "→ Ders Ekle";
            btnDersEkle.UseVisualStyleBackColor = false;
            btnDersEkle.Click += BtnDersEkle_Click;
            // 
            // btnDersCikar
            // 
            btnDersCikar.BackColor = Color.Red;
            btnDersCikar.Enabled = false;
            btnDersCikar.ForeColor = Color.White;
            btnDersCikar.Location = new Point(320, 266);
            btnDersCikar.Name = "btnDersCikar";
            btnDersCikar.Size = new Size(103, 37);
            btnDersCikar.TabIndex = 8;
            btnDersCikar.Text = "← Ders Çıkar";
            btnDersCikar.UseVisualStyleBackColor = false;
            btnDersCikar.Click += BtnDersCikar_Click;
            // 
            // lblToplamKredi
            // 
            lblToplamKredi.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToplamKredi.Location = new Point(429, 386);
            lblToplamKredi.Name = "lblToplamKredi";
            lblToplamKredi.Size = new Size(117, 25);
            lblToplamKredi.TabIndex = 9;
            lblToplamKredi.Text = "Toplam Kredi: 0";
            // 
            // lblToplamAkts
            // 
            lblToplamAkts.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToplamAkts.Location = new Point(552, 386);
            lblToplamAkts.Name = "lblToplamAkts";
            lblToplamAkts.Size = new Size(111, 20);
            lblToplamAkts.TabIndex = 10;
            lblToplamAkts.Text = "Toplam AKTS: 0";
            // 
            // lblDersSayisi
            // 
            lblDersSayisi.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDersSayisi.Location = new Point(666, 386);
            lblDersSayisi.Name = "lblDersSayisi";
            lblDersSayisi.Size = new Size(100, 20);
            lblDersSayisi.TabIndex = 11;
            lblDersSayisi.Text = "Ders Sayısı: 0";
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Gray;
            btnKapat.ForeColor = Color.White;
            btnKapat.Location = new Point(350, 520);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(100, 35);
            btnKapat.TabIndex = 12;
            btnKapat.Text = "Kapat";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += BtnKapat_Click;
            // 
            // lblBaslik
            // 
            lblBaslik.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblBaslik.Location = new Point(250, 20);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(300, 30);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "ÖĞRENCİ DERS KAYIT SİSTEMİ";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOgrenci
            // 
            lblOgrenci.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblOgrenci.Location = new Point(30, 70);
            lblOgrenci.Name = "lblOgrenci";
            lblOgrenci.Size = new Size(100, 20);
            lblOgrenci.TabIndex = 1;
            lblOgrenci.Text = "Öğrenci Seç:";
            // 
            // lblMevcutDersler
            // 
            lblMevcutDersler.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblMevcutDersler.Location = new Point(30, 120);
            lblMevcutDersler.Name = "lblMevcutDersler";
            lblMevcutDersler.Size = new Size(150, 20);
            lblMevcutDersler.TabIndex = 3;
            lblMevcutDersler.Text = "Mevcut Dersler";
            lblMevcutDersler.Click += lblMevcutDersler_Click;
            // 
            // lblKayitliDersler
            // 
            lblKayitliDersler.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblKayitliDersler.Location = new Point(450, 120);
            lblKayitliDersler.Name = "lblKayitliDersler";
            lblKayitliDersler.Size = new Size(150, 20);
            lblKayitliDersler.TabIndex = 5;
            lblKayitliDersler.Text = "Kayıtlı Dersler";
            // 
            // DersKayitForm
            // 
            ClientSize = new Size(778, 594);
            Controls.Add(lblBaslik);
            Controls.Add(lblOgrenci);
            Controls.Add(cbOgrenciler);
            Controls.Add(lblMevcutDersler);
            Controls.Add(lbMevcutDersler);
            Controls.Add(lblKayitliDersler);
            Controls.Add(lbKayitliDersler);
            Controls.Add(btnDersEkle);
            Controls.Add(btnDersCikar);
            Controls.Add(lblToplamKredi);
            Controls.Add(lblToplamAkts);
            Controls.Add(lblDersSayisi);
            Controls.Add(btnKapat);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DersKayitForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Öğrenci Ders Kayıt";
            ResumeLayout(false);
        }

        private void LoadData()
        {
            // Öğrencileri yükle
            cbOgrenciler.Items.Clear();
            cbOgrenciler.Items.Add("-- Öğrenci Seçiniz --");

            var ogrenciler = ogrenciYonetici.TumOgrenciler();
            foreach (var ogrenci in ogrenciler.OrderBy(o => o.Ad))
            {
                cbOgrenciler.Items.Add($"{ogrenci.OgrenciNo} - {ogrenci.TamAd()}");
            }

            cbOgrenciler.SelectedIndex = 0;

            // Mevcut dersleri yükle
            LoadMevcutDersler();
        }

        private void LoadMevcutDersler()
        {
            lbMevcutDersler.Items.Clear();
            var dersler = dersYonetici.TumDersler();

            foreach (var ders in dersler.OrderBy(d => d.Kod))
            {
                string dersTuru = ders is ZorunluDers ? "Zorunlu" : "Seçmeli";
                lbMevcutDersler.Items.Add($"{ders.Kod} - {ders.Ad} ({ders.Kredi} kr) - {dersTuru}");
            }
        }

        private void CbOgrenciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOgrenciler.SelectedIndex <= 0)
            {
                lbKayitliDersler.Items.Clear();
                lblToplamKredi.Text = "Toplam Kredi: 0";
                lblToplamAkts.Text = "Toplam AKTS: 0";
                lblDersSayisi.Text = "Ders Sayısı: 0";
                btnDersEkle.Enabled = false;
                btnDersCikar.Enabled = false;
                return;
            }

            string selectedText = cbOgrenciler.SelectedItem.ToString();
            string ogrenciNo = selectedText.Split(' ')[0];

            LoadOgrencininDersleri(ogrenciNo);
            UpdateMevcutDerslerForOgrenci(ogrenciNo);
        }

        private void UpdateMevcutDerslerForOgrenci(string ogrenciNo)
        {
            // Öğrencinin kayıtlı olmadığı dersleri göster
            lbMevcutDersler.Items.Clear();
            var tumDersler = dersYonetici.TumDersler();
            var kayitliDersKodlari = dersKayitYonetici.OgrencininDersleri(ogrenciNo)
                .Select(k => k.DersKodu).ToHashSet();

            foreach (var ders in tumDersler.OrderBy(d => d.Kod))
            {
                if (!kayitliDersKodlari.Contains(ders.Kod))
                {
                    string dersTuru = ders is ZorunluDers ? "Zorunlu" : "Seçmeli";
                    lbMevcutDersler.Items.Add($"{ders.Kod} - {ders.Ad} ({ders.Kredi} kr) - {dersTuru}");
                }
            }
        }

        private void LoadOgrencininDersleri(string ogrenciNo)
        {
            lbKayitliDersler.Items.Clear();

            var kayitliDersler = dersKayitYonetici.OgrencininDersleri(ogrenciNo);
            int toplamKredi = 0;
            int toplamAkts = 0;
            int dersSayisi = kayitliDersler.Count();

            foreach (var kayit in kayitliDersler.OrderBy(k => k.DersKodu))
            {
                var ders = dersYonetici.DersGetir(kayit.DersKodu);
                if (ders != null)
                {
                    string dersTuru = ders is ZorunluDers ? "Zorunlu" : "Seçmeli";
                    lbKayitliDersler.Items.Add($"{ders.Kod} - {ders.Ad} ({ders.Kredi} kr) - {dersTuru}");
                    toplamKredi += ders.Kredi;
                    // AKTS genellikle krediye eşittir, ders sınıfında AKTS özelliği yoksa krediyi kullanıyoruz
                    toplamAkts += ders.Kredi; // Ders sınıfında AKTS özelliği varsa ders.Akts kullanılabilir
                }
            }

            // Bilgileri güncelle
            lblToplamKredi.Text = $"Toplam Kredi: {toplamKredi}/{MAKSIMUM_KREDI}";
            lblToplamAkts.Text = $"Toplam AKTS: {toplamAkts}";

            // Ders sayısı kontrolü ve renk ayarı
            if (dersSayisi >= MAKSIMUM_DERS_SAYISI)
            {
                lblDersSayisi.Text = $"Ders Sayısı: {dersSayisi}/{MAKSIMUM_DERS_SAYISI} (LİMİT DOLDU!)";
                lblDersSayisi.ForeColor = Color.Red;
            }
            else
            {
                lblDersSayisi.Text = $"Ders Sayısı: {dersSayisi}/{MAKSIMUM_DERS_SAYISI}";
                lblDersSayisi.ForeColor = Color.Black;
            }

            // Kredi durumuna göre renk ayarla
            if (toplamKredi >= MAKSIMUM_KREDI)
            {
                lblToplamKredi.ForeColor = Color.Red;
            }
            else
            {
                lblToplamKredi.ForeColor = Color.Black;
            }
        }

        private void LbMevcutDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDersEkle.Enabled = (cbOgrenciler.SelectedIndex > 0 && lbMevcutDersler.SelectedItem != null);
        }

        private void BtnDersEkle_Click(object sender, EventArgs e)
        {
            if (cbOgrenciler.SelectedIndex <= 0)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lbMevcutDersler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen eklenecek dersi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedOgrenci = cbOgrenciler.SelectedItem.ToString();
            string ogrenciNo = selectedOgrenci.Split(' ')[0];

            string selectedDers = lbMevcutDersler.SelectedItem.ToString();
            string dersKodu = selectedDers.Split(' ')[0];

            // Ders sayısı kontrolü
            var mevcutDersler = dersKayitYonetici.OgrencininDersleri(ogrenciNo);
            if (mevcutDersler.Count() >= MAKSIMUM_DERS_SAYISI)
            {
                MessageBox.Show($"Maksimum ders sayısı aşılacak!\n\nMevcut Ders Sayısı: {mevcutDersler.Count()}\nMaksimum Limit: {MAKSIMUM_DERS_SAYISI}",
                    "Ders Sayısı Limiti Aşımı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kredi kontrolü
            int mevcutKredi = dersKayitYonetici.OgrencininToplamKredisi(ogrenciNo);
            var ders = dersYonetici.DersGetir(dersKodu);

            if (mevcutKredi + ders.Kredi > MAKSIMUM_KREDI)
            {
                MessageBox.Show($"Kredi limiti aşılacak!\n\nMevcut Kredi: {mevcutKredi}\nEklenecek Ders Kredisi: {ders.Kredi}\nToplam Olacak: {mevcutKredi + ders.Kredi}\nMaksimum Limit: {MAKSIMUM_KREDI}\n\nKalan Kredi Hakkı: {MAKSIMUM_KREDI - mevcutKredi}",
                    "Kredi Limiti Aşımı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dersKayitYonetici.DersKaydiEkle(ogrenciNo, dersKodu))
            {
                MessageBox.Show($"Ders kaydı başarıyla eklendi!\n\nDers: {ders.Ad}\nKredi: {ders.Kredi}\nYeni Toplam Kredi: {mevcutKredi + ders.Kredi}/{MAKSIMUM_KREDI}\nYeni Ders Sayısı: {mevcutDersler.Count() + 1}/{MAKSIMUM_DERS_SAYISI}",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOgrencininDersleri(ogrenciNo);
                UpdateMevcutDerslerForOgrenci(ogrenciNo);
                btnDersEkle.Enabled = false;
            }
            else
            {
                MessageBox.Show("Ders kaydı eklenirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDersCikar_Click(object sender, EventArgs e)
        {
            if (cbOgrenciler.SelectedIndex <= 0)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lbKayitliDersler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen çıkarılacak dersi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedOgrenci = cbOgrenciler.SelectedItem.ToString();
            string ogrenciNo = selectedOgrenci.Split(' ')[0];

            string selectedDers = lbKayitliDersler.SelectedItem.ToString();
            string dersKodu = selectedDers.Split(' ')[0];

            var ders = dersYonetici.DersGetir(dersKodu);
            int mevcutKredi = dersKayitYonetici.OgrencininToplamKredisi(ogrenciNo);
            int mevcutDersSayisi = dersKayitYonetici.OgrencininDersleri(ogrenciNo).Count();

            DialogResult result = MessageBox.Show($"Seçili dersi çıkarmak istediğinizden emin misiniz?\n\nDers: {ders.Ad}\nKredi: {ders.Kredi}\nYeni Toplam Kredi: {mevcutKredi - ders.Kredi}/{MAKSIMUM_KREDI}\nYeni Ders Sayısı: {mevcutDersSayisi - 1}/{MAKSIMUM_DERS_SAYISI}",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dersKayitYonetici.DersKaydiIptal(ogrenciNo, dersKodu))
                {
                    MessageBox.Show("Ders kaydı başarıyla iptal edildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOgrencininDersleri(ogrenciNo);
                    UpdateMevcutDerslerForOgrenci(ogrenciNo);
                    btnDersCikar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Ders kaydı iptal edilirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LbMevcutDersler_DoubleClick(object sender, EventArgs e)
        {
            BtnDersEkle_Click(sender, e);
        }

        private void LbKayitliDersler_DoubleClick(object sender, EventArgs e)
        {
            btnDersCikar.Enabled = true;
            BtnDersCikar_Click(sender, e);
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMevcutDersler_Click(object sender, EventArgs e)
        {

        }
    }
}