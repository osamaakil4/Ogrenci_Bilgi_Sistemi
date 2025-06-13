using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ogrenci_Bilgi_Sistemi
{
    public partial class TranskriptForm : Form
    {
        private TranskriptYonetici transkriptYonetici;
        private OgrenciYonetici ogrenciYonetici;
        private ComboBox cmbOgrenci;
        private RichTextBox rtbTranskript;
        private Button btnIndir;

        public TranskriptForm(TranskriptYonetici transkriptYonetici, OgrenciYonetici ogrenciYonetici)
        {
            this.transkriptYonetici = transkriptYonetici;
            this.ogrenciYonetici = ogrenciYonetici;
            InitializeComponent();
            ComboBoxDoldur();
        }

        private void InitializeComponent()
        {
            this.lblBaslik = new Label();
            this.lblOgrenci = new Label();
            cmbOgrenci = new ComboBox();
            this.btnGoster = new Button();
            this.lblTranskript = new Label();
            rtbTranskript = new RichTextBox();
            this.btnIndir = new Button();
            this.btnKapat = new Button();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblBaslik.Location = new Point(200, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(300, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "TRANSKRİPT GÖRÜNTÜLEME";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.Location = new Point(30, 60);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new Size(120, 20);
            this.lblOgrenci.TabIndex = 1;
            this.lblOgrenci.Text = "Öğrenci Seçiniz:";
            // 
            // cmbOgrenci
            // 
            cmbOgrenci.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOgrenci.Location = new Point(160, 60);
            cmbOgrenci.Name = "cmbOgrenci";
            cmbOgrenci.Size = new Size(300, 33);
            cmbOgrenci.TabIndex = 2;

            // 
            // btnGoster
            // 
            this.btnGoster.BackColor = Color.DodgerBlue;
            this.btnGoster.ForeColor = Color.White;
            this.btnGoster.Location = new Point(480, 58);
            this.btnGoster.Name = "btnGoster";
            this.btnGoster.Size = new Size(120, 25);
            this.btnGoster.TabIndex = 3;
            this.btnGoster.Text = "Transkript Göster";
            this.btnGoster.UseVisualStyleBackColor = false;
            this.btnGoster.Click += this.BtnGoster_Click;
            // 
            // lblTranskript
            // 
            this.lblTranskript.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.lblTranskript.Location = new Point(30, 100);
            this.lblTranskript.Name = "lblTranskript";
            this.lblTranskript.Size = new Size(100, 20);
            this.lblTranskript.TabIndex = 4;
            this.lblTranskript.Text = "Transkript:";
            // 
            // rtbTranskript
            // 
            rtbTranskript.BackColor = Color.White;
            rtbTranskript.Font = new Font("Courier New", 10F);
            rtbTranskript.Location = new Point(30, 125);
            rtbTranskript.Name = "rtbTranskript";
            rtbTranskript.ReadOnly = true;
            rtbTranskript.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbTranskript.Size = new Size(620, 380);
            rtbTranskript.TabIndex = 5;
            rtbTranskript.Text = "";
            // 
            // btnIndir
            // 
            this.btnIndir.BackColor = Color.Green;
            this.btnIndir.ForeColor = Color.White;
            this.btnIndir.Location = new Point(450, 520);
            this.btnIndir.Name = "btnIndir";
            this.btnIndir.Size = new Size(100, 30);
            this.btnIndir.TabIndex = 6;
            this.btnIndir.Text = "İndir";
            this.btnIndir.UseVisualStyleBackColor = false;
            this.btnIndir.Click += this.BtnIndir_Click;
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = Color.IndianRed;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(570, 520);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 30);
            this.btnKapat.TabIndex = 7;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += this.BtnKapat_Click;
            // 
            // TranskriptForm
            // 
            ClientSize = new Size(678, 634);
            Controls.Add(this.lblBaslik);
            Controls.Add(this.lblOgrenci);
            Controls.Add(cmbOgrenci);
            Controls.Add(this.btnGoster);
            Controls.Add(this.lblTranskript);
            Controls.Add(rtbTranskript);
            Controls.Add(this.btnIndir);
            Controls.Add(this.btnKapat);
            MinimumSize = new Size(700, 600);
            Name = "TranskriptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transkript Görüntüleme";
            ResumeLayout(false);
        }

        private void ComboBoxDoldur()
        {
            cmbOgrenci.Items.Clear();
            foreach (var ogrenci in ogrenciYonetici.TumOgrenciler())
            {
                cmbOgrenci.Items.Add($"{ogrenci.OgrenciNo} - {ogrenci.Ad} {ogrenci.Soyad}");
            }
        }

        private void BtnGoster_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ogrenciNo = cmbOgrenci.Text.Split('-')[0].Trim();
            string transkript = transkriptYonetici.TranskriptOlustur(ogrenciNo);

            if (!string.IsNullOrEmpty(transkript))
            {
                rtbTranskript.Text = transkript;
            }
            else
            {
                rtbTranskript.Text = "Bu öğrenci için transkript oluşturulamadı veya hiç not kaydı bulunamadı.";
            }
        }

        private void BtnIndir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbTranskript.Text) ||
                rtbTranskript.Text.Contains("Bu öğrenci için transkript oluşturulamadı"))
            {
                MessageBox.Show("İndirilecek transkript bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbOgrenci.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string ogrenciNo = cmbOgrenci.Text.Split('-')[0].Trim();

                // SaveFileDialog kullanarak kullanıcının dosya konumunu seçmesini sağla
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Metin Dosyası (*.txt)|*.txt|PDF Dosyası (*.pdf)|*.pdf";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.FileName = $"Transkript_{ogrenciNo}_{DateTime.Now:yyyyMMdd_HHmmss}";
                saveFileDialog.Title = "Transkripti Kaydet";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = saveFileDialog.FileName;
                    string uzanti = Path.GetExtension(dosyaYolu).ToLower();

                    if (uzanti == ".txt")
                    {
                        // Metin dosyası olarak kaydet
                        File.WriteAllText(dosyaYolu, rtbTranskript.Text, Encoding.UTF8);
                        MessageBox.Show($"Transkript başarıyla indirildi:\n{dosyaYolu}",
                                      "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (uzanti == ".pdf")
                    {
                        // PDF olarak kaydetmek için TranskriptYonetici'deki PDFOlustur metodunu kullan
                        // Ancak bu metod şu an basit text dosyası oluşturuyor
                        // Gerçek PDF oluşturma için iTextSharp gibi kütüphaneler gerekir

                        // Şimdilik PDF uzantısıyla text dosyası oluştur
                        string pdfDosyaYolu = Path.ChangeExtension(dosyaYolu, ".txt");
                        File.WriteAllText(pdfDosyaYolu, rtbTranskript.Text, Encoding.UTF8);

                        MessageBox.Show($"Transkript metin dosyası olarak indirildi:\n{pdfDosyaYolu}\n\n" +
                                      "Not: Gerçek PDF oluşturma için ek kütüphaneler gereklidir.",
                                     "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya indirme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}