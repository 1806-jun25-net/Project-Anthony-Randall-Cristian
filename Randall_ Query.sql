CREATE TABLE ZRV_Pub.Locations (
  Id INT NOT NULL Identity,
  Street_Address NVARCHAR(255) NOT NULL,
  Postal_Code NVARCHAR(255) NOT NULL,
  City NVARCHAR(255) NOT NULL,
  States NVARCHAR(255) NOT NULL,
  PRIMARY KEY (Id));

  CREATE TABLE ZRV_Pub.Inventory (
  Id INT NOT NULL Identity Primary Key,
  IngredientName NVARCHAR(255) NOT NULL,
  IngredientType NVARCHAR(255) NOT NULL,
  Price Decimal(9,2) NOT NULL,
  );

 

  CREATE TABLE ZRV_Pub.Inventory_Has_Location(

  Id Int Identity Primary key,
  LocationID int not null,
  InventoryId int not null,
  Quantity int not null
  Constraint FK_Location_ID Foreign key (LocationID)
  References ZRV_Pub.Locations(Id),
  Constraint FK_Inventory_ID Foreign key (InventoryId)
  References ZRV_Pub.Inventory(Id));




  create table ZRV_Pub.Location_Order_Process (

        id int identity Primary key, 
        locationId int not null,  
        orderId int not null 
        Constraint FK_Location_Order Foreign key (locationId)
        References ZRV_Pub.Locations(id),
        constraint FK_Order_Location Foreign key (orderId)
        References ZRV_Pub.Orders(OrderId)

);

Create Table MenuPreBuilt(
Id Int Identity Primary Key,
NameOfMenu NVARCHAR(255) NOT NULL,
);

Create Table MenuPrebuilt_Has_Orders(
Id int Identity Primary Key,
MenuPreBuildID int not null,
OrdersId int not null,
constraint FK_Orders_ID Foreign key (OrdersId)
References ZRV_Pub.Orders(OrderId)
);


Create Table Custom_Has_Inventory(


);


Create Table MenuPreBuilt_Has_Inventory(
Id int identity Primary Key,
MenuPreBuildId int not null,
InventoryId int not null,
Quantity int not null,

Constraint FK_MenuPreBuild_ID Foreign key (MenuPreBuildId)
References dbo.MenuPreBuilt(Id),
constraint FK_Inventory_ID Foreign key (InventoryId)
References ZRV_Pub.Inventory(Id)
);


Create Table ZRV_Pub.MenuCustom(
Id Int Identity Primary Key,
NameOfCustomMenu NVARCHAR(255) NOT NULL,
IdOrders int Not Null,
constraint FK_Orders_ID Foreign key (IdOrders)
References ZRV_Pub.Orders(OrderId)

);

Create Table ZRV_Pub.MenuCustom_Has_Iventory_(
Id Int Identity Primary Key,
IdInventory int Not Null,
IdMenuCustom int Not Null,


Constraint FK_MenuCustom_ID Foreign key (IdMenuCustom)
References ZRV_Pub.MenuCustom(Id),
constraint FK_Inventory_ID_MenuCustom Foreign key (IdInventory)
References ZRV_Pub.Inventory(Id)
);


