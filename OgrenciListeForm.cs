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
    public partial class OgrenciListeForm : Form
    {
        private OgrenciYonetici ogrenciYonetici;
        private NotYonetici notYonetici; // Not silme için
        private DersKayitYonetici dersKayitYonetici; // Ders kayıt silme için
        private SistemYonetici sistemYonetici; // Tüm veriler için
        private DataGridView dgvOgrenciler;
        private TextBox txtArama;

        public OgrenciListeForm(SistemYonetici sistemYonetici)
        {
            this.sistemYonetici = sistemYonetici;
            this.ogrenciYonetici = sistemYonetici.OgrenciYoneticisi;
            this.notYonetici = sistemYonetici.NotYoneticisi;
            this.dersKayitYonetici = sistemYonetici.DersKayitYoneticisi;
            InitializeComponent();
            OgrencileriYukle();
        }

        private void InitializeComponent()
        {
            lblBaslik = new Label();
            lblArama = new Label();
            txtArama = new TextBox();
            btnYenile = new Button();
            dgvOgrenciler = new DataGridView();
            lblToplam = new Label();
            btnDetay = new Button();
            btnSil = new Button(); // YENİ: Silme butonu
            btnKapat = new Button();
            ((ISupportInitialize)dgvOgrenciler).BeginInit();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblBaslik.Location = new Point(300, 20);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(200, 25);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "ÖĞRENCİ LİSTESİ";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArama
            // 
            lblArama.Location = new Point(30, 60);
            lblArama.Name = "lblArama";
            lblArama.Size = new Size(150, 20);
            lblArama.TabIndex = 1;
            lblArama.Text = "Arama (Ad, Soyad veya No):";
            // 
            // txtArama
            // 
            txtArama.Location = new Point(190, 60);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(200, 31);
            txtArama.TabIndex = 2;
            txtArama.TextChanged += TxtArama_TextChanged;
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.DodgerBlue;
            btnYenile.ForeColor = Color.White;
            btnYenile.Location = new Point(410, 58);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(80, 33);
            btnYenile.TabIndex = 3;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += BtnYenile_Click;
            // 
            // dgvOgrenciler
            // 
            dgvOgrenciler.AllowUserToAddRows = false;
            dgvOgrenciler.AllowUserToDeleteRows = false;
            dgvOgrenciler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOgrenciler.BackgroundColor = Color.White;
            dgvOgrenciler.BorderStyle = BorderStyle.Fixed3D;
            dgvOgrenciler.ColumnHeadersHeight = 34;
            dgvOgrenciler.Location = new Point(30, 100);
            dgvOgrenciler.MultiSelect = false;
            dgvOgrenciler.Name = "dgvOgrenciler";
            dgvOgrenciler.ReadOnly = true;
            dgvOgrenciler.RowHeadersVisible = false;
            dgvOgrenciler.RowHeadersWidth = 62;
            dgvOgrenciler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOgrenciler.Size = new Size(720, 400);
            dgvOgrenciler.TabIndex = 4;
            // 
            // lblToplam
            // 
            lblToplam.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblToplam.Location = new Point(30, 528);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(200, 20);
            lblToplam.TabIndex = 5;
            lblToplam.Text = "Toplam Öğrenci: 0";
            // 
            // btnDetay
            // 
            btnDetay.BackColor = Color.Green;
            btnDetay.ForeColor = Color.White;
            btnDetay.Location = new Point(380, 518);
            btnDetay.Name = "btnDetay";
            btnDetay.Size = new Size(120, 36);
            btnDetay.TabIndex = 6;
            btnDetay.Text = "Öğrenci Detayı";
            btnDetay.UseVisualStyleBackColor = false;
            btnDetay.Click += BtnDetay_Click;
            // 
            // btnSil - YENİ BUTON
            // 
            btnSil.BackColor = Color.Red;
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(520, 518);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(100, 36);
            btnSil.TabIndex = 7;
            btnSil.Text = "Öğrenci Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += BtnSil_Click;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.IndianRed;
            btnKapat.ForeColor = Color.White;
            btnKapat.Location = new Point(640, 518);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(80, 36);
            btnKapat.TabIndex = 8;
            btnKapat.Text = "Kapat";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += BtnKapat_Click;
            // 
            // OgrenciListeForm
            // 
            ClientSize = new Size(864, 656);
            Controls.Add(lblBaslik);
            Controls.Add(lblArama);
            Controls.Add(txtArama);
            Controls.Add(btnYenile);
            Controls.Add(dgvOgrenciler);
            Controls.Add(lblToplam);
            Controls.Add(btnDetay);
            Controls.Add(btnSil); // YENİ buton eklendi
            Controls.Add(btnKapat);
            MinimumSize = new Size(800, 600);
            Name = "OgrenciListeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Öğrenci Listesi";
            ((ISupportInitialize)dgvOgrenciler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void OgrencileriYukle()
        {
            var ogrenciler = ogrenciYonetici.TumOgrenciler();
            DataTable dt = new DataTable();

            dt.Columns.Add("Öğrenci No", typeof(string));
            dt.Columns.Add("Ad", typeof(string));
            dt.Columns.Add("Soyad", typeof(string));
            dt.Columns.Add("E-mail", typeof(string));

            foreach (var ogrenci in ogrenciler)
            {
                dt.Rows.Add(ogrenci.OgrenciNo, ogrenci.Ad, ogrenci.Soyad, ogrenci.Email);
            }

            dgvOgrenciler.DataSource = dt;

            // Toplam sayıyı güncelle
            var lblToplam = this.Controls.Find("lblToplam", true)[0] as Label;
            if (lblToplam != null)
            {
                lblToplam.Text = $"Toplam Öğrenci: {ogrenciler.Count}";
            }
        }

        private void TxtArama_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtArama.Text.ToLower();

            if (string.IsNullOrWhiteSpace(aramaMetni))
            {
                OgrencileriYukle();
                return;
            }

            var ogrenciler = ogrenciYonetici.TumOgrenciler()
                .Where(o => o.OgrenciNo.ToLower().Contains(aramaMetni) ||
                           o.Ad.ToLower().Contains(aramaMetni) ||
                           o.Soyad.ToLower().Contains(aramaMetni) ||
                           o.Email.ToLower().Contains(aramaMetni))
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Öğrenci No", typeof(string));
            dt.Columns.Add("Ad", typeof(string));
            dt.Columns.Add("Soyad", typeof(string));
            dt.Columns.Add("E-mail", typeof(string));

            foreach (var ogrenci in ogrenciler)
            {
                dt.Rows.Add(ogrenci.OgrenciNo, ogrenci.Ad, ogrenci.Soyad, ogrenci.Email);
            }

            dgvOgrenciler.DataSource = dt;

            // Toplam sayıyı güncelle
            var lblToplam = this.Controls.Find("lblToplam", true)[0] as Label;
            if (lblToplam != null)
            {
                lblToplam.Text = $"Toplam Öğrenci: {ogrenciler.Count}";
            }
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            txtArama.Text = "";
            OgrencileriYukle();
        }

        private void BtnDetay_Click(object sender, EventArgs e)
        {
            if (dgvOgrenciler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ogrenciNo = dgvOgrenciler.SelectedRows[0].Cells["Öğrenci No"].Value.ToString();
            var ogrenci = ogrenciYonetici.OgrenciGetir(ogrenciNo);

            if (ogrenci != null)
            {
                // Öğrencinin kayıtlı olduğu dersleri al
                var kayitliDersler = dersKayitYonetici.OgrencininDersleri(ogrenciNo);
                var ogrenciNotlari = notYonetici.OgrenciNotlari(ogrenciNo);

                string detay = $"ÖĞRENCİ DETAY BİLGİLERİ\n\n" +
                              $"Öğrenci No: {ogrenci.OgrenciNo}\n" +
                              $"Ad: {ogrenci.Ad}\n" +
                              $"Soyad: {ogrenci.Soyad}\n" +
                              $"E-mail: {ogrenci.Email}\n" +
                              $"Kayıtlı Ders Sayısı: {kayitliDersler.Count}\n" +
                              $"Not Girilen Ders Sayısı: {ogrenciNotlari.Count}\n" +
                              $"Kayıt Tarihi: {DateTime.Now.ToString("dd.MM.yyyy")}";

                MessageBox.Show(detay, "Öğrenci Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // YENİ: Öğrenci silme işlemi
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (dgvOgrenciler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek öğrenciyi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ogrenciNo = dgvOgrenciler.SelectedRows[0].Cells["Öğrenci No"].Value.ToString();
            var ogrenci = ogrenciYonetici.OgrenciGetir(ogrenciNo);

            if (ogrenci == null)
            {
                MessageBox.Show("Öğrenci bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Silme onayı iste
            var result = MessageBox.Show(
                $"'{ogrenci.Ad} {ogrenci.Soyad}' ({ogrenci.OgrenciNo}) adlı öğrenciyi ve bu öğrenciye ait TÜM VERİLERİ (notlar, ders kayıtları) silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!",
                "Öğrenci Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 1. Önce öğrencinin notlarını sil
                    var ogrenciNotlari = notYonetici.OgrenciNotlari(ogrenciNo);
                    foreach (var not in ogrenciNotlari.ToList()) // ToList() ile kopya oluştur
                    {
                        notYonetici.NotSil(not.OgrenciNo, not.DersKodu);
                    }

                    // 2. Öğrencinin ders kayıtlarını sil
                    var kayitliDersler = dersKayitYonetici.OgrencininDersleri(ogrenciNo);
                    foreach ( var dersKodu in kayitliDersler.ToList()) // ToList() ile kopya oluştur
                    {
                       string a= dersKodu.ToString(); // Ders kodunu string'e çevir
                        dersKayitYonetici.DersKaydiIptal(ogrenciNo, a);
                    }

                    // 3. Son olarak öğrenciyi sil
                    bool basarili = ogrenciYonetici.OgrenciSil(ogrenciNo);

                    if (basarili)
                    {
                        MessageBox.Show(
                            $"Öğrenci '{ogrenci.Ad} {ogrenci.Soyad}' ve tüm verileri başarıyla silindi!",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // 4. Verileri dosyaya kaydet
                        var veriYoneticisi = new VeriYoneticisi();
                        veriYoneticisi.TumVerileriKaydet(sistemYonetici);

                        // 5. Listeyi yenile
                        OgrencileriYukle();
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci silinirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Öğrenci silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
