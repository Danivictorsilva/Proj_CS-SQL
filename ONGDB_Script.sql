USE [master]
GO
/****** Object:  Database [ONG]    Script Date: 27/09/2022 14:14:36 ******/
CREATE DATABASE [ONG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ONG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ONG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ONG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ONG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ONG] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ONG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ONG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ONG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ONG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ONG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ONG] SET ARITHABORT OFF 
GO
ALTER DATABASE [ONG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ONG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ONG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ONG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ONG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ONG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ONG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ONG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ONG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ONG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ONG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ONG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ONG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ONG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ONG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ONG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ONG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ONG] SET RECOVERY FULL 
GO
ALTER DATABASE [ONG] SET  MULTI_USER 
GO
ALTER DATABASE [ONG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ONG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ONG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ONG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ONG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ONG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ONG', N'ON'
GO
ALTER DATABASE [ONG] SET QUERY_STORE = OFF
GO
USE [ONG]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Nome] [nvarchar](50) NULL,
	[CPF] [nvarchar](11) NOT NULL,
	[Sexo] [char](1) NULL,
	[DataDeNascimento] [date] NULL,
	[Endereco] [nvarchar](50) NULL,
	[Telefone] [nvarchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa_Pet]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa_Pet](
	[CPF] [nvarchar](11) NOT NULL,
	[Chip] [int] NOT NULL,
 CONSTRAINT [PK_Pessoa_Pet] PRIMARY KEY CLUSTERED 
(
	[Chip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pet]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pet](
	[Chip] [int] IDENTITY(1,1) NOT NULL,
	[Familia] [nvarchar](20) NULL,
	[Raca] [nvarchar](20) NULL,
	[Sexo] [char](1) NULL,
	[Nome] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Chip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Khalilah Major', N'28446653141', N'F', CAST(N'1985-12-30' AS Date), N'676 Daren Terrace Suite 212 - Durham, NH / 35924', N'55648903537')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Bradley Mair', N'29333961909', N'M', CAST(N'1991-11-18' AS Date), N'11482 Danial Mission Suite 782 - Evansville, HI / ', N'65032494704')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Crista Taylor', N'29494615301', N'F', CAST(N'1986-08-21' AS Date), N'206 Alberto Squares Suite 784 - Scranton, CO / 340', N'65239966540')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Letisha Simpson', N'30911959700', N'F', CAST(N'1983-07-24' AS Date), N'909 Bryon Pike Apt. 708 - Middletown, KY / 53896', N'77480019289')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Ji Aldred', N'32318819351', N'M', CAST(N'2000-06-27' AS Date), N'83747 Orland Lodge Apt. 638 - New Orleans, RI / 58', N'14265855270')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Herberto Agostinho', N'52368724567', N'M', CAST(N'1992-04-09' AS Date), N'88017 Quigley Flats Suite 155 - Tucson, MT / 20992', N'11434438824')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Horacio Horner', N'63465162803', N'M', CAST(N'1967-08-18' AS Date), N'082 Prosacco Common Suite 254 - Clearwater, MD / 3', N'84618222263')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Keshia Butler', N'66564962371', N'F', CAST(N'1968-03-08' AS Date), N'9258 Abshire Place Suite 223 - Anchorage, KS / 530', N'51785479776')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Jeannine Bone', N'85609121183', N'F', CAST(N'1989-05-20' AS Date), N'6808 Ramona Extension Apt. 517 - Biloxi, OK / 8788', N'93158942518')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Chaya Edwards', N'90064855279', N'F', CAST(N'1977-11-19' AS Date), N'39628 Padberg Radial Suite 618 - Wheeling, HI / 86', N'07090943968')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Nova Perez', N'96905444898', N'F', CAST(N'1979-05-17' AS Date), N'35954 Carroll Stravenue Suite 830 - Enid, HI / 144', N'93294681526')
INSERT [dbo].[Pessoa] ([Nome], [CPF], [Sexo], [DataDeNascimento], [Endereco], [Telefone]) VALUES (N'Cammy Wallace', N'98239409830', N'F', CAST(N'1981-01-08' AS Date), N'2708 Kathryne Ford Suite 674 - Sherman, NE / 56415', N'75605042211')
GO
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'30911959700', 5)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'29494615301', 6)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'66564962371', 7)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'63465162803', 8)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'29333961909', 9)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'85609121183', 11)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'28446653141', 12)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'52368724567', 13)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'96905444898', 14)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'28446653141', 15)
INSERT [dbo].[Pessoa_Pet] ([CPF], [Chip]) VALUES (N'90064855279', 16)
GO
SET IDENTITY_INSERT [dbo].[Pet] ON 

INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (5, N'Enguia', N'-', N'M', N'Teddy')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (6, N'Cachorro', N'ShihTzu', N'M', N'Teddy')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (7, N'Cachorro', N'Basenji', N'F', N'Puppy')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (8, N'Gato', N'-', N'F', N'Chester')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (9, N'Cachorro', N'Boiadeiro Bernês', N'M', N'Astro')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (10, N'Cachorro', N'Greyhound', N'M', N'Tucker')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (11, N'Gato', N'-', N'M', N'Ginger')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (12, N'Cachorro', N'Grande Boiadeiro Sui', N'M', N'Prince')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (13, N'Gato', N'-', N'M', N'Zeus')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (14, N'Cachorro', N'Pinscher Miniatura', N'F', N'Bonnie')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (15, N'Gato', N'-', N'M', N'Houdini')
INSERT [dbo].[Pet] ([Chip], [Familia], [Raca], [Sexo], [Nome]) VALUES (16, N'Gato', N'-', N'F', N'Fluffy')
SET IDENTITY_INSERT [dbo].[Pet] OFF
GO
ALTER TABLE [dbo].[Pessoa_Pet]  WITH CHECK ADD FOREIGN KEY([CPF])
REFERENCES [dbo].[Pessoa] ([CPF])
GO
ALTER TABLE [dbo].[Pessoa_Pet]  WITH CHECK ADD  CONSTRAINT [FK_Pessoa_Pet_Chip] FOREIGN KEY([Chip])
REFERENCES [dbo].[Pet] ([Chip])
GO
ALTER TABLE [dbo].[Pessoa_Pet] CHECK CONSTRAINT [FK_Pessoa_Pet_Chip]
GO
/****** Object:  StoredProcedure [dbo].[Pessoa_Delete]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Pessoa_Delete]
	@CPF nvarchar(11)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE Pessoa WHERE CPF = @CPF
END
GO
/****** Object:  StoredProcedure [dbo].[Pessoa_Insert]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Pessoa_Insert]
	@Nome nvarchar(50),
	@CPF nvarchar(11),
	@Sexo char(1),
	@DataDeNascimento Date,
	@Endereco nvarchar(50),
	@Telefone nvarchar(11)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Pessoa(Nome, CPF, Sexo, DataDeNascimento, Endereco, Telefone)
	VALUES (@Nome, @CPF, @Sexo, @DataDeNascimento, @Endereco, @Telefone);
END
GO
/****** Object:  StoredProcedure [dbo].[Pessoa_Pet_Delete]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Pessoa_Pet_Delete]
	@Chip INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE Pessoa_Pet WHERE Chip = @Chip
END
GO
/****** Object:  StoredProcedure [dbo].[Pessoa_Pet_Insert]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Pessoa_Pet_Insert]
	@CPF NVARCHAR(11),
	@Chip INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Pessoa_Pet(CPF, Chip)
	VALUES (@CPF, @Chip);
END
GO
/****** Object:  StoredProcedure [dbo].[Pessoa_Update]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Pessoa_Update]
	@Nome nvarchar(50),
	@CPF nvarchar(11),
	@Sexo char(1),
	@DataDeNascimento Date,
	@Endereco nvarchar(50),
	@Telefone nvarchar(11)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Pessoa SET Nome = @Nome WHERE CPF = @CPF
	UPDATE Pessoa SET Sexo = @Sexo WHERE CPF = @CPF
	UPDATE Pessoa SET DataDeNascimento = @DataDeNAscimento WHERE CPF = @CPF
	UPDATE Pessoa SET Endereco = @Endereco WHERE CPF = @CPF
	UPDATE Pessoa SET Telefone = @Telefone WHERE CPF = @CPF
END
GO
/****** Object:  StoredProcedure [dbo].[Pet_Delete]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Pet_Delete]
	@Chip int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE Pet WHERE Chip = @Chip

END
GO
/****** Object:  StoredProcedure [dbo].[Pet_Insert]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Pet_Insert]
	@Familia nvarchar(20),
	@Raca nvarchar(20),
	@Sexo char(1),
	@Nome nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Pet(Familia, Raca, Sexo, Nome)
	VALUES (@Familia, @Raca, @Sexo, @Nome);
END
GO
/****** Object:  StoredProcedure [dbo].[Pet_Update]    Script Date: 27/09/2022 14:14:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Pet_Update]
	@Chip int,
	@Familia nvarchar(20),
	@Raca nvarchar(20),
	@Sexo char(1),
	@Nome nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Pet SET Familia = @Familia WHERE Chip = @Chip
	UPDATE Pet SET Raca = @Raca WHERE Chip = @Chip
	UPDATE Pet SET Sexo = @Sexo WHERE Chip = @Chip
	UPDATE Pet SET Nome = @Nome WHERE Chip = @Chip

END
GO
USE [master]
GO
ALTER DATABASE [ONG] SET  READ_WRITE 
GO
