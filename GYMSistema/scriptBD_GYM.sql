USE [GYMBD]
GO
/****** Object:  Table [dbo].[Clases]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clases](
	[IdClase] [int] IDENTITY(1,1) NOT NULL,
	[IdSocio] [int] NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[DiaSemana] [nvarchar](10) NOT NULL,
	[Hora] [time](7) NOT NULL,
	[CupoMaximo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membresias]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresias](
	[IdMembresia] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[DuracionMeses] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Activa] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdSocio] [int] NULL,
	[IdMembresia] [int] NULL,
	[FechaPago] [date] NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socios]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socios](
	[IdSocio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [nvarchar](255) NULL,
	[Telefono] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Membresias] ADD  DEFAULT ((1)) FOR [Activa]
GO
ALTER TABLE [dbo].[Clases]  WITH CHECK ADD FOREIGN KEY([IdSocio])
REFERENCES [dbo].[Socios] ([IdSocio])
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD FOREIGN KEY([IdMembresia])
REFERENCES [dbo].[Membresias] ([IdMembresia])
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD FOREIGN KEY([IdSocio])
REFERENCES [dbo].[Socios] ([IdSocio])
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarClase]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarClase]
    @IdClase INT,
    @IdSocio INT,
    @Nombre NVARCHAR(100),
    @DiaSemana NVARCHAR(10),
    @Hora TIME,
    @CupoMaximo INT
AS
BEGIN
    UPDATE Clases
    SET IdSocio = @IdSocio, Nombre = @Nombre, DiaSemana = @DiaSemana, Hora = @Hora, CupoMaximo = @CupoMaximo
    WHERE IdClase = @IdClase
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarMembresia]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarMembresia]
    @IdMembresia INT,
    @Tipo NVARCHAR(50),
    @DuracionMeses INT,
    @Precio DECIMAL(10, 2)
AS
BEGIN
    UPDATE Membresias
    SET Tipo = @Tipo, DuracionMeses = @DuracionMeses, Precio = @Precio
    WHERE IdMembresia = @IdMembresia
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarPago]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarPago]
    @IdPago INT,
    @IdSocio INT,
    @IdMembresia INT,
    @FechaPago DATE,
    @Monto DECIMAL(10, 2)
AS
BEGIN
    UPDATE Pagos
    SET IdSocio = @IdSocio, IdMembresia = @IdMembresia, FechaPago = @FechaPago, Monto = @Monto
    WHERE IdPago = @IdPago
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarSocio]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarSocio]
    @IdSocio INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Direccion NVARCHAR(255),
    @Telefono VARCHAR(15)
AS
BEGIN
    UPDATE Socios
    SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento,
        Direccion = @Direccion, Telefono = @Telefono
    WHERE IdSocio = @IdSocio
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarClase]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarClase]
    @IdClase INT
AS
BEGIN
    DELETE FROM Clases WHERE IdClase = @IdClase
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMembresia]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarMembresia]
    @IdMembresia INT
AS
BEGIN
    DELETE FROM Membresias WHERE IdMembresia = @IdMembresia
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPago]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarPago]
    @IdPago INT
AS
BEGIN
    DELETE FROM Pagos WHERE IdPago = @IdPago
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarSocio]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarSocio]
    @IdSocio INT
AS
BEGIN
    DELETE FROM Socios WHERE IdSocio = @IdSocio
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarClase]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimientos Almacenados CRUD para Clases

CREATE PROCEDURE [dbo].[sp_InsertarClase]
    @IdSocio INT,
    @Nombre NVARCHAR(100),
    @DiaSemana NVARCHAR(10),
    @Hora TIME,
    @CupoMaximo INT
AS
BEGIN
    INSERT INTO Clases (IdSocio, Nombre, DiaSemana, Hora, CupoMaximo)
    VALUES (@IdSocio, @Nombre, @DiaSemana, @Hora, @CupoMaximo)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarMembresia]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimientos Almacenados CRUD para Membresías

CREATE PROCEDURE [dbo].[sp_InsertarMembresia]
    @Tipo NVARCHAR(50),
    @DuracionMeses INT,
    @Precio DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Membresias (Tipo, DuracionMeses, Precio)
    VALUES (@Tipo, @DuracionMeses, @Precio)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPago]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimientos Almacenados CRUD para Pagos

CREATE PROCEDURE [dbo].[sp_InsertarPago]
    @IdSocio INT,
    @IdMembresia INT,
    @FechaPago DATE,
    @Monto DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Pagos (IdSocio, IdMembresia, FechaPago, Monto)
    VALUES (@IdSocio, @IdMembresia, @FechaPago, @Monto)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarSocio]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimientos Almacenados CRUD para Socios

CREATE PROCEDURE [dbo].[sp_InsertarSocio]
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Direccion NVARCHAR(255),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO Socios (Nombre, Apellido, FechaNacimiento, Direccion, Telefono)
    VALUES (@Nombre, @Apellido, @FechaNacimiento, @Direccion, @Telefono)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarClases]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarClases]
AS
BEGIN
    SELECT * FROM Clases
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarMembresias]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarMembresias]
AS
BEGIN
    SELECT * FROM Membresias
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarPagos]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarPagos]
AS
BEGIN
    SELECT * FROM Pagos
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarSocios]    Script Date: 31/1/2025 10:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarSocios]
AS
BEGIN
    SELECT * FROM Socios
END
GO
