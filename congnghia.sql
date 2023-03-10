USE [master]
GO
/****** Object:  Database [blogDB]    Script Date: 05/06/2022 19:50:57 ******/
CREATE DATABASE [blogDB] ON  PRIMARY 
( NAME = N'blogDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\blogDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'blogDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\blogDB_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [blogDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [blogDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [blogDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [blogDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [blogDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [blogDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [blogDB] SET ARITHABORT OFF
GO
ALTER DATABASE [blogDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [blogDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [blogDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [blogDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [blogDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [blogDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [blogDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [blogDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [blogDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [blogDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [blogDB] SET  ENABLE_BROKER
GO
ALTER DATABASE [blogDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [blogDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [blogDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [blogDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [blogDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [blogDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [blogDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [blogDB] SET  READ_WRITE
GO
ALTER DATABASE [blogDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [blogDB] SET  MULTI_USER
GO
ALTER DATABASE [blogDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [blogDB] SET DB_CHAINING OFF
GO
USE [blogDB]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05/06/2022 19:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[RoleDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 05/06/2022 19:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[Tite] [nvarchar](255) NULL,
	[Thumb] [nvarchar](255) NULL,
	[Published] [bit] NULL,
	[Alias] [nvarchar](255) NULL,
	[Author] [nvarchar](255) NULL,
	[AccountId] [int] NULL,
	[ShortContent] [nvarchar](255) NULL,
	[Tag] [nvarchar](255) NULL,
	[CastID] [int] NULL,
	[isHot] [bit] NULL,
	[isNewfeed] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[Contents] [nvarchar](max) NULL,
	[Thumb1] [nvarchar](255) NULL,
	[Thumb2] [nvarchar](255) NULL,
 CONSTRAINT [PK_NPost] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 05/06/2022 19:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CastId] [int] IDENTITY(1,1) NOT NULL,
	[CastName] [nvarchar](250) NULL,
	[Title] [nvarchar](250) NULL,
	[Alias] [nvarchar](250) NULL,
	[MetaDesc] [nvarchar](250) NULL,
	[MetaKey] [nvarchar](250) NULL,
	[Thumb] [nvarchar](250) NULL,
	[Published] [bit] NULL,
	[Ordering] [int] NULL,
	[Parent] [int] NULL,
	[Levels] [int] NULL,
	[Icon] [nvarchar](250) NULL,
	[Cover] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CastId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 05/06/2022 19:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nchar](10) NULL,
	[Password] [nvarchar](50) NULL,
	[Salt] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[LastLogin] [datetime] NULL,
	[RoleID] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Account_Role]    Script Date: 05/06/2022 19:51:01 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
