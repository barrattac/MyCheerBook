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
ALTER TABLE [dbo].[UserStatus] DROP CONSTRAINT [FK__UserStatu__UserI__41B8C09B]
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
ALTER TABLE [dbo].[TeamNews] DROP CONSTRAINT [FK__TeamNews__UserID__10E07F16]
GO
ALTER TABLE [dbo].[TeamNews] DROP CONSTRAINT [FK__TeamNews__TeamID__0FEC5ADD]
GO
ALTER TABLE [dbo].[TeamImages] DROP CONSTRAINT [FK__TeamImage__TeamI__239E4DCF]
GO
ALTER TABLE [dbo].[TeamImages] DROP CONSTRAINT [FK__TeamImage__Image__22AA2996]
GO
ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK__Friends__Y_ID__0C50D423]
GO
ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK__Friends__F_ID__0D44F85C]
GO
ALTER TABLE [dbo].[UserStatus] DROP CONSTRAINT [DF_UserStatus_Active]
GO
ALTER TABLE [dbo].[UserStatus] DROP CONSTRAINT [DF__UserStatus__DATE__42ACE4D4]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__Active__21B6055D]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__ProfileIm__20C1E124]
GO
ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [DF__Teams__Active__1FCDBCEB]
GO
ALTER TABLE [dbo].[TeamNews] DROP CONSTRAINT [DF__TeamNews__Active__12C8C788]
GO
ALTER TABLE [dbo].[TeamNews] DROP CONSTRAINT [DF__TeamNews__Date__11D4A34F]
GO
ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [DF__Friends__Request__0E391C95]
GO
/****** Object:  Table [dbo].[Videos]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[Videos]
GO
/****** Object:  Table [dbo].[UserVideos]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[UserVideos]
GO
/****** Object:  Table [dbo].[UserTeam]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[UserTeam]
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[UserStatus]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserImages]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[UserImages]
GO
/****** Object:  Table [dbo].[TeamVideos]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[TeamVideos]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[Teams]
GO
/****** Object:  Table [dbo].[TeamNews]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[TeamNews]
GO
/****** Object:  Table [dbo].[TeamImages]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[TeamImages]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[Images]
GO
/****** Object:  Table [dbo].[Friends]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP TABLE [dbo].[Friends]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[UpdateUser]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeam]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[UpdateTeam]
GO
/****** Object:  StoredProcedure [dbo].[UnFriend]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[UnFriend]
GO
/****** Object:  StoredProcedure [dbo].[SearchUsers]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[SearchUsers]
GO
/****** Object:  StoredProcedure [dbo].[SearchTeams]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[SearchTeams]
GO
/****** Object:  StoredProcedure [dbo].[RequestFriends]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[RequestFriends]
GO
/****** Object:  StoredProcedure [dbo].[MakeFriends]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[MakeFriends]
GO
/****** Object:  StoredProcedure [dbo].[GetVideos]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[GetVideos]
GO
/****** Object:  StoredProcedure [dbo].[GetUserVideos]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[GetUserVideos]
GO
/****** Object:  StoredProcedure [dbo].[GetUserTeams]    Script Date: 1/14/2014 2:50:33 PM ******/
DROP PROCEDURE [dbo].[GetUserTeams]
GO
/****** Object:  StoredProcedure [dbo].[GetUserStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetUserStatus]
GO
/****** Object:  StoredProcedure [dbo].[GetUserImages]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetUserImages]
GO
/****** Object:  StoredProcedure [dbo].[GetTeamNews]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetTeamNews]
GO
/****** Object:  StoredProcedure [dbo].[GetTeamMembers]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetTeamMembers]
GO
/****** Object:  StoredProcedure [dbo].[GetTeamImages]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetTeamImages]
GO
/****** Object:  StoredProcedure [dbo].[GetImages]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetImages]
GO
/****** Object:  StoredProcedure [dbo].[GetFriendStatus2]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetFriendStatus2]
GO
/****** Object:  StoredProcedure [dbo].[GetFriendStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetFriendStatus]
GO
/****** Object:  StoredProcedure [dbo].[GetFriends]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetFriends]
GO
/****** Object:  StoredProcedure [dbo].[GetFriendRequest]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[GetFriendRequest]
GO
/****** Object:  StoredProcedure [dbo].[FriendsYouRequested]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[FriendsYouRequested]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserVideos]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[DeleteUserVideos]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserImages]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[DeleteUserImages]
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[CreateUser]
GO
/****** Object:  StoredProcedure [dbo].[CreateTeam]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[CreateTeam]
GO
/****** Object:  StoredProcedure [dbo].[AddVideo]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddVideo]
GO
/****** Object:  StoredProcedure [dbo].[AddUserVideo]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddUserVideo]
GO
/****** Object:  StoredProcedure [dbo].[AddUserTeam]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddUserTeam]
GO
/****** Object:  StoredProcedure [dbo].[AddUserImage]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddUserImage]
GO
/****** Object:  StoredProcedure [dbo].[AddTeamNews]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddTeamNews]
GO
/****** Object:  StoredProcedure [dbo].[AddStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddStatus]
GO
/****** Object:  StoredProcedure [dbo].[AddImage]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[AddImage]
GO
/****** Object:  StoredProcedure [dbo].[ActiveUsers]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[ActiveUsers]
GO
/****** Object:  StoredProcedure [dbo].[ActiveTeams]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP PROCEDURE [dbo].[ActiveTeams]
GO
USE [master]
GO
/****** Object:  Database [MyCheerBook]    Script Date: 1/14/2014 2:50:34 PM ******/
DROP DATABASE [MyCheerBook]
GO
/****** Object:  Database [MyCheerBook]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ActiveTeams]    Script Date: 1/14/2014 2:50:34 PM ******/
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
	ORDER BY TeamName
END

GO
/****** Object:  StoredProcedure [dbo].[ActiveUsers]    Script Date: 1/14/2014 2:50:34 PM ******/
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
	ORDER BY LastName, FirstName
END

GO
/****** Object:  StoredProcedure [dbo].[AddImage]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddImage] 
	@Location TEXT,
	@Title VARCHAR(25) = null
AS
BEGIN
	INSERT INTO Images
	VALUES (@Location, @Title)
END

GO
/****** Object:  StoredProcedure [dbo].[AddStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddStatus]
	@UserID INT,
	@Status TEXT,
	@Date DATETIME
AS
BEGIN
	INSERT INTO UserStatus
	VALUES (@UserID, @Status, @Date, 1)
END

GO
/****** Object:  StoredProcedure [dbo].[AddTeamNews]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTeamNews]
	@UserID INT,
	@Status TEXT,
	@Date DATETIME,
	@TeamID INT
AS
BEGIN
	INSERT INTO TeamNews(TeamID, UserID, Status, Date, Active)
	VALUES (@TeamID, @UserID, @Status, @Date, 1)
END

GO
/****** Object:  StoredProcedure [dbo].[AddUserImage]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUserImage] 
	@UserID INT,
	@ImageID INT
AS
BEGIN
	INSERT INTO UserImages
	VALUES (@UserID, @ImageID)
END

GO
/****** Object:  StoredProcedure [dbo].[AddUserTeam]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AddUserVideo]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUserVideo]
	@UserID INT,
	@VideoID INT
AS
BEGIN
	INSERT INTO UserVideos
	VALUES (@UserID, @VideoID)
END

GO
/****** Object:  StoredProcedure [dbo].[AddVideo]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddVideo]
	@Location TEXT,
	@Title VARCHAR(25)
AS
BEGIN
	INSERT INTO Videos
	VALUES (@Location, @Title)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateTeam]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteUserImages]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUserImages]
	@UserID INT,
	@ImageID INT
AS
BEGIN
	DELETE FROM UserImages
	WHERE UserID = @userID
	AND ImageID = @ImageID
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUserVideos]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUserVideos]
	@UserID INT,
	@VideoID INT
AS
BEGIN
	DELETE FROM UserVideos
	WHERE UserID = @userID
	AND VideoID = @VideoID
END

GO
/****** Object:  StoredProcedure [dbo].[FriendsYouRequested]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FriendsYouRequested]
	@UserID INT
AS
BEGIN
	SELECT Users.ID, Users.FirstName, Users.LastName, Users.Email, Users.Password, Users.ProfileImage FROM Users
	JOIN Friends ON Users.ID = Friends.F_ID
	WHERE Y_ID = @UserID
	AND Friends.Request = 1
	ORDER BY Users.LastName, Users.FirstName
END

GO
/****** Object:  StoredProcedure [dbo].[GetFriendRequest]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFriendRequest]
	@UserID INT
AS
BEGIN
	SELECT Users.ID, Users.FirstName, Users.LastName, Users.Email, Users.Password, Users.ProfileImage FROM Users
	JOIN Friends ON Users.ID = Friends.Y_ID
	WHERE F_ID = @UserID
	AND Friends.Request = 1
	ORDER BY Users.LastName, Users.FirstName
END

GO
/****** Object:  StoredProcedure [dbo].[GetFriends]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFriends]
	@UserID INT
AS
BEGIN
	SELECT Users.ID, Users.FirstName, Users.LastName, Users.Email, Users.Password, Users.ProfileImage FROM Users
	JOIN Friends ON Users.ID = Friends.F_ID
	WHERE Y_ID = @UserID
	AND Friends.Request = 2
	UNION
	SELECT Users.ID, Users.FirstName, Users.LastName, Users.Email, Users.Password, Users.ProfileImage FROM Users
	JOIN Friends ON Users.ID = Friends.Y_ID
	WHERE F_ID = @UserID
	AND Friends.Request = 2
	ORDER BY Users.LastName, Users.FirstName
END

GO
/****** Object:  StoredProcedure [dbo].[GetFriendStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFriendStatus]
	@UserID INT
AS
BEGIN
	SELECT UserStatus.* FROM UserStatus
	JOIN Friends ON UserStatus.UserID = Friends.Y_ID
	WHERE Friends.F_ID = @UserID
	AND Friends.Request = 2
	AND UserStatus.Active = 1
	ORDER BY UserStatus.Date DESC
END

GO
/****** Object:  StoredProcedure [dbo].[GetFriendStatus2]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFriendStatus2]
	@UserID INT
AS
BEGIN
	SELECT UserStatus.* FROM UserStatus
	JOIN Friends ON UserStatus.UserID = Friends.F_ID
	WHERE Friends.Y_ID = @UserID
	AND Friends.Request = 2
	AND UserStatus.Active = 1
	ORDER BY UserStatus.Date DESC
END

GO
/****** Object:  StoredProcedure [dbo].[GetImages]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetTeamImages]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeamImages]
	@TeamID INT
AS
BEGIN
	SELECT Images.ID, Images.Location, Images.Title FROM Images
	JOIN TeamImages ON Images.ID = TeamImages.ImageID
	WHERE TeamID = @TeamID
END

GO
/****** Object:  StoredProcedure [dbo].[GetTeamMembers]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeamMembers]
	@TeamID INT
AS
BEGIN
	SELECT Users.* FROM Users
	JOIN UserTeam ON Users.ID = UserTeam.UserID
	WHERE UserTeam.TeamID = @TeamID
	AND Users.Active = 1
	ORDER BY Users.LastName, Users.FirstName
END

GO
/****** Object:  StoredProcedure [dbo].[GetTeamNews]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeamNews]
	@TeamID INT
AS
BEGIN
	SELECT ID, UserID, Status, Date FROM TeamNews
	WHERE TeamID = @TeamID
	AND Active = 1
	ORDER BY TeamNews.Date DESC
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserImages]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[GetUserStatus]
	@UserID INT
AS
BEGIN
	SELECT UserStatus.* FROM UserStatus
	WHERE UserStatus.UserID = @UserID
	AND UserStatus.Active = 1
	ORDER BY UserStatus.Date DESC
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserTeams]    Script Date: 1/14/2014 2:50:34 PM ******/
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
	SELECT Teams.* FROM Teams
	JOIN UserTeam ON Teams.ID = UserTeam.TeamID
	WHERE UserTeam.UserID = @UserID
	AND Teams.Active = 1
	ORDER BY Teams.TeamName
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserVideos]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserVideos]
	@UserID INT
AS
BEGIN
	SELECT Videos.ID, Videos.Location, Videos.Title FROM Videos
	JOIN UserVideos ON Videos.ID = UserVideos.VideoID
	WHERE UserID = @UserID
END

GO
/****** Object:  StoredProcedure [dbo].[GetVideos]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVideos]

AS
BEGIN
	SELECT * FROM Videos
END

GO
/****** Object:  StoredProcedure [dbo].[MakeFriends]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MakeFriends]
	@UserID INT,
	@FriendID INT
AS
BEGIN
	UPDATE Friends
	SET Request = 2
	WHERE Y_ID = @UserID
	AND F_ID = @FriendID
	OR
	Y_ID = @FriendID
	AND F_ID = @UserID

END

GO
/****** Object:  StoredProcedure [dbo].[RequestFriends]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RequestFriends]
	@UserID INT,
	@FriendID INT
AS
BEGIN
	INSERT INTO Friends(Y_ID, F_ID, Request)
	VALUES(@UserID, @FriendID, 1)
END

GO
/****** Object:  StoredProcedure [dbo].[SearchTeams]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchTeams]
	@Word VARCHAR(100)
AS
BEGIN
	SELECT * FROM Teams
	WHERE Active = 1
	AND( 
		TeamName LIKE @Word
		OR CoachName LIKE @Word
		OR City LIKE @Word
		OR State LIKE @Word
		)
		ORDER BY TeamName
END

GO
/****** Object:  StoredProcedure [dbo].[SearchUsers]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchUsers]
	@Word VARCHAR(100)
AS
BEGIN
	SELECT * FROM Users
	WHERE Active = 1
	AND( 
		FirstName LIKE @Word
		OR LastName LIKE @Word
		OR Email LIKE @Word
		)
		ORDER BY LastName, FirstName
END

GO
/****** Object:  StoredProcedure [dbo].[UnFriend]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UnFriend]
	@UserID INT,
	@FriendID INT
AS
BEGIN
	UPDATE Friends
	SET Request = 0
	WHERE Y_ID = @UserID
	AND F_ID = @FriendID
	OR
	Y_ID = @FriendID
	AND F_ID = @UserID
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateTeam]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[Friends]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friends](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Y_ID] [int] NOT NULL,
	[F_ID] [int] NOT NULL,
	[Request] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[TeamImages]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[TeamNews]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamNews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Status] [text] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[TeamVideos]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[UserImages]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[UserStatus]    Script Date: 1/14/2014 2:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Status] [text] NOT NULL,
	[DATE] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTeam]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[UserVideos]    Script Date: 1/14/2014 2:50:34 PM ******/
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
/****** Object:  Table [dbo].[Videos]    Script Date: 1/14/2014 2:50:34 PM ******/
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
ALTER TABLE [dbo].[Friends] ADD  DEFAULT ((1)) FOR [Request]
GO
ALTER TABLE [dbo].[TeamNews] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[TeamNews] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Teams] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [ProfileImage]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[UserStatus] ADD  DEFAULT (getdate()) FOR [DATE]
GO
ALTER TABLE [dbo].[UserStatus] ADD  CONSTRAINT [DF_UserStatus_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD FOREIGN KEY([F_ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD FOREIGN KEY([Y_ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[TeamImages]  WITH CHECK ADD FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([ID])
GO
ALTER TABLE [dbo].[TeamImages]  WITH CHECK ADD FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[TeamNews]  WITH CHECK ADD FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[TeamNews]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
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
