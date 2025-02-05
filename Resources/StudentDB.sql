-- Creaci�n de la base de datos
CREATE DATABASE StudentDB;
GO

USE StudentDB;
GO

-- Tabla de Profesores
CREATE TABLE Profesores (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla de Materias
CREATE TABLE Materias (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Creditos INT NOT NULL DEFAULT 3,
    ProfesorId INT NOT NULL,
    FOREIGN KEY (ProfesorId) REFERENCES Profesores(Id)
);

-- Tabla de Estudiantes
CREATE TABLE Estudiantes (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE
);

-- Tabla intermedia para la relaci�n muchos a muchos entre Estudiantes y Materias
CREATE TABLE EstudianteMateria (
    EstudianteId INT,
    MateriaId INT,
    PRIMARY KEY (EstudianteId, MateriaId),
    FOREIGN KEY (EstudianteId) REFERENCES Estudiantes(Id),
    FOREIGN KEY (MateriaId) REFERENCES Materias(Id)
);

-- Inserciones de Profesores
INSERT INTO Profesores (Id, Nombre) VALUES (1, 'Profesor A');
INSERT INTO Profesores (Id, Nombre) VALUES (2, 'Profesor B');
INSERT INTO Profesores (Id, Nombre) VALUES (3, 'Profesor C');
INSERT INTO Profesores (Id, Nombre) VALUES (4, 'Profesor D');
INSERT INTO Profesores (Id, Nombre) VALUES (5, 'Profesor E');

-- Inserciones de Materias
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (1, 'Matem�ticas', 1);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (2, 'F�sica', 1);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (3, 'Qu�mica', 2);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (4, 'Biolog�a', 2);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (5, 'Historia', 3);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (6, 'Geograf�a', 3);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (7, 'Ingl�s', 4);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (8, 'Franc�s', 4);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (9, 'Arte', 5);
INSERT INTO Materias (Id, Nombre, ProfesorId) VALUES (10, 'M�sica', 5);

-- Inserciones de Estudiantes
INSERT INTO Estudiantes (Id, Nombre, Email) VALUES (1, 'Juan P�rez', 'juan.perez@example.com');
INSERT INTO Estudiantes (Id, Nombre, Email) VALUES (2, 'Mar�a G�mez', 'maria.gomez@example.com');
INSERT INTO Estudiantes (Id, Nombre, Email) VALUES (3, 'Carlos L�pez', 'carlos.lopez@example.com');

-- Relaci�n Estudiantes con Materias (ejemplo)
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (1, 1);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (1, 3);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (1, 5);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (2, 2);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (2, 4);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (2, 6);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (3, 7);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (3, 8);
INSERT INTO EstudianteMateria (EstudianteId, MateriaId) VALUES (3, 9);
