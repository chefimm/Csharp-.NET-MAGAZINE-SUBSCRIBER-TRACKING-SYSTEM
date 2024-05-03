USE [master]
GO
/****** Object:  Database [Dergi-AboneDb]    Script Date: 6.07.2023 14:42:27 ******/
CREATE DATABASE [Dergi-AboneDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dergi-AboneDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dergi-AboneDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Dergi-AboneDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dergi-AboneDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Dergi-AboneDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dergi-AboneDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dergi-AboneDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dergi-AboneDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dergi-AboneDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Dergi-AboneDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dergi-AboneDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Dergi-AboneDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET RECOVERY FULL 
GO
ALTER DATABASE [Dergi-AboneDb] SET  MULTI_USER 
GO
ALTER DATABASE [Dergi-AboneDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dergi-AboneDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dergi-AboneDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dergi-AboneDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Dergi-AboneDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Dergi-AboneDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dergi-AboneDb', N'ON'
GO
ALTER DATABASE [Dergi-AboneDb] SET QUERY_STORE = OFF
GO
USE [Dergi-AboneDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlinanDergi]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlinanDergi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DergiId] [int] NOT NULL,
	[UyeId] [int] NOT NULL,
	[AboneBaslangic] [datetime] NOT NULL,
	[AboneBitis] [datetime] NOT NULL,
	[OdemeTarihi] [datetime] NULL,
 CONSTRAINT [PK_dbo.AlinanDergi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dergi]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dergi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NOT NULL,
	[SiraNo] [varchar](500) NOT NULL,
	[Adet] [int] NOT NULL,
	[EklenmeTarihi] [datetime] NOT NULL,
	[YazarId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Dergi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Kategori] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KategoriDergi]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategoriDergi](
	[Kategori_Id] [int] NOT NULL,
	[Dergi_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.KategoriDergi] PRIMARY KEY CLUSTERED 
(
	[Kategori_Id] ASC,
	[Dergi_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uye]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](70) NOT NULL,
	[Soyad] [varchar](70) NOT NULL,
	[Adres] [char](400) NULL,
	[Tel] [char](11) NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[Mail] [nvarchar](250) NULL,
	[Sifre] [char](32) NULL,
	[Ceza] [int] NOT NULL,
	[Yetki] [char](1) NULL,
 CONSTRAINT [PK_dbo.Uye] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yazar]    Script Date: 6.07.2023 14:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yazar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](200) NOT NULL,
 CONSTRAINT [PK_dbo.Yazar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_DergiId]    Script Date: 6.07.2023 14:42:28 ******/
CREATE NONCLUSTERED INDEX [IX_DergiId] ON [dbo].[AlinanDergi]
(
	[DergiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UyeId]    Script Date: 6.07.2023 14:42:28 ******/
CREATE NONCLUSTERED INDEX [IX_UyeId] ON [dbo].[AlinanDergi]
(
	[UyeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_YazarId]    Script Date: 6.07.2023 14:42:28 ******/
CREATE NONCLUSTERED INDEX [IX_YazarId] ON [dbo].[Dergi]
(
	[YazarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Dergi_Id]    Script Date: 6.07.2023 14:42:28 ******/
CREATE NONCLUSTERED INDEX [IX_Dergi_Id] ON [dbo].[KategoriDergi]
(
	[Dergi_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kategori_Id]    Script Date: 6.07.2023 14:42:28 ******/
CREATE NONCLUSTERED INDEX [IX_Kategori_Id] ON [dbo].[KategoriDergi]
(
	[Kategori_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlinanDergi]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AlinanDergi_dbo.Dergi_DergiId] FOREIGN KEY([DergiId])
REFERENCES [dbo].[Dergi] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlinanDergi] CHECK CONSTRAINT [FK_dbo.AlinanDergi_dbo.Dergi_DergiId]
GO
ALTER TABLE [dbo].[AlinanDergi]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AlinanDergi_dbo.Uye_UyeId] FOREIGN KEY([UyeId])
REFERENCES [dbo].[Uye] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlinanDergi] CHECK CONSTRAINT [FK_dbo.AlinanDergi_dbo.Uye_UyeId]
GO
ALTER TABLE [dbo].[Dergi]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Dergi_dbo.Yazar_YazarId] FOREIGN KEY([YazarId])
REFERENCES [dbo].[Yazar] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dergi] CHECK CONSTRAINT [FK_dbo.Dergi_dbo.Yazar_YazarId]
GO
ALTER TABLE [dbo].[KategoriDergi]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KategoriDergi_dbo.Dergi_Dergi_Id] FOREIGN KEY([Dergi_Id])
REFERENCES [dbo].[Dergi] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KategoriDergi] CHECK CONSTRAINT [FK_dbo.KategoriDergi_dbo.Dergi_Dergi_Id]
GO
ALTER TABLE [dbo].[KategoriDergi]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KategoriDergi_dbo.Kategori_Kategori_Id] FOREIGN KEY([Kategori_Id])
REFERENCES [dbo].[Kategori] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KategoriDergi] CHECK CONSTRAINT [FK_dbo.KategoriDergi_dbo.Kategori_Kategori_Id]
GO
USE [master]
GO
ALTER DATABASE [Dergi-AboneDb] SET  READ_WRITE 
GO
