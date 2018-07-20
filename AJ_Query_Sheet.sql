--create schema--
select * from ZRV_Pub.Orders

create schema ZRV_Pub;

GO;
------------------------------------------------------

--create tables
create table ZRV_Pub.Orders
(
	OrderId int primary key identity,
	OrderTime DateTime2 not null,
	LocationId int not null
)
GO;

create table ZRV_Pub.Users
(
	UserId int primary key identity,
	Username nvarchar(50) unique not null,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	DateOfBirth DateTime2 not null,
	UserAddress nvarchar(150) not null,
	PhoneNumber nvarchar(20) unique not null,
	Email nvarchar(50) unique not null
);
GO;

create table ZRV_Pub.UserLoginInfo
(
	Username nvarchar(50) primary key,
	UserPassword nvarchar(50) not null
);
--------------------------------------------------------------

--table alterations
alter table ZRV_Pub.Orders
add UserId int not null;
GO;

alter table ZRV_Pub.Users
add UserPic nvarchar(100) null;
---------------------------------------------------------------

--Foreign Key assignments
ALTER TABLE ZRV_Pub.Orders
ADD CONSTRAINT FK_UserId FOREIGN KEY (UserId) REFERENCES ZRV_Pub.Users(UserId);