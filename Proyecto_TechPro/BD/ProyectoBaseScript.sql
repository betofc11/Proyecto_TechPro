Create database ProyectoProgra; 

create table Productos(
idProducto int primary  key, 
nombreProducto varchar(50),
precio int, 
descripcion varchar(100),
idCategoria int unique, 
imagen varchar(150) 
)
create table Invetario(
idProducto int primary  key, 
cantidad int,
FOREIGN KEY (idProducto) REFERENCES Productos(idProducto)
)

create table Categoria(
idCategoria int primary  key, 
nombreCategoria varchar(50),
FOREIGN KEY (idCategoria) REFERENCES Productos(idCategoria)
)
create table Direccion(
idDireccion int primary key,
provincia varchar(25),
canton varchar (25),
codigoPostal varchar (25),
dirExacta varchar (100),
indicaciones varchar (50)
)
create table Ordenes(
idProducto int,
cantidad int,
idDireccion int ,
idUsuario int,
idCategoria int,
FOREIGN KEY (idProducto) REFERENCES Productos(idProducto),
FOREIGN KEY (idCategoria) REFERENCES Productos(idCategoria),
Foreign Key (idDireccion) references Direccion(idDireccion)
)
Create table administrador(
idAdmin int primary key,
email varchar(35),
nombre varchar (20),
primerApellido varchar (20),
segundoApellido varchar(20),
cedula int)

create table adminPassword(
idAdmin int,
pass varchar(30)
Foreign Key (idAdmin) references administrador(idAdmin)
)
create table usuario(
idUsuario int primary key,
telefono int ,
email  varchar(30),
idDireccion int ,
nombre varchar (25),
primerApellido varchar (25),
segundoApellido varchar (25),
Foreign Key (idDireccion) references Direccion(idDireccion)
)
Create table Password(
idUsuario int,
Pass varchar(30)
Foreign Key (idUsuario) references usuario(idUsuario)
)
