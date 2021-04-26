Create database ProyectoProgra; 

use ProyectoProgra;

create table Categoria(
idCategoria int IDENTITY(1,1) primary key, 
nombreCategoria varchar(50)
);

create table Productos(
idProducto int IDENTITY(1,1) primary key, 
nombreProducto varchar(50),
precio int, 
descripcion varchar(100),
idCategoria int, 
imagen varchar(150),
FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria) 
);

create table Invetario(
idProducto int primary key, 
cantidad int,
FOREIGN KEY (idProducto) REFERENCES Productos(idProducto)
);



create table usuario(
idUsuario int IDENTITY(1,1) primary key,
telefono varchar(8) ,
email  varchar(30),
Pass varchar(30),
nombre varchar (25),
primerApellido varchar (25),
segundoApellido varchar (25)
);

create table Ordenes(
idOrden int IDENTITY(1, 1) PRIMARY KEY,
idProducto int,
cantidad int,
direccion varchar(150) ,
idUsuario int,
idCategoria int,
estado varchar(9),
FOREIGN KEY (idProducto) REFERENCES Productos(idProducto),
FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria),
FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario)
);
Create table administrador(
idAdmin int IDENTITY(1,1) primary key,
email varchar(35),
adminPass varchar(30),
nombre varchar (20),
primerApellido varchar (20),
segundoApellido varchar(20),
cedula varchar(9));

-------------------------------------------------------------------------------------------------------------

	USE [ProyectoProgra]
	GO

	INSERT INTO [dbo].[Categoria]
			   ([nombreCategoria])
		 VALUES
			   ('Componentes')
	GO
	INSERT INTO [dbo].[Categoria]
			   ([nombreCategoria])
		 VALUES
			   ('Perifericos')
	GO
	INSERT INTO [dbo].[Categoria]
			   ([nombreCategoria])
		 VALUES
			   ('Laptops')
	GO
	INSERT INTO [dbo].[Categoria]
			   ([nombreCategoria])
		 VALUES
			   ('Smartphones')
	GO
    	INSERT INTO [dbo].[Categoria]
			   ([nombreCategoria])
		 VALUES
			   ('Televisores')
	GO

-----------------------------------------------------------------


USE [ProyectoProgra]
GO

INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Laptop ASUS G512LIHN054T'
           ,990000
           ,'Laptop gaming de la marca ASUS'
           ,3
           ,'asus_G512LIHN054T.png')
GO
INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Mouse Razer Basilisk'
           ,35000
           ,'Mose inalambrico de la marca Razer'
           ,2
           ,'razer_basilisk.png')
GO
INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Teclado mecanico Razer Blackwidow'
           ,65000
           ,'Teclado mechanico 60% de la marca Razer'
           ,2
           ,'razer_blackwidow.png')
GO
INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Headset gaming PS4-PC Astro A20'
           ,95000
           ,'Headset Astro a20 compatible con la consola PS$ y PC'
           ,2
           ,'astro_a20.png')
GO
INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Teclado Logitech G513'
           ,44900
           ,'Teclado mecanico de la marca Logitech'
           ,2
           ,'logitech_g502.png')
GO
INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Monitor Asus Rog Strix'
           ,349900
           ,'Monitor de la marca Asus con 240Hz'
           ,2
           ,'asus_rog_strix_XG32VQR.png')
GO
INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Silla Cougar Armor One'
           ,349900
           ,'Silla gaming de la marca Cougar'
           ,2
           ,'cougar_armor_one.png')
GO

INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('Televisor Samsung'
           ,1900000
           ,' Televisor de 73 pulgadas'
           ,2
           ,'QLEDSamsung.jpg')
GO



INSERT INTO [dbo].[Productos]
           ([nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           ('IPHONE 12 PRO MAX'
           ,850000
           ,' IPHONE 128 GB 6 RAM'
           ,4
           ,'iphone12ProMax.png')
GO

-------------------------------------------------------------------------------------

INSERT INTO [dbo].[administrador]
           ([email]
           ,[adminPass]
           ,[nombre]
           ,[primerApellido]
           ,[segundoApellido]
           ,[cedula])
     VALUES
           ('admin@admin.com'
           ,'adminpass'
           ,'Administrador1'
           ,'ApellidoAdmin1'
           ,'SApellidoAdmin1'
           ,'777777777')
GO

----------------------------------------------------------------------------------------

INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (1, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (2, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (3, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (4, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (5, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (6, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (7, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (8, 4)
GO
INSERT INTO [dbo].[Invetario]
           ([idProducto]
           ,[cantidad])
     VALUES
           (9, 4)
GO

------------------------------------------------------------------------