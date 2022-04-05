create database PRN_Project
go

--acount table
create table Account(
	aid int identity primary key not null,
	email nvarchar(100) not null,
	password nvarchar(100) not null,
	phone_number nvarchar(10),
	role int not null --0 admin, 1 customer
)
go

--product category
create table ProductCategory(
	cid int identity primary key not null,
	cname nvarchar(100) not null
)
go

--product table
create table Product(
	pid int identity primary key not null,
	pname nvarchar(100) not null,
	price float not null,
	pimage nvarchar(200) not null,
	cid int not null

	foreign key (cid) references ProductCategory(cid) 
)
go

--order table
create table Orders(
	oid int identity primary key not null,
	orderDate Date,
	status int not null,--0 đã đặt , 1 đã gửi, 2 đã giao
	aid int not null,
	totalPrice float not null

	foreign key (aid) references Account(aid)
)
go

--order detail
create table OrdersDetail(
	odid int identity primary key not null,
	pid int not null,
	oid int not null,
	quantity int not null,
	price float not null

	foreign key (oid) references Orders(oid),
	foreign key (pid) references Product(pid) 
)
go

