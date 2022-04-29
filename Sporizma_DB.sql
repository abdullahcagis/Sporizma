CREATE DATABASE Sporizma
GO
USE Sporizma
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Moderat�r')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTurID int,
	Isim nvarchar(50) NOT NULL,
	Soyisim nvarchar(50),
	Mail nvarchar(120),
	Sifre nvarchar(20),
	Durum bit,
	CONSTRAINT pk_yonetici PRIMARY KEY(ID),
	CONSTRAINT pk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID)
	REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyisim, Mail, Sifre, Durum) VALUES(1, 'Alp', 'Sar�k��la', 'alpsarikisla@hotmail.com', '12345',1)
GO
CREATE TABLE UyeTurleri
(
    ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	CONSTRAINT pk_uyeturleri PRIMARY KEY(ID)
)
GO
INSERT INTO UyeTurleri(Isim) VALUES('Antren�r')
INSERT INTO UyeTurleri(Isim) VALUES('Oyuncu')

CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	UyeTurleriID int,
	Isim nvarchar(50) NOT NULL,
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(20),
	Mail nvarchar(120),
	Sifre nvarchar(20),
	UyelikTarih datetime,
	Durum bit,
	CONSTRAINT pk_Uyeler PRIMARY KEY(ID),
	CONSTRAINT fk_UyeTurleri FOREIGN KEY(UyeTurleriID)
	REFERENCES UyeTurleri(ID)
)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	Durum bit,
	CONSTRAINT pk_kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Antrenmanlar
(
	ID int IDENTITY(1,1),
	KategoriID int,
	YazarID int,
	Baslik nvarchar(120) NOT NULL,
	Ozet nvarchar(500),
	Icerik nvarchar(MAX),
	GoruntulemeSayi int,
	KapakResim nvarchar(50),
	EklemeTarih datetime,
	Durum bit,
	CONSTRAINT pk_makale PRIMARY KEY(ID),
	CONSTRAINT fk_antrenmanKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_antrenmanYonetici FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID),
	CONSTRAINT fk_Antrenmankullanici FOREIGN KEY(YazarID) REFERENCES Uyeler(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	MakaleID int,
	UyeID int,
	Icerik nvarchar(500),
	EklemeTarihi date,
	Durum bit,
	CONSTRAINT pk_yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(MakaleID) REFERENCES Antrenmanlar(ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID)
)