# İkinci El Eşya Satış Platformu (ASP.NET Core MVC)

Bu proje, Web Tasarımı ve Programlama II dersi için geliştirilmiş bir ikinci el eşya satış platformudur.

## Kullanılan Teknolojiler ve Mimariler
* ASP.NET Core 8.0 MVC
* Entity Framework Core (Code-First) & SQLite
* ASP.NET Core Identity (Authentication & Role-based Authorization)
* Repository Pattern & Dependency Injection
* View Models (DTOs) ve Data Annotations

## Projeyi Çalıştırma Talimatları
1. Projeyi bilgisayarınıza klonlayın.
2. Visual Studio üzerinden `SecondHandSales.sln` dosyasını açın.
3. Package Manager Console (Paket Yöneticisi Konsolu) üzerinden şu komutu çalıştırarak veritabanını oluşturun:
   `Update-Database`
4. Projeyi çalıştırın (F5).
5. Sistem otomatik olarak varsayılan bir Admin hesabı oluşturacaktır:
   * **E-posta:** admin@admin.com
   * **Şifre:** Admin123!