USE [MyCheerBook]
GO
ALTER TABLE [dbo].[UserVideos] DROP CONSTRAINT [FK__UserVideo__Video__2C3393D0]
GO
ALTER TABLE [dbo].[UserVideos] DROP CONSTRAINT [FK__UserVideo__UserI__2B3F6F97]
GO
ALTER TABLE [dbo].[UserTeam] DROP CONSTRAINT [FK__UserTeam__UserID__2A4B4B5E]
GO
ALTER TABLE [dbo].[UserTeam] DROP CONSTRAINT [FK__UserTeam__TeamID__29572725]
GO
ALTER TABLE [dbo].[UserStatus] DROP CONSTRAINT [FK__UserStatu__UserI__4D94879B]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__ProfileIm__286302EC]
GO
ALTER TABLE [dbo].[UserImages] DROP CONSTRAINT [FK__UserImage__UserI__276EDEB3]
GO
ALTER TABLE [dbo].[UserImages] DROP CONSTRAINT [FK__UserImage__Image__267ABA7A]
GO
ALTER TABLE [dbo].[TeamVideos] DROP CONSTRAINT [FK__TeamVideo__Video__25869641]
GO
ALTER TABLE [dbo].[TeamVideos] DROP CONSTRAINT [FK__TeamVideo__TeamI__24927208]
GO
ALTER TABLE [dbo].[TeamImages] DROP CONSTRAINT [FK__TeamImage__TeamI__239E4DCF]
GO
ALTER TABLE [dbo].[TeamImages] DROP CONSTRAINT [FK__TeamImage__Image__22AA2996]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__Active__21B6055D]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__ProfileIm__20C1E124]
GO
ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [DF__Teams__Active__1FCDBCEB]
GO
/****** Object:  Table [dbo].[Videos]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[Videos]
GO
/****** Object:  Table [dbo].[UserVideos]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[UserVideos]
GO
/****** Object:  Table [dbo].[UserTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[UserTeam]
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[UserStatus]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserImages]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[UserImages]
GO
/****** Object:  Table [dbo].[TeamVideos]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[TeamVideos]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[Teams]
GO
/****** Object:  Table [dbo].[TeamImages]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[TeamImages]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP TABLE [dbo].[Images]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[UpdateUser]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[UpdateTeam]
GO
/****** Object:  StoredProcedure [dbo].[GetUserTeams]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[GetUserTeams]
GO
/****** Object:  StoredProcedure [dbo].[GetUserImages]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[GetUserImages]
GO
/****** Object:  StoredProcedure [dbo].[GetImages]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[GetImages]
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[CreateUser]
GO
/****** Object:  StoredProcedure [dbo].[CreateTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[CreateTeam]
GO
/****** Object:  StoredProcedure [dbo].[AddUserTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[AddUserTeam]
GO
/****** Object:  StoredProcedure [dbo].[ActiveUsers]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[ActiveUsers]
GO
/****** Object:  StoredProcedure [dbo].[ActiveTeams]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP PROCEDURE [dbo].[ActiveTeams]
GO
USE [master]
GO
/****** Object:  Database [MyCheerBook]    Script Date: 12/29/2013 9:21:33 PM ******/
DROP DATABASE [MyCheerBook]
GO
/****** Object:  Database [MyCheerBook]    Script Date: 12/29/2013 9:21:33 PM ******/
CREATE DATABASE [MyCheerBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyCheerBook', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MyCheerBook.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyCheerBook_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MyCheerBook_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyCheerBook] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyCheerBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyCheerBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyCheerBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyCheerBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyCheerBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyCheerBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyCheerBook] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyCheerBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MyCheerBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyCheerBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyCheerBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyCheerBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyCheerBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyCheerBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyCheerBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyCheerBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyCheerBook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyCheerBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyCheerBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyCheerBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyCheerBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyCheerBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyCheerBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyCheerBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyCheerBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyCheerBook] SET  MULTI_USER 
GO
ALTER DATABASE [MyCheerBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyCheerBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyCheerBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyCheerBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MyCheerBook]
GO
/****** Object:  StoredProcedure [dbo].[ActiveTeams]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActiveTeams]

AS
BEGIN
	SELECT * FROM Teams
	WHERE Active = 1
END

GO
/****** Object:  StoredProcedure [dbo].[ActiveUsers]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActiveUsers]

AS
BEGIN
	SELECT * FROM Users
	WHERE Active = 1
END

GO
/****** Object:  StoredProcedure [dbo].[AddUserTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUserTeam]
	@UserID INT,
	@TeamID INT
AS
BEGIN
	INSERT INTO UserTeam
	VALUES (@UserID, @TeamID)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateTeam]
	@TeamName VARCHAR(100),
	@CoachName VARCHAR(100),
	@Email VARCHAR(254) = null,
	@Phone NCHAR(10) = null,
	@Line1 VARCHAR(150) = null,
	@Line2 VARCHAR(150) = null,
	@City VARCHAR(100) = null,
	@State NCHAR(2) = null,
	@Zip INT = null,
	@Web TEXT = null,
	@Active INT
AS
BEGIN
	INSERT INTO Teams
	VALUES (@TeamName, @CoachName, @Email, @Phone, @Line1, @Line2, @City, @State, @Zip, @Web, @Active)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser] 
	@FirstName VARCHAR(100) = null,
	@LastName VARCHAR(100) = null,
	@Email VARCHAR(254),
	@Password VARCHAR(100),
	@ProfileImage INT,
	@Active INT
AS
BEGIN
	INSERT INTO Users
	VALUES (@FirstName, @LastName, @Email, @Password, @ProfileImage, @Active)
END

GO
/****** Object:  StoredProcedure [dbo].[GetImages]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetImages]

AS
BEGIN
	SELECT * FROM Images
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserImages]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserImages]
	@UserID INT
AS
BEGIN
	SELECT Images.ID, Images.Location, Images.Title FROM Images
	JOIN UserImages ON Images.ID = UserImages.ImageID
	WHERE UserID = @UserID
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserTeams]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserTeams]
	@UserID INT
AS
BEGIN
	SELECT Teams.*
	FROM Teams
	LEFT JOIN UserTeam ON UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTeam]
	@ID INT,
	@TeamName VARCHAR(100) = null,
	@CoachName VARCHAR(100) = null,
	@Email VARCHAR(254) = null,
	@Phone NCHAR(10) = null,
	@Line1 VARCHAR(150) = null,
	@Line2 VARCHAR(150) = null,
	@City VARCHAR(100) = null,
	@State NCHAR(2) = null,
	@Zip INT = null,
	@Web TEXT = null,
	@Active INT = null
AS
BEGIN
	Update Teams
	SET TeamName = @TeamName, CoachName = @CoachName, Email = @Email, Phone = @Phone, Line1 = @Line1, Line2 = @Line2, City = @City, State = @State, Zip = @Zip, Web = @Web, Active = @Active
	WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	@ID INT,
	@FirstName VARCHAR(100) = null,
	@LastName VARCHAR(100) = null,
	@Email VARCHAR(254) = null,
	@Password VARCHAR(100) = null,
	@ProfileImage INT = null,
	@Active INT = null
AS
BEGIN
	UPDATE Users
	SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password, ProfileImage = @ProfileImage, Active = @Active
	WHERE ID = @ID
END

GO
/****** Object:  Table [dbo].[Images]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [text] NOT NULL,
	[Title] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeamImages]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[ImageID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teams](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [varchar](100) NOT NULL,
	[CoachName] [varchar](100) NOT NULL,
	[Email] [varchar](254) NULL,
	[Phone] [nchar](10) NULL,
	[Line1] [varchar](150) NULL,
	[Line2] [varchar](150) NULL,
	[City] [varchar](100) NULL,
	[State] [nchar](2) NULL,
	[Zip] [int] NULL,
	[Web] [text] NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeamVideos]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamVideos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[VideoID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserImages]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ImageID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](254) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[ProfileImage] [int] NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Status] [text] NOT NULL,
	[Since] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTeam]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTeam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TeamID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserVideos]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVideos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[VideoID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Videos]    Script Date: 12/29/2013 9:21:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Videos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [text] NOT NULL,
	[Title] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Teams] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [ProfileImage]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[TeamImages]  WITH CHECK ADD FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([ID])
GO
ALTER TABLE [dbo].[TeamImages]  WITH CHECK ADD FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[TeamVideos]  WITH CHECK ADD FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[TeamVideos]  WITH CHECK ADD FOREIGN KEY([VideoID])
REFERENCES [dbo].[Videos] ([ID])
GO
ALTER TABLE [dbo].[UserImages]  WITH CHECK ADD FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([ID])
GO
ALTER TABLE [dbo].[UserImages]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([ProfileImage])
REFERENCES [dbo].[Images] ([ID])
GO
ALTER TABLE [dbo].[UserStatus]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserTeam]  WITH CHECK ADD FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[UserTeam]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserVideos]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserVideos]  WITH CHECK ADD FOREIGN KEY([VideoID])
REFERENCES [dbo].[Videos] ([ID])
GO
USE [master]
GO
ALTER DATABASE [MyCheerBook] SET  READ_WRITE 
GO
