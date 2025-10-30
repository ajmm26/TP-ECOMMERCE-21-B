CREATE DATABASE Ecommerce_DB;
GO

USE Ecommerce_DB;
GO

CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),         
    DNI VARCHAR(20) NOT NULL,                 
    Nombre VARCHAR(50) NOT NULL,              
    Apellido VARCHAR(50) NOT NULL,           
    Correo VARCHAR(100) NOT NULL,             
    Contraseña VARCHAR(100) NOT NULL,         
    Rol VARCHAR(20) NOT NULL,                 
    Telefono VARCHAR(20),                     
    Direccion VARCHAR(100),                   
    CodigoPostal VARCHAR(10),
    Estado BIT NOT NULL

);

CREATE TABLE Marca (
    Id INT PRIMARY KEY IDENTITY(1,1),    
    Nombre VARCHAR(50) NOT NULL           
);
CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY(1,1),         
    Codigo VARCHAR(20) NOT NULL,                 
    Nombre VARCHAR(50) NOT NULL,
    MarcaId INT NOT NULL,      
    Descripcion VARCHAR(50) NOT NULL,           
    PrecioCompra DECIMAL(10,2) NOT NULL,             
    PorcentajeGanancia DECIMAL(10,2) NOT NULL,         
    PrecioVenta DECIMAL(10,2) NOT NULL,                 
    StockActual INT NOT NULL,                     
    StockMinimo INT NOT NULL,
    Estado BIT NOT NULL,

    
    FOREIGN KEY (MarcaId) REFERENCES Marca(Id)  
             
);
CREATE TABLE Imagen (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT NOT NULL,
    Url VARCHAR(80) NOT NULL,
    FOREIGN KEY (IdProducto) REFERENCES Producto(Id)
);


INSERT INTO Marca (Nombre) VALUES
('Samsung'),
('Apple'),
('Sony'),
('LG'),
('Xiaomi');

INSERT INTO Producto (Codigo, Nombre, MarcaId, Descripcion, PrecioCompra, PorcentajeGanancia, PrecioVenta, StockActual, StockMinimo, Estado)
VALUES
('P001', 'Smartphone Galaxy A14', 1, 'Pantalla 6.6", 128GB', 100000, 20, 120000, 50, 10, 1),
('P002', 'iPhone 13', 2, '128GB, cámara dual', 250000, 15, 287500, 30, 5, 1),
('P003', 'Televisor 55" 4K', 3, 'Smart TV UHD', 180000, 25, 225000, 20, 3, 1);

INSERT INTO Imagen (IdProducto, Url) VALUES
(1, 'https://img.joomcdn.net/5614e867d137a0dae93a61d2076d9bd638957a95_original.jpeg'),
(1, 'https://img.joomcdn.net/a64ca5011cb73a505c8cc83d04d535acab007214_original.jpeg'),
(2, 'https://img.joomcdn.net/6ae4b8ac5defcce5ca751e77bdf08f6d6676dbeb_original.jpeg'),
(3, 'https://img.joomcdn.net/b9fbc3606a0c740e74207886bc271f914c39f337_original.jpeg');

INSERT INTO Usuario (DNI, Nombre, Apellido, Correo, Contraseña, Rol, Telefono, Direccion, CodigoPostal, Estado)
VALUES
('12345678', 'Juan', 'Pérez', 'juan@example.com', '1234', 'Cliente', '1122334455', 'Calle Falsa 123', 'B1609', 1),
('87654321', 'Admin', 'Root', 'admin@example.com', 'admin123', 'Administrador', '1199887766', 'Av. Principal 456', 'B1609', 1);




