/*  CREATE DATABASE  */
USE [MASTER]
-- TODO : use environmental variables from mssql.env for '/opt/itera/mssql/data' instead of hardcode
CREATE DATABASE [$(DB_NAME)]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'$(DB_NAME)', FILENAME = N'/opt/itera/mssql/data/$(DB_NAME).mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'$(DB_NAME)_log', FILENAME = N'/opt/itera/mssql/data/$(DB_NAME)_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [$(DB_NAME)] SET COMPATIBILITY_LEVEL = 140
GO
ALTER DATABASE [$(DB_NAME)] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET ARITHABORT OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
GO
ALTER DATABASE [$(DB_NAME)] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [$(DB_NAME)] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [$(DB_NAME)] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET  DISABLE_BROKER 
GO
ALTER DATABASE [$(DB_NAME)] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [$(DB_NAME)] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [$(DB_NAME)] SET  READ_WRITE 
GO
ALTER DATABASE [$(DB_NAME)] SET RECOVERY FULL 
GO
ALTER DATABASE [$(DB_NAME)] SET  MULTI_USER 
GO
ALTER DATABASE [$(DB_NAME)] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [$(DB_NAME)] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [$(DB_NAME)] SET DELAYED_DURABILITY = DISABLED 
GO
USE [$(DB_NAME)]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = On;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = Primary;
GO
USE [$(DB_NAME)]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [$(DB_NAME)] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO




/* Create Tables  */
USE [$(DB_NAME)]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 30.03.2019 14:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemperaturesHumidities]    Script Date: 30.03.2019 14:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemperaturesHumidities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Temperature] [decimal](18, 0) NOT NULL,
	[Humidity] [decimal](18, 0) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[Location] [geography] NULL,
 CONSTRAINT [PK_TemperaturesHumidities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TemperaturesHumidities]  WITH CHECK ADD  CONSTRAINT [FK_TemperaturesHumidities_Devices] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Devices] ([Id])
GO
ALTER TABLE [dbo].[TemperaturesHumidities] CHECK CONSTRAINT [FK_TemperaturesHumidities_Devices]
GO



/* Insert Into Table */

Insert into [TempHumid].[dbo].[Devices] (Name, CreatedAt) 
Values ('GrizzlyBear',CURRENT_TIMESTAMP);