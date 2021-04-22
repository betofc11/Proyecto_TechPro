Create database ProyectoProgra; 

use ProyectoProgra;

create table Categoria(
idCategoria int primary key, 
nombreCategoria varchar(50)
);

create table Productos(
idProducto int primary key, 
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

create table Direccion(
idDireccion int primary key,
provincia varchar(25),
canton varchar (25),
codigoPostal varchar (25),
dirExacta varchar (100),
indicaciones varchar (50)
);


create table usuario(
idUsuario int primary key,
telefono int ,
email  varchar(30),
Pass varchar(30),
idDireccion int ,
nombre varchar (25),
primerApellido varchar (25),
segundoApellido varchar (25),
Foreign Key (idDireccion) references Direccion(idDireccion)
);

create table Ordenes(
idProducto int,
cantidad int,
idDireccion int ,
idUsuario int,
idCategoria int,
FOREIGN KEY (idProducto) REFERENCES Productos(idProducto),
FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria),
FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
Foreign Key (idDireccion) references Direccion(idDireccion)
);
Create table administrador(
idAdmin int primary key,
email varchar(35),
adminPass varchar(30),
nombre varchar (20),
primerApellido varchar (20),
segundoApellido varchar(20),
cedula int);

	USE [ProyectoProgra]
	GO

	INSERT INTO [dbo].[Categoria]
			   ([idCategoria]
			   ,[nombreCategoria])
		 VALUES
			   (1, 'Componentes')
	GO
	INSERT INTO [dbo].[Categoria]
			   ([idCategoria]
			   ,[nombreCategoria])
		 VALUES
			   (2, 'Perifericos')
	GO
	INSERT INTO [dbo].[Categoria]
			   ([idCategoria]
			   ,[nombreCategoria])
		 VALUES
			   (3, 'Laptops')
	GO
	INSERT INTO [dbo].[Categoria]
			   ([idCategoria]
			   ,[nombreCategoria])
		 VALUES
			   (4, 'Smartphones')
	GO
    	INSERT INTO [dbo].[Categoria]
			   ([idCategoria]
			   ,[nombreCategoria])
		 VALUES
			   (5, 'Televisores')
	GO

-----------------------------------------------------------------


USE [ProyectoProgra]
GO

INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (1
           ,'Laptop ASUS G512LIHN054T'
           ,990000
           ,'Laptop gaming de la marca ASUS'
           ,3
           ,'asus_G512LIHN054T.png')
GO
INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (2
           ,'Mouse Razer Basilisk'
           ,35000
           ,'Mose inalambrico de la marca Razer'
           ,2
           ,'razer_basilisk.png')
GO
INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (3
           ,'Teclado mecanico Razer Blackwidow'
           ,65000
           ,'Teclado mechanico 60% de la marca Razer'
           ,2
           ,'razer_blackwidow.png')
GO
INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (4
           ,'Headset gaming PS4-PC Astro A20'
           ,95000
           ,'Headset Astro a20 compatible con la consola PS$ y PC'
           ,2
           ,'astro_a20.png')
GO
INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (5
           ,'Teclado Logitech G513'
           ,44900
           ,'Teclado mecanico de la marca Logitech'
           ,2
           ,'logitech_g502.png')
GO
INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (6
           ,'Monitor Asus Rog Strix'
           ,349900
           ,'Monitor de la marca Asus con 240Hz'
           ,2
           ,'asus_rog_strix_XG32VQR.png')
GO
INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (7
           ,'Silla Cougar Armor One'
           ,349900
           ,'Silla gaming de la marca Cougar'
           ,2
           ,'cougar_armor_one.png')
GO

INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (8
           ,'Televisor Samsung'
           ,1900000
           ,' Televisor de 73 pulgadas'
           ,2
           ,'QLEDSamsung.jpg')
GO



INSERT INTO [dbo].[Productos]
           ([idProducto]
           ,[nombreProducto]
           ,[precio]
           ,[descripcion]
           ,[idCategoria]
           ,[imagen])
     VALUES
           (9
           ,'IPHONE 12 PRO MAX'
           ,850000
           ,' IPHONE 128 GB 6 RAM'
           ,4
           ,'iphone12ProMax.png')
GO