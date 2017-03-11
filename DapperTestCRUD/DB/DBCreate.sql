Create database Weterynarz
Go
Use Weterynarz
GO
Create table Gatunek
(
ID_Gatunek int not null primary key identity(1,1),
Nazwa varchar(50) not null unique
)
Go
Create table Rasa
(
ID_Rasa int not null primary key identity(1,1),
ID_Gatunek int not null foreign key references Gatunek(ID_Gatunek),
Nazwa varchar(50) not null unique
)
Go
Create table Hodowla
(
ID_Hodowla  int not null primary key identity(1,1),
Hodowca varchar(50),
[Nazwa Hodowli] varchar(50) unique,
Miejscowosc varchar(50) not null,
Ulica varchar(50),
Telefon varchar(9) not null unique
constraint hodowla_telefon_consraint check (Telefon Like REPLICATE('[0-9]',9))
)
Go
Create table Usluga
(
ID_Usluga int not null primary key identity(1,1),
Nazwa varchar(100) not null unique
)
Go
Create table Wlasciciel
(
ID_Wlasciciel int not null primary key identity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(50) not null,
Miejscowosc  varchar(50) not null,
Pesel varchar(11) not null unique,
Telefon varchar(9) not null unique,
constraint Wlasciciel_telefon_consraint check (Telefon Like REPLICATE('[0-9]',9)),
constraint Wlasciciel_pesel_consraint check (Pesel Like REPLICATE('[0-9]',11))
)
Go
Create table Lekarz
(
ID_Lekarz int not null primary key identity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(50) not null,
Tytul varchar (20) not null default 'lek. wet. ',
Stanowisko varchar (20) not null default 'pomoc medyczna',
Miejscowosc  varchar(50) not null,
Ulica varchar(50),
Pesel varchar(11)not null,
Telefon varchar(9) not null unique,
[Data Zatrudnienia] date not null,
constraint Lekarz_telefon_consraint check (Telefon Like REPLICATE('[0-9]',9)),
constraint Lekarz_pesel_consraint check (Pesel Like REPLICATE('[0-9]',11))
)
Go
Create table Zwierze
(
ID_Zwierze int not null primary key identity(1,1),
Imie varchar(50) not null,
Plec varchar(10) not null,
ID_Rasa int not null foreign key references Rasa(ID_Rasa),
ID_Hodowla int foreign key references Hodowla(ID_Hodowla),
[Data Urodzenia] date not null,
Rodowod varchar(50),
[Numer Chipa] varchar(20),
Mama int foreign key references Zwierze(ID_Zwierze),
Tata int foreign key references Zwierze(ID_Zwierze),
Waga DECIMAL(18, 5) not null
constraint Waga_Cannot_Be_Lower_Than check (Waga > 0.001) 
)
Go
Create table Wlasnosc
(
ID_Wlasnosc int not null primary key identity(1,1),
ID_Wlasciciel int not null foreign key references Wlasciciel(ID_Wlasciciel),
ID_Zwierze int not null foreign key references Zwierze(ID_Zwierze),
[Data Od] date not null default GetDate(),
[Data Do] date,
constraint chk_Data_Do check ([Data Do] >= [Data OD]) 
)
Go
Create table Wizyta
(
ID_Wizyta int not null primary key identity(1,1),
ID_Zwierze int not null foreign key references Zwierze(ID_Zwierze),
ID_Lekarz int not null foreign key references Lekarz(ID_Lekarz),

Data datetime not null default GetDate()
)
Go
Create table Dostawca
(
ID_Dostawca int not null primary key identity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(50) not null,
Miejscowosc varchar(50) not null,
Ulica varchar(50) not null,
Telefon int not null unique
)
Go
Create table Produkt 
(
ID_Produkt int not null primary key identity(1,1),
Nazwa varchar(100) not null,
Jednostka_Produktu varchar(50),
)
Go
Create table Magazyn
(
ID_Magazyn  int not null primary key identity(1,1),
Nazwa varchar(50) not null unique
)
Go
Create table Dostawa
(
ID_Dostawa int not null primary key identity(1,1),
ID_Produkt int not null foreign key references Produkt(ID_Produkt),
ID_Magazyn int not null foreign key references Magazyn(ID_Magazyn),
Ilosc decimal not null,
Cena decimal not null,
ID_Dostawca int not null foreign key references Dostawca(ID_Dostawca),
[Data Dostawy] smalldatetime not null default GetDate(),
constraint Data_Dostawy_nie_wczesniejsza_niz_teraz check ([Data Dostawy] <=GetDate()),
constraint ilosc_mniejsze_od_zera_Dostawa check (Ilosc >= 0.0)
)
Go
Create table [Wizyta Szczegol]
(
ID_Wizyta_Szczegol int not null primary key identity(1,1),
ID_Wizyta int not null foreign key references Wizyta(ID_Wizyta),
ID_Dostawa int not null foreign key references Dostawa(ID_Dostawa),
Ilosc decimal not null,
ID_Usluga int not null foreign key references Usluga(ID_Usluga),
Uwaga varchar(200) default 'Brak uwag',
constraint ilosc_mniejsze_od_zera_Szczegol check (Ilosc >= 0.0)
)
Go