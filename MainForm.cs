using System;
using System.Windows.Forms;
namespace Ogrenci_Bilgi_Sistemi
{

    public partial class MainForm : Form
    {
        private SistemYonetici sistemYonetici;

        public MainForm()
        {
            InitializeComponent();
            sistemYonetici = new SistemYonetici();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBaslik = new Label();
            btnOgrenciKaydet = new Button();
            btnDersOlustur = new Button();
            btnDersKayit = new Button();
            btnNotGir = new Button();
            btnTranskript = new Button();
            btnOgrenciListele = new Button();
            btnDersListele = new Button();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblBaslik.Location = new Point(137, 18);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(300, 30);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "ÖĞRENCİ BİLGİ SİSTEMİ";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOgrenciKaydet
            // 
            btnOgrenciKaydet.Location = new Point(49, 100);
            btnOgrenciKaydet.Name = "btnOgrenciKaydet";
            btnOgrenciKaydet.Size = new Size(150, 40);
            btnOgrenciKaydet.TabIndex = 1;
            btnOgrenciKaydet.Text = "Öğrenci Kaydet";
            btnOgrenciKaydet.Click += BtnOgrenciKaydet_Click;
            // 
            // btnDersOlustur
            // 
            btnDersOlustur.Location = new Point(222, 100);
            btnDersOlustur.Name = "btnDersOlustur";
            btnDersOlustur.Size = new Size(150, 40);
            btnDersOlustur.TabIndex = 2;
            btnDersOlustur.Text = "Ders Oluştur";
            btnDersOlustur.Click += BtnDersOlustur_Click;
            // 
            // btnDersKayit
            // 
            btnDersKayit.Location = new Point(49, 160);
            btnDersKayit.Name = "btnDersKayit";
            btnDersKayit.Size = new Size(150, 40);
            btnDersKayit.TabIndex = 8;
            btnDersKayit.Text = "Ders Kayıt";
            btnDersKayit.Click += BtnDersKayit_Click;
            // 
            // btnNotGir
            // 
            btnNotGir.Location = new Point(405, 100);
            btnNotGir.Name = "btnNotGir";
            btnNotGir.Size = new Size(150, 40);
            btnNotGir.TabIndex = 3;
            btnNotGir.Text = "Not Gir";
            btnNotGir.Click += BtnNotGir_Click;
            // 
            // btnTranskript
            // 
            btnTranskript.Location = new Point(222, 234);
            btnTranskript.Name = "btnTranskript";
            btnTranskript.Size = new Size(150, 40);
            btnTranskript.TabIndex = 4;
            btnTranskript.Text = "Transkript Al";
            btnTranskript.Click += BtnTranskript_Click;
            // 
            // btnOgrenciListele
            // 
            btnOgrenciListele.Location = new Point(222, 160);
            btnOgrenciListele.Name = "btnOgrenciListele";
            btnOgrenciListele.Size = new Size(150, 40);
            btnOgrenciListele.TabIndex = 5;
            btnOgrenciListele.Text = "Öğrenci Listele";
            btnOgrenciListele.Click += BtnOgrenciListele_Click;
            // 
            // btnDersListele
            // 
            btnDersListele.Location = new Point(405, 160);
            btnDersListele.Name = "btnDersListele";
            btnDersListele.Size = new Size(150, 40);
            btnDersListele.TabIndex = 6;
            btnDersListele.Text = "Ders Listele";
            btnDersListele.Click += BtnDersListele_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = Color.IndianRed;
            btnCikis.ForeColor = Color.White;
            btnCikis.Location = new Point(222, 318);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(150, 40);
            btnCikis.TabIndex = 9;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += BtnCikis_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(600, 400);
            Controls.Add(lblBaslik);
            Controls.Add(btnOgrenciKaydet);
            Controls.Add(btnDersOlustur);
            Controls.Add(btnDersKayit);
            Controls.Add(btnNotGir);
            Controls.Add(btnTranskript);
            Controls.Add(btnOgrenciListele);
            Controls.Add(btnDersListele);
            Controls.Add(btnCikis);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Öğrenci Bilgi Sistemi";
            Load += MainForm_Load_1;
            ResumeLayout(false);
        }

        private void BtnOgrenciKaydet_Click(object sender, EventArgs e)
        {
            OgrenciKayitForm form = new OgrenciKayitForm(sistemYonetici.OgrenciYoneticisi);
            form.ShowDialog();
        }

        private void BtnDersOlustur_Click(object sender, EventArgs e)
        {
            DersOlusturForm form = new DersOlusturForm(sistemYonetici.DersYoneticisi);
            form.ShowDialog();
        }

        // Yeni metod - Ders Kayıt formu açma
        private void BtnDersKayit_Click(object sender, EventArgs e)
        {
            try
            {
                DersKayitForm form = new DersKayitForm(
                    sistemYonetici.DersKayitYoneticisi,
                    sistemYonetici.OgrenciYoneticisi,
                    sistemYonetici.DersYoneticisi
                );
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ders Kayıt formu açılırken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNotGir_Click(object sender, EventArgs e)
        {
            try
            {
                // Doğru sırayla parametreleri geçirin
                NotGirForm form = new NotGirForm(
                    sistemYonetici.OgrenciYoneticisi,
                    sistemYonetici.DersYoneticisi,
                    sistemYonetici.NotYoneticisi
                );
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Not Gir formu açılırken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTranskript_Click(object sender, EventArgs e)
        {
            TranskriptForm form = new TranskriptForm(sistemYonetici.TranskriptYoneticisi, sistemYonetici.OgrenciYoneticisi);
            form.ShowDialog();
        }

        private void BtnOgrenciListele_Click(object sender, EventArgs e)
        {
            OgrenciListeForm form = new OgrenciListeForm(sistemYonetici.OgrenciYoneticisi);
            form.ShowDialog();
        }

        private void BtnDersListele_Click(object sender, EventArgs e)
        {
            DersListeForm form = new DersListeForm(sistemYonetici.DersYoneticisi);
            form.ShowDialog();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Programdan çıkmak istediğinizden emin misiniz?",
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Örnek veriler yükle
            sistemYonetici.OrnekVerilerYukle();
            MessageBox.Show("Sistem başlatıldı ve örnek veriler yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        // Field'lar - Designer için gerekli
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnOgrenciKaydet;
        private System.Windows.Forms.Button btnDersOlustur;
        private System.Windows.Forms.Button btnDersKayit; 
        private System.Windows.Forms.Button btnNotGir;
        private System.Windows.Forms.Button btnTranskript;
        private System.Windows.Forms.Button btnOgrenciListele;
        private System.Windows.Forms.Button btnDersListele;
        private System.Windows.Forms.Button btnCikis;
    }
}
