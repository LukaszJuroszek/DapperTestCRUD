Create database Weterynarz
Go
Use Weterynarz
GO
Create table Gatunek
(
IdGatunek int not null primary key Identity(1,1),
Nazwa varchar(50) not null unique
)
Go
Create table Rasa
(
IdRasa int not null primary key identity(1,1),
IdGatunek int not null foreign key references Gatunek(IdGatunek),
Nazwa varchar(50) not null unique
)
Go
Create table Hodowla
(
IdHodowla  int not null primary key identity(1,1),
Hodowca varchar(50),
NazwaHodowli varchar(50) unique,
Miejscowosc varchar(50) not null,
Ulica varchar(50),
Telefon varchar(9) not null unique
constraint hodowla_telefon_consraint check (Telefon Like REPLICATE('[0-9]',9))
)
Go
Create table Usluga
(
IdUsluga int not null primary key identity(1,1),
Nazwa varchar(100) not null unique
)
Go
Create table Wlasciciel
(
IdWlasciciel int not null primary key identity(1,1),
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
IdLekarz int not null primary key identity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(50) not null,
Tytul varchar (20) not null default 'lek. wet. ',
Stanowisko varchar (20) not null default 'pomoc medyczna',
Miejscowosc  varchar(50) not null,
Ulica varchar(50),
Pesel varchar(11)not null,
Telefon varchar(9) not null unique,
DataZatrudnienia date not null,
constraint Lekarz_telefon_consraint check (Telefon Like REPLICATE('[0-9]',9)),
constraint Lekarz_pesel_consraint check (Pesel Like REPLICATE('[0-9]',11))
)
Go
Create table Zwierze
(
IdZwierze int not null primary key identity(1,1),
Imie varchar(50) not null,
Plec varchar(10) not null,
IdRasa int not null foreign key references Rasa(IdRasa),
IdHodowla int foreign key references Hodowla(IdHodowla),
DataUrodzenia date not null,
Rodowod varchar(50),
NumerChipa varchar(20),
Mama int foreign key references Zwierze(IdZwierze),
Tata int foreign key references Zwierze(IdZwierze),
Waga DECIMAL(18, 5) not null
constraint Waga_Cannot_Be_Lower_Than check (Waga > 0.001) 
)
Go
Create table Wlasnosc
(
IdWlasnosc int not null primary key identity(1,1),
IdWlasciciel int not null foreign key references Wlasciciel(IdWlasciciel),
IdZwierze int not null foreign key references Zwierze(IdZwierze),
DataOd date not null default GetDate(),
DataDo date,
constraint chk_Data_Do check (DataDo >= DataOd) 
)
Go
Create table Wizyta
(
IdWizyta int not null primary key identity(1,1),
IdZwierze int not null foreign key references Zwierze(IdZwierze),
IdLekarz int not null foreign key references Lekarz(IdLekarz),
Data datetime not null default GetDate()
)
Go
Create table Dostawca
(
IdDostawca int not null primary key identity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(50) not null,
Miejscowosc varchar(50) not null,
Ulica varchar(50) not null,
Telefon int not null unique
)
Go
Create table Produkt 
(
IdProdukt int not null primary key identity(1,1),
Nazwa varchar(100) not null,
JednostkaProduktu varchar(50),
)
Go
Create table Magazyn
(
IdMagazyn  int not null primary key identity(1,1),
Nazwa varchar(50) not null unique
)
Go
Create table Dostawa
(
IdDostawa int not null primary key identity(1,1),
IdProdukt int not null foreign key references Produkt(IdProdukt),
IdMagazyn int not null foreign key references Magazyn(IdMagazyn),
Ilosc decimal not null,
Cena decimal not null,
IdDostawca int not null foreign key references Dostawca(IdDostawca),
DataDostawy smalldatetime not null default GetDate(),
constraint Data_Dostawy_nie_wczesniejsza_niz_teraz check (DataDostawy <=GetDate()),
constraint ilosc_mniejsze_od_zera_Dostawa check (Ilosc >= 0.0)
)
Go
Create table WizytaSzczegol
(
IdWizytaSzczegol int not null primary key identity(1,1),
IdWizyta int not null foreign key references Wizyta(IdWizyta),
IdDostawa int not null foreign key references Dostawa(IdDostawa),
Ilosc decimal not null,
IdUsluga int not null foreign key references Usluga(IdUsluga),
Uwaga varchar(200) default 'Brak uwag',
constraint ilosc_mniejsze_od_zera_Szczegol check (Ilosc >= 0.0)
)
Go