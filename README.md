# Öğrenci Bilgi Sistemi (Student Information System)

## 📋 Proje Açıklaması

Bu proje, C# Windows Forms kullanılarak geliştirilmiş kapsamlı bir öğrenci bilgi yönetim sistemidir. Sistem, öğrenci kayıtları, ders yönetimi, not girişi ve transkript oluşturma gibi temel akademik işlemleri destekler.

## 🚀 Özellikler

### 🎓 Öğrenci Yönetimi
- Yeni öğrenci kaydı ekleme
- Öğrenci bilgilerini görüntüleme ve düzenleme
- Öğrenci listesi ve arama işlemleri

### 📚 Ders Yönetimi
- Zorunlu ve seçmeli ders oluşturma
- Ders bilgilerini düzenleme
- Ders silme işlemleri
- Dönem bazlı ders filtreleme

### 📝 Ders Kayıt Sistemi
- Öğrenci ders kayıt işlemleri
- Kredi limiti kontrolü (maksimum 30 kredi)
- Ders sayısı limiti kontrolü (maksimum 10 ders)
- Otomatik kayıt doğrulama

### 📊 Not Yönetimi
- Vize ve final notu girişi
- Otomatik harf notu hesaplama
- GANO (Genel Akademik Not Ortalaması) hesaplama
- Not güncelleme işlemleri

### 📄 Transkript Sistemi
- Detaylı akademik transkript oluşturma
- GANO ve AGNO hesaplamaları
- PDF'e aktarım desteği

### 💾 Veri Yönetimi
- JSON formatında veri saklama
- Otomatik veri yedekleme
- Sistem başlangıcında veri yükleme

## 🏗️ Mimari ve Tasarım

### Nesne Yönelimli Programlama Prensipleri
- **Kalıtım (Inheritance)**: `Ders` abstract sınıfından türetilen `ZorunluDers` ve `SecmeliDers` sınıfları
- **Polimorfizm**: Ders türlerine göre farklı davranışlar
- **Encapsulation**: Private alanlar ve public property'ler
- **Abstraction**: Abstract `Ders` sınıfı ve `IRaporlanabilir` interface

### Kullanılan Tasarım Desenleri
- **Manager Pattern**: Her veri türü için ayrı yönetici sınıfları
- **Single Responsibility**: Her sınıfın tek bir sorumluluğu
- **Data Transfer Object**: Veri saklama için ayrı veri sınıfları

## 📁 Proje Yapısı

```
Ogrenci_Bilgi_Sistemi/
├── Forms/                          # Windows Forms dosyaları
│   ├── MainForm.cs                 # Ana form
│   ├── OgrenciKayitForm.cs         # Öğrenci kayıt formu
│   ├── DersOlusturForm.cs          # Ders oluşturma formu
│   ├── DersKayitForm.cs            # Ders kayıt formu
│   ├── NotGirForm.cs               # Not giriş formu
│   ├── TranskriptForm.cs           # Transkript formu
│   ├── OgrenciListeForm.cs         # Öğrenci liste formu
│   └── DersListeForm.cs            # Ders liste formu
├── Temel_Siniflar/                 # Temel veri sınıfları
│   ├── Ogrenci.cs                  # Öğrenci sınıfı
│   ├── Ders.cs                     # Abstract ders sınıfı
│   ├── ZorunluDers.cs              # Zorunlu ders sınıfı
│   ├── SecmeliDers.cs              # Seçmeli ders sınıfı
│   ├── Not.cs                      # Not sınıfı
│   ├── OgrenciDersKayit.cs         # Ders kayıt sınıfı
│   └── IRaporlanabilir.cs          # Rapor interface'i
└── Yonetici_Siniflar/              # İş mantığı sınıfları
    ├── SistemYonetici.cs           # Ana sistem yöneticisi
    ├── OgrenciYonetici.cs          # Öğrenci yöneticisi
    ├── DersYonetici.cs             # Ders yöneticisi
    ├── NotYonetici.cs              # Not yöneticisi
    ├── DersKayitYonetici.cs        # Ders kayıt yöneticisi
    ├── TranskriptYonetici.cs       # Transkript yöneticisi
    └── VeriYoneticisi.cs           # Veri yöneticisi
```

## 🛠️ Teknik Gereksinimler

- **Framework**: .NET Framework 4.7.2 veya üzeri
- **UI Framework**: Windows Forms
- **Veri Formatı**: JSON
- **IDE**: Visual Studio 2019 veya üzeri

## 📋 Kurulum

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/kullaniciadi/ogrenci-bilgi-sistemi.git
   ```

2. **Visual Studio'da açın:**
   - Solution dosyasını (.sln) Visual Studio ile açın

3. **Projeyi derleyin:**
   - Build → Build Solution (Ctrl+Shift+B)

4. **Çalıştırın:**
   - Debug → Start Debugging (F5)

## 🔧 Kullanım

### İlk Çalıştırma
- Sistem ilk kez çalıştırıldığında örnek veriler otomatik olarak yüklenir
- Veriler `%APPDATA%/OgrenciBilgiSistemi/` klasöründe saklanır

### Temel İşlemler

#### Öğrenci Ekleme
1. Ana menüden "Öğrenci Kaydet" butonuna tıklayın
2. Gerekli bilgileri doldurun
3. "Kaydet" butonuna tıklayın

#### Ders Oluşturma
1. Ana menüden "Ders Oluştur" butonuna tıklayın
2. Ders bilgilerini girin
3. Zorunlu/Seçmeli seçimini yapın
4. "Ders Oluştur" butonuna tıklayın

#### Ders Kayıt İşlemi
1. Ana menüden "Ders Kayıt" butonuna tıklayın
2. Öğrenciyi seçin
3. Dersi seçip "Ders Ekle" butonuna tıklayın
4. Sistem otomatik olarak kredi ve ders sayısı kontrolü yapar

#### Not Girişi
1. Ana menüden "Not Gir" butonuna tıklayın
2. Öğrenci ve dersi seçin
3. Vize ve final notlarını girin
4. Sistem otomatik olarak harf notunu hesaplar

## 📊 Not Sistemi

| Puan Aralığı | Harf Notu | Puan Karşılığı |
|--------------|-----------|----------------|
| 90-100       | AA        | 4.0            |
| 85-89        | BA        | 3.5            |
| 75-84        | BB        | 3.0            |
| 70-74        | CB        | 2.5            |
| 60-69        | CC        | 2.0            |
| 55-59        | DC        | 1.5            |
| 50-54        | DD        | 1.0            |
| 0-49         | FF        | 0.0            |

## 📈 Veri Yönetimi

### Otomatik Kaydetme
- Her işlem sonrası veriler otomatik olarak JSON formatında kaydedilir
- Uygulama kapatılırken tüm veriler güvenceye alınır

### Veri Konumu
```
%APPDATA%/OgrenciBilgiSistemi/
├── ogrenciler.json      # Öğrenci verileri
├── dersler.json         # Ders verileri
├── notlar.json          # Not verileri
└── derskayitlari.json   # Ders kayıt verileri
```

## 🧪 Test Verileri

Sistem, test amaçlı olarak aşağıdaki örnek verilerle gelir:

**Öğrenciler:**
- 2021001 - Ahmet Yılmaz
- 2021002 - Fatma Kaya
- 2021003 - Mehmet Demir

**Dersler:**
- CS101 - Programlama Temelleri (Zorunlu, 4 kredi)
- CS102 - Veri Yapıları (Zorunlu, 3 kredi)
- CS201 - Web Programlama (Seçmeli, 3 kredi)
- CS103 - Algoritma Analizi (Zorunlu, 4 kredi)
- CS202 - Mobil Programlama (Seçmeli, 3 kredi)

## 🔄 Sistem Limitleri

- **Maksimum kredi limiti**: 30 kredi/dönem
- **Maksimum ders sayısı**: 10 ders/dönem
- **Not aralığı**: 0-100
- **Öğrenci numarası**: Benzersiz olmalı

## 🐛 Bilinen Sorunlar

- Çok büyük veri setlerinde performans düşüşü yaşanabilir
- Ağ bağlantısı gerektirmez (offline çalışır)

## 🤝 Katkıda Bulunma

1. Bu repository'yi fork edin
2. Feature branch oluşturun (`git checkout -b feature/YeniOzellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/YeniOzellik`)
5. Pull Request oluşturun

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.

## 📞 İletişim

- **Geliştirici**: Muhammed Usame Akil
- **E-posta**: osamaakil4@gmail.com
- **GitHub**: https://github.com/osamaakil4

## 🔄 Versiyon Geçmişi

### v1.0.0 (İlk Sürüm)
- Temel öğrenci, ders ve not yönetimi
- Windows Forms arayüzü
- JSON veri saklama
- Transkript oluşturma

---

**Not**: Bu sistem eğitim amaçlı geliştirilmiştir ve gerçek akademik ortamlarda kullanım için ek güvenlik ve performans optimizasyonları gerekebilir.
