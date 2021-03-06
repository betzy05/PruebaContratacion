USE [master]
GO
/****** Object:  Database [Mlg]    Script Date: 20/05/2021 9:51:37 ******/
CREATE DATABASE [Mlg]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mlg', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Mlg.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mlg_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Mlg_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mlg].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mlg] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mlg] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mlg] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mlg] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mlg] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mlg] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mlg] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mlg] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mlg] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mlg] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mlg] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mlg] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mlg] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mlg] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mlg] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Mlg] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mlg] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mlg] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mlg] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mlg] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mlg] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mlg] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mlg] SET RECOVERY FULL 
GO
ALTER DATABASE [Mlg] SET  MULTI_USER 
GO
ALTER DATABASE [Mlg] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mlg] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mlg] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mlg] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mlg] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mlg', N'ON'
GO
ALTER DATABASE [Mlg] SET QUERY_STORE = OFF
GO
USE [Mlg]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/05/2021 9:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelClienteTienda]    Script Date: 20/05/2021 9:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelClienteTienda](
	[id_Cliente] [int] NULL,
	[id_Tienda] [int] NULL,
	[monto] [int] NULL,
	[fecha] [date] NULL,
	[idRel] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 20/05/2021 9:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RelClienteTienda]  WITH CHECK ADD FOREIGN KEY([id_Cliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[RelClienteTienda]  WITH CHECK ADD FOREIGN KEY([id_Tienda])
REFERENCES [dbo].[Tienda] ([id])
GO
/****** Object:  StoredProcedure [dbo].[sp_MaxCompras]    Script Date: 20/05/2021 9:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_MaxCompras]
as
begin
	select rct.id_Cliente, cliente.Nombre, COUNT(*) as ComprasHechas FROM RelClienteTienda rct
	inner join Clientes cliente on cliente.id= rct.id_Cliente
	group by rct.id_Cliente, cliente.Nombre	
	having COUNT(*)>2
end
GO
USE [master]
GO
ALTER DATABASE [Mlg] SET  READ_WRITE 
GO
