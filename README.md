# Hasta Takip & Randevu Sistemi

Hastane ortamı için geliştirilmiş, **doktor** ve **hasta** olmak üzere iki ayrı rol paneli sunan masaüstü hasta takip ve randevu uygulaması. .NET 10 Windows Forms ile yazılmış, verilerini Microsoft SQL Server üzerinde tutar.

---

## Özellikler

Uygulama açılışta bir **seçim paneli** ile karşılar; kullanıcı buradan doktor ya da hasta girişini seçer.

### Doktor Paneli

| Özellik | Açıklama |
|---|---|
| **Giriş** | Kullanıcı adı + şifre ile doğrulama (`IsActive = 1` kontrolü yapılır) |
| **Hasta Listesi** | Doktora randevusu olan hastalar; TCKN maskeli gösterilir (`********123`) |
| **Son Randevular** | Tamamlanmış ve iptal edilmiş son 5 randevu |
| **Randevu Listeleme** | Tüm randevular; tarih aralığı ve hasta adına göre filtrelenebilir |
| **Yeni Hasta Kaydı** | TCKN, ad-soyad, doğum tarihi, cinsiyet, telefon, e-posta, adres ile kayıt |
| **Mesajlaşma** | Hastalarla birebir yazışma |
| **Duyurular** | Yayınlanmış duyuruları görüntüleme |

### Hasta Paneli

| Özellik | Açıklama |
|---|---|
| **Giriş** | 11 haneli TCKN + şifre ile doğrulama |
| **Dashboard** | Son 10 randevu + yaklaşan randevular tek ekranda |
| **Randevu Oluşturma** | Branş → doktor → tarih → saat seçimi; 09:00–17:00 arası yarım saatlik slotlar |
| **Randevularım** | Geçmiş/gelecek ayrımı ile tüm randevular, seçili randevuyu iptal etme |
| **Doktorlarım** | Randevu alınmış doktorlar ve branşları |
| **Mesajlar** | Doktorlarla yazışma |
| **Duyurular** | Hastane duyurularını okuma |


## Kullanılan Teknolojiler

- **.NET 10.0** (`net10.0-windows`)
- **Windows Forms** — nullable referans tipleri ve implicit usings açık
- **Microsoft.Data.SqlClient 6.1.3** — veri erişimi
- **Microsoft SQL Server Express** — `HastaneDB` veritabanı
- ADO.NET (`SqlCommand`, `SqlDataReader`, `SqlDataAdapter` + `DataTable`)

---

## Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
