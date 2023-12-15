create database Assignment7
use assignment7

create table Books
(BookId int primary key,
Title nvarchar(50),
Author nvarchar(50),
Genre nvarchar(50),
Quantity int)

insert into Books values(1,'A brief hisory of my life','Arjun','Life lesson',5)
insert into Books values(2,'how to stop worrying','Ram','History',3)
insert into Books values(3,'Vitamins','Sahiti','Science',2)
select *from Books