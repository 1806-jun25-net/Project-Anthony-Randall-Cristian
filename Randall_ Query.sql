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


);
