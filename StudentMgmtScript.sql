USE [master]
GO
/****** Object:  Database [MagicSoftTest]    Script Date: 07/21/2020 16:30:55 ******/
CREATE DATABASE [MagicSoftTest] ON  PRIMARY 
( NAME = N'MagicSoftTest', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\MagicSoftTest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MagicSoftTest_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\MagicSoftTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MagicSoftTest] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MagicSoftTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MagicSoftTest] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MagicSoftTest] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MagicSoftTest] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MagicSoftTest] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MagicSoftTest] SET ARITHABORT OFF
GO
ALTER DATABASE [MagicSoftTest] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MagicSoftTest] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MagicSoftTest] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MagicSoftTest] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MagicSoftTest] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MagicSoftTest] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MagicSoftTest] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MagicSoftTest] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MagicSoftTest] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MagicSoftTest] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MagicSoftTest] SET  DISABLE_BROKER
GO
ALTER DATABASE [MagicSoftTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MagicSoftTest] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MagicSoftTest] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MagicSoftTest] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MagicSoftTest] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MagicSoftTest] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MagicSoftTest] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MagicSoftTest] SET  READ_WRITE
GO
ALTER DATABASE [MagicSoftTest] SET RECOVERY SIMPLE
GO
ALTER DATABASE [MagicSoftTest] SET  MULTI_USER
GO
ALTER DATABASE [MagicSoftTest] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MagicSoftTest] SET DB_CHAINING OFF
GO
USE [MagicSoftTest]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 07/21/2020 16:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Ssn] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([DistrictId], [FirstName], [LastName], [DateOfBirth], [Ssn]) VALUES (1, N'Prakash', N'kumar', CAST(0x0000A4DE00C043A9 AS DateTime), N'ASDF')
INSERT [dbo].[Student] ([DistrictId], [FirstName], [LastName], [DateOfBirth], [Ssn]) VALUES (2, N'Ramesh', N'singh', CAST(0x0000A37100C0693F AS DateTime), N'SDFR')
INSERT [dbo].[Student] ([DistrictId], [FirstName], [LastName], [DateOfBirth], [Ssn]) VALUES (3, N'Ajay', N'kumar', CAST(0x0000A4DE00C043A9 AS DateTime), N'ASDF')
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[Service]    Script Date: 07/21/2020 16:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[SchoolYear] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Service] ON
INSERT [dbo].[Service] ([ServiceId], [StudentId], [SchoolYear], [StartDate], [EndDate]) VALUES (1, 1, 2018, CAST(0x0000A92500C0B190 AS DateTime), CAST(0x0000AA9200C0B190 AS DateTime))
SET IDENTITY_INSERT [dbo].[Service] OFF
/****** Object:  Table [dbo].[Enrollment]    Script Date: 07/21/2020 16:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SchoolYear] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Enrollment] ON
INSERT [dbo].[Enrollment] ([EnrollmentID], [StudentId], [SchoolYear], [StartDate], [EndDate]) VALUES (1, 1, 2019, CAST(0x0000AA9200C0B190 AS DateTime), CAST(0x0000ABFC00C0CA95 AS DateTime))
INSERT [dbo].[Enrollment] ([EnrollmentID], [StudentId], [SchoolYear], [StartDate], [EndDate]) VALUES (2, 2, 2020, CAST(0x0000AB6900C0F152 AS DateTime), CAST(0x0000ABE100C100A2 AS DateTime))
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
