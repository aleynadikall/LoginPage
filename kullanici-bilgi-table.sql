-- Veritabanımızı oluşturalim.
Create Database Ornek

-- Tablomuzu ve gerekli bilgileri oluşturalim.
Create Table KullaniciBilgi(
id int primary key identity (1,1) not null,
kullanici_adi nvarchar(50),
sifre nvarchar(50)
)

-- Değerleri girelim.
insert into KullaniciBilgi values ('eagle12', '12345')

select * from KullaniciBilgi