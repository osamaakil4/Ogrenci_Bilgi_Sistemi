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
    public partial class DersOlusturForm : Form
    {
        private DersYonetici dersYonetici;
        private TextBox txtDersKodu;
        private TextBox txtDersAdi;
        private TextBox txtKredi;
        private TextBox txtAkts; // AKTS alanı eklendi
        private ComboBox cmbDonem; // Dönem ComboBox olarak değiştirildi
        private RadioButton rbZorunlu;
        private RadioButton rbSecmeli;
        private Label lblBaslik;
        private Label lblDersKodu;
        private Label lblDersAdi;
        private Label lblKredi;
        private Label lblAkts; // AKTS label'i eklendi
        private Label lblDonem;
        private Label lblDersTuru;
        private GroupBox gbDersTuru;
        private Button btnKaydet;
        private Button btnIptal;

        public DersOlusturForm(DersYonetici dersYonetici)
        {
            this.dersYonetici = dersYonetici;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblBaslik = new Label();
            this.lblDersKodu = new Label();
            this.txtDersKodu = new TextBox();
            this.lblDersAdi = new Label();
            this.txtDersAdi = new TextBox();
            this.lblKredi = new Label();
            this.txtKredi = new TextBox();
            this.lblAkts = new Label();
            this.txtAkts = new TextBox();
            this.lblDonem = new Label();
            this.cmbDonem = new ComboBox();
            this.lblDersTuru = new Label();
            this.gbDersTuru = new GroupBox();
            this.rbZorunlu = new RadioButton();
            this.rbSecmeli = new RadioButton();
            this.btnKaydet = new Button();
            this.btnIptal = new Button();
            this.gbDersTuru.SuspendLayout();
            SuspendLayout();

            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblBaslik.Location = new Point(125, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(200, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "YENİ DERS OLUŞTUR";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblDersKodu
            // 
            this.lblDersKodu.Location = new Point(30, 70);
            this.lblDersKodu.Name = "lblDersKodu";
            this.lblDersKodu.Size = new Size(100, 20);
            this.lblDersKodu.TabIndex = 1;
            this.lblDersKodu.Text = "Ders Kodu:";

            // 
            // txtDersKodu
            // 
            this.txtDersKodu.Location = new Point(140, 70);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Size = new Size(250, 31);
            this.txtDersKodu.TabIndex = 2;

            // 
            // lblDersAdi
            // 
            this.lblDersAdi.Location = new Point(30, 110);
            this.lblDersAdi.Name = "lblDersAdi";
            this.lblDersAdi.Size = new Size(100, 20);
            this.lblDersAdi.TabIndex = 3;
            this.lblDersAdi.Text = "Ders Adı:";

            // 
            // txtDersAdi
            // 
            this.txtDersAdi.Location = new Point(140, 110);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Size = new Size(250, 31);
            this.txtDersAdi.TabIndex = 4;

            // 
            // lblKredi
            // 
            this.lblKredi.Location = new Point(30, 150);
            this.lblKredi.Name = "lblKredi";
            this.lblKredi.Size = new Size(100, 20);
            this.lblKredi.TabIndex = 5;
            this.lblKredi.Text = "Kredi:";

            // 
            // txtKredi
            // 
            this.txtKredi.Location = new Point(140, 150);
            this.txtKredi.Name = "txtKredi";
            this.txtKredi.Size = new Size(100, 31);
            this.txtKredi.TabIndex = 6;

            // 
            // lblAkts
            // 
            this.lblAkts.Location = new Point(30, 190);
            this.lblAkts.Name = "lblAkts";
            this.lblAkts.Size = new Size(100, 20);
            this.lblAkts.TabIndex = 7;
            this.lblAkts.Text = "AKTS:";

            // 
            // txtAkts
            // 
            this.txtAkts.Location = new Point(140, 190);
            this.txtAkts.Name = "txtAkts";
            this.txtAkts.Size = new Size(100, 31);
            this.txtAkts.TabIndex = 8;

            // 
            // lblDonem
            // 
            this.lblDonem.Location = new Point(30, 230);
            this.lblDonem.Name = "lblDonem";
            this.lblDonem.Size = new Size(100, 20);
            this.lblDonem.TabIndex = 9;
            this.lblDonem.Text = "Dönem:";

            // 
            // cmbDonem
            // 
            this.cmbDonem.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDonem.Location = new Point(140, 230);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Size = new Size(150, 33);
            this.cmbDonem.TabIndex = 10;

            // 
            // lblDersTuru
            // 
            this.lblDersTuru.Font = new Font("Arial", 9F, FontStyle.Bold);
            this.lblDersTuru.Location = new Point(30, 280);
            this.lblDersTuru.Name = "lblDersTuru";
            this.lblDersTuru.Size = new Size(100, 20);
            this.lblDersTuru.TabIndex = 11;
            this.lblDersTuru.Text = "Ders Türü:";

            // 
            // gbDersTuru
            // 
            this.gbDersTuru.Controls.Add(this.rbZorunlu);
            this.gbDersTuru.Controls.Add(this.rbSecmeli);
            this.gbDersTuru.Location = new Point(140, 270);
            this.gbDersTuru.Name = "gbDersTuru";
            this.gbDersTuru.Size = new Size(250, 50);
            this.gbDersTuru.TabIndex = 12;
            this.gbDersTuru.TabStop = false;

            // 
            // rbZorunlu
            // 
            this.rbZorunlu.Checked = true;
            this.rbZorunlu.Location = new Point(10, 20);
            this.rbZorunlu.Name = "rbZorunlu";
            this.rbZorunlu.Size = new Size(80, 20);
            this.rbZorunlu.TabIndex = 0;
            this.rbZorunlu.TabStop = true;
            this.rbZorunlu.Text = "Zorunlu";

            // 
            // rbSecmeli
            // 
            this.rbSecmeli.Location = new Point(100, 20);
            this.rbSecmeli.Name = "rbSecmeli";
            this.rbSecmeli.Size = new Size(80, 20);
            this.rbSecmeli.TabIndex = 1;
            this.rbSecmeli.Text = "Seçmeli";

            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = Color.Green;
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(140, 340);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(100, 30);
            this.btnKaydet.TabIndex = 13;
            this.btnKaydet.Text = "Ders Oluştur";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += this.BtnKaydet_Click;

            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = Color.Gray;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(260, 340);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(80, 30);
            this.btnIptal.TabIndex = 14;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += this.BtnIptal_Click;

            // 
            // DersOlusturForm
            // 
            this.ClientSize = new Size(428, 400);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.lblDersKodu);
            this.Controls.Add(this.txtDersKodu);
            this.Controls.Add(this.lblDersAdi);
            this.Controls.Add(this.txtDersAdi);
            this.Controls.Add(this.lblKredi);
            this.Controls.Add(this.txtKredi);
            this.Controls.Add(this.lblAkts);
            this.Controls.Add(this.txtAkts);
            this.Controls.Add(this.lblDonem);
            this.Controls.Add(this.cmbDonem);
            this.Controls.Add(this.lblDersTuru);
            this.Controls.Add(this.gbDersTuru);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DersOlusturForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Yeni Ders Oluştur";
            this.Load += this.DersOlusturForm_Load;
            this.gbDersTuru.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DersOlusturForm_Load(object sender, EventArgs e)
        {
            // Dönem ComboBox'ını doldur
            cmbDonem.Items.Clear();
            cmbDonem.Items.Add("Güz");
            cmbDonem.Items.Add("Bahar");
            cmbDonem.Items.Add("Yaz");
            cmbDonem.SelectedIndex = 0; // Varsayılan olarak "Güz" seçili
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Doğrulama
                if (string.IsNullOrWhiteSpace(txtDersKodu.Text))
                {
                    MessageBox.Show("Ders kodu boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDersKodu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDersAdi.Text))
                {
                    MessageBox.Show("Ders adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDersAdi.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtKredi.Text) || !int.TryParse(txtKredi.Text, out int kredi) || kredi <= 0)
                {
                    MessageBox.Show("Geçerli bir kredi değeri giriniz (0'dan büyük)!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKredi.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAkts.Text) || !int.TryParse(txtAkts.Text, out int akts) || akts <= 0)
                {
                    MessageBox.Show("Geçerli bir AKTS değeri giriniz (0'dan büyük)!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAkts.Focus();
                    return;
                }

                if (cmbDonem.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir dönem seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDonem.Focus();
                    return;
                }

                // Ders var mı kontrol et
                if (dersYonetici.DersVarMi(txtDersKodu.Text.Trim()))
                {
                    MessageBox.Show("Bu ders kodu zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDersKodu.Focus();
                    return;
                }

                // Ders oluştur
                Ders yeniDers;
                string secilenDonem = cmbDonem.SelectedItem.ToString();

                if (rbZorunlu.Checked)
                {
                    yeniDers = new ZorunluDers(
                        txtDersKodu.Text.Trim(),
                        txtDersAdi.Text.Trim(),
                        kredi,
                        akts,
                        secilenDonem
                    );
                }
                else
                {
                    yeniDers = new SecmeliDers(
                        txtDersKodu.Text.Trim(),
                        txtDersAdi.Text.Trim(),
                        kredi,
                        akts,
                        secilenDonem
                    );
                }

                if (dersYonetici.DersEkle(yeniDers))
                {
                    MessageBox.Show($"Ders başarıyla oluşturuldu!\n\nDers Kodu: {txtDersKodu.Text.Trim()}\nDers Adı: {txtDersAdi.Text.Trim()}\nKredi: {kredi}\nAKTS: {akts}\nDönem: {secilenDonem}\nTürü: {(rbZorunlu.Checked ? "Zorunlu" : "Seçmeli")}",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ders oluşturulurken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ders oluşturulurken beklenmeyen bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}