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
	[Longitude] [decimal](18, 0) NOT NULL,
	[Latitude] [decimal](18, 0) NOT NULL,
	[DeviceId] [int] NOT NULL
 CONSTRAINT [PK_TemperaturesHumidities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TemperaturesHumidities]  WITH CHECK ADD  CONSTRAINT [FK_TemperaturesHumidities_Devices] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Devices] ([Id])
GO
ALTER TABLE [dbo].[TemperaturesHumidities] CHECK CONSTRAINT [FK_TemperaturesHumidities_Devices]
GO



/* Insert Into Table */

Insert into [dbo].[Devices] (Name, CreatedAt) 
Values ('GrizzlyBear',CURRENT_TIMESTAMP);