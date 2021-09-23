use HeadphonesDB

go

drop table if exists Headphones
drop table if exists Designs
drop table if exists Companies
drop table if exists Users
drop procedure if exists CountUsers

go

create table Users
(
	Id int primary key identity(1,1),
	[Login] nvarchar(16) unique not null,
	[Password] nvarchar(16) not null,
	IsAdmin bit not null
)

create table Designs
(
	Id int primary key identity(1,1),
	[Name] nvarchar(32) unique not null
)

create table Companies
(
	Id int primary key identity(1,1),
	[Name] nvarchar(32) unique not null
)

create table Headphones
(
	Id int primary key identity(1,1),
	[Name] nvarchar(128),
	MinFrequency float,
	MaxFrequency float,
	Picture nvarchar(256),
	CompanyId int references Companies(Id) on delete cascade,
	DesignId int references Designs(Id) on delete cascade
)

go

create procedure CountUsers as
select COUNT(*) from Users 

go 

create trigger HeadphonesInsert
on Headphones
after insert
as
update Headphones
set Picture = 'None'
where Picture LIKE '' or Picture is NULL

go

insert Users values
('admin', 'admin', 1),
('user', 'user', 0)

insert Companies values
('Sony'),
('JBL')

insert Designs values
('Tiny'),
('Huge')

insert Headphones values
('Sony WH-1000XM4', 4, 40000, '', 1, 2),
('JBL Tune 510BT', 20, 20000, '', 2, 2)