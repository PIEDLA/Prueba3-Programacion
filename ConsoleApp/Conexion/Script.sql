CREATE DATABASE db_cinema;
GO
USE db_cinema;
GO

CREATE TABLE [Cinemas] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(50) NOT NULL,
);

CREATE TABLE [Salas] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(50) NOT NULL,
	[Cinema] INT REFERENCES [Cinemas]([Id]) NOT NULL,
	[Fecha] SMALLDATETIME DEFAULT GETDATE(),
	[Activo] BIT NOT NULL,
	[Area] DECIMAL(10, 2) NOT NULL,
);
GO

INSERT INTO [Cinemas] VALUES ('Procinal');
INSERT INTO [Cinemas] VALUES ('Cine colombia');
INSERT INTO [Salas] VALUES ('S001', 1, GETDATE(), 1, 0.0);
INSERT INTO [Salas] VALUES ('S002', 1, GETDATE(), 1, 100.0);
INSERT INTO [Salas] VALUES ('S001', 2, GETDATE(), 1, 500.0);
INSERT INTO [Salas] ([Nombre], [Cinema], [Activo], [Area]) 
VALUES ('S003', 2, 0, 500.0);
GO

SELECT * FROM [Cinemas];
SELECT * FROM [Salas];

SELECT s.*, c.[Nombre] 'NombreCinema'
FROM [Salas] s INNER JOIN [Cinemas] c
	ON s.[Cinema] = c.[Id];