create table Utilizatori
(
	IDUser int identity(1,1) primary key,
	Nume nvarchar(20),
	Prenume nvarchar(20),
	Varsta int,
	Email nvarchar(30),
	Telefon nvarchar(10),
	Sector int,
	Strada nvarchar(20),
	Numar int,
	TipUtilizator nvarchar(10),
	NumarComenzi int,
	SumaBani int,
	Cont nvarchar(20),
	Parola nvarchar(20)
)
create table FelMancare
(
	IDFelMancare int identity(1,1) primary key,
	NumeMancare nvarchar(20),
	CategorieMancare nvarchar(20),
	Stoc int,
	Ingrediente nvarchar(70),
	Calorii int,
	Pret int,
)

insert into FelMancare(NumeMancare,CategorieMancare,Stoc,Ingrediente,Calorii,Pret)
values('Pizza Salami','Pizza',10,'blat pizza,mozzarela,sos de rosii,salam',1050,32),
('Pizza Diavola','Pizza',10,'blat pizza,mozzarela,sos de rosii,salam chorizo,carnati chorizo',1200,35)
insert into FelMancare(NumeMancare,CategorieMancare,Stoc,Ingrediente,Calorii,Pret)
values('Burger Black Angus','Burger',25,'carne vita,maioneza,castraveti murati,rosii,salata',856,40)
select* from FelMancare
select count(*) from FelMancare group by CategorieMancare having CategorieMancare='Pizza'