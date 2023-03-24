USE [master]
GO
/****** Object:  Database [GiveGood]    Script Date: 23.03.2023 18:11:45 ******/
CREATE DATABASE [GiveGood]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GiveGood', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GiveGood.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GiveGood_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GiveGood_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GiveGood] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GiveGood].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GiveGood] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GiveGood] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GiveGood] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GiveGood] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GiveGood] SET ARITHABORT OFF 
GO
ALTER DATABASE [GiveGood] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GiveGood] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GiveGood] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GiveGood] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GiveGood] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GiveGood] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GiveGood] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GiveGood] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GiveGood] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GiveGood] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GiveGood] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GiveGood] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GiveGood] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GiveGood] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GiveGood] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GiveGood] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GiveGood] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GiveGood] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GiveGood] SET  MULTI_USER 
GO
ALTER DATABASE [GiveGood] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GiveGood] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GiveGood] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GiveGood] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GiveGood] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GiveGood] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GiveGood] SET QUERY_STORE = OFF
GO
USE [GiveGood]
GO
/****** Object:  Table [dbo].[Action]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
	[ActionID] [int] NOT NULL,
	[ActionName] [nvarchar](100) NOT NULL,
	[ActionTypeID] [int] NOT NULL,
	[ActionDescription] [nvarchar](max) NOT NULL,
	[ActionMaxParticipants] [int] NOT NULL,
	[ActionStatusID] [int] NOT NULL,
	[ActionRegisterDate] [date] NOT NULL,
	[ActionStartDate] [date] NOT NULL,
	[ActionFinishDate] [date] NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActionDistrict]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionDistrict](
	[DistrictID] [int] NOT NULL,
	[ActionID] [int] NOT NULL,
 CONSTRAINT [PK_ActionDistrict] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC,
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActionOrganizer]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionOrganizer](
	[ActionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ActionOrganizer] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActionParticipant]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionParticipant](
	[ActionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ActionParticipant] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActionStatus]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionStatus](
	[ActionStatusID] [int] NOT NULL,
	[ActionStatusName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ActionStatus] PRIMARY KEY CLUSTERED 
(
	[ActionStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActionType]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionType](
	[ActionTypeID] [int] NOT NULL,
	[ActionTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ActionType] PRIMARY KEY CLUSTERED 
(
	[ActionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictID] [int] NOT NULL,
	[DistrictName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] NOT NULL,
	[UserSurname] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPatronymic] [nvarchar](50) NULL,
	[BirthDate] [date] NOT NULL,
	[Phone] [nvarchar](16) NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDistrict]    Script Date: 23.03.2023 18:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDistrict](
	[DistrictID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_UserDistrict] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (1, N'Проект "чистота 5"', 1, N'Убрать мусор на территории парка', 10, 1, CAST(N'2023-03-10' AS Date), CAST(N'2023-03-20' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (2, N'Человек собаке друг', 2, N'Собрать корма и гуманитарную помощь  для приютов для собак', 20, 1, CAST(N'2023-03-10' AS Date), CAST(N'2023-03-25' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (3, N'Гуляй народ', 3, N'Провести конкурсы на день города', 10, 2, CAST(N'2023-03-08' AS Date), CAST(N'2023-03-14' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (4, N'Глоток свежего воздуха', 4, N'Доставить продукты питания лицам, находящимя в инфекционной изоляции', 10, 2, CAST(N'2023-03-09' AS Date), CAST(N'2023-03-13' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (5, N'Мы вместе', 5, N'Организация трансфера инвалидов центра реабилитации на концерт', 7, 1, CAST(N'2023-03-10' AS Date), CAST(N'2023-03-16' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (6, N'Помни героев', 6, N'Организация встречи ветеранов боевых действий', 10, 1, CAST(N'2023-03-11' AS Date), CAST(N'2023-03-19' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (7, N'Проект "чистота 4"', 1, N'Убрать мусор на территории парка', 10, 2, CAST(N'2023-03-10' AS Date), CAST(N'2023-03-13' AS Date), NULL)
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (11, N'Веселое детство', 7, N'Ремонтироване объектов детской площадки', 5, 3, CAST(N'2021-05-21' AS Date), CAST(N'2021-05-23' AS Date), CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (12, N'Всемирная паутина', 8, N'Настройка интернет оборудования для пожилых людей', 5, 3, CAST(N'2021-05-22' AS Date), CAST(N'2021-05-24' AS Date), CAST(N'2021-05-26' AS Date))
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (13, N'будь внимателен', 8, N'Проведенение вебинара по интернет безопасности для учеников школы', 6, 2, CAST(N'2021-05-23' AS Date), CAST(N'2021-05-25' AS Date), CAST(N'2021-05-27' AS Date))
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (14, N'тест', 1, N'тест
тест
тест', 10, 1, CAST(N'0001-01-01' AS Date), CAST(N'2023-03-21' AS Date), CAST(N'2023-03-23' AS Date))
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionTypeID], [ActionDescription], [ActionMaxParticipants], [ActionStatusID], [ActionRegisterDate], [ActionStartDate], [ActionFinishDate]) VALUES (15, N'ewrqwerqwerqwe', 1, N'rqwerqwerqwedsfvasd', 12, 1, CAST(N'2023-03-20' AS Date), CAST(N'2023-03-21' AS Date), CAST(N'2023-03-23' AS Date))
GO
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (4, 11)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (4, 12)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (4, 13)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (4, 14)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (4, 15)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (10, 1)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (10, 2)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (10, 3)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (10, 4)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (12, 5)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (12, 6)
INSERT [dbo].[ActionDistrict] ([DistrictID], [ActionID]) VALUES (12, 7)
GO
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (1, 43)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (2, 43)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (3, 43)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (4, 43)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (5, 36)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (6, 36)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (7, 36)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (11, 22)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (12, 22)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (13, 22)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (14, 22)
INSERT [dbo].[ActionOrganizer] ([ActionID], [UserID]) VALUES (15, 22)
GO
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (3, 45)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (3, 46)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (4, 47)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (4, 48)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (4, 49)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (4, 50)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (7, 38)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (7, 39)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (7, 40)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (7, 41)
INSERT [dbo].[ActionParticipant] ([ActionID], [UserID]) VALUES (7, 42)
GO
INSERT [dbo].[ActionStatus] ([ActionStatusID], [ActionStatusName]) VALUES (1, N'Сбор участников')
INSERT [dbo].[ActionStatus] ([ActionStatusID], [ActionStatusName]) VALUES (2, N'Действует')
INSERT [dbo].[ActionStatus] ([ActionStatusID], [ActionStatusName]) VALUES (3, N'Завершена')
GO
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (1, N'Уборка мусора')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (2, N'Сбор средств')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (3, N'Организация мероприятия')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (4, N'Помощь заболевшим')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (5, N'Помошь лицам с ОВЗ и маломобильным')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (6, N'Помощь ветеранам')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (7, N'Техническая помощь')
INSERT [dbo].[ActionType] ([ActionTypeID], [ActionTypeName]) VALUES (8, N'IT помощь')
GO
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (1, N'Адмиралтейский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (2, N'Василеостровский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (3, N'Выборгский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (4, N'Калининский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (5, N'Кировский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (6, N'Колпинский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (7, N'Красногвардейский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (8, N'Красносельский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (9, N'Кронштадтcкий')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (10, N'Курортный')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (11, N'Московский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (12, N'Невский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (13, N'Петроградский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (14, N'Петродворцовый')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (15, N'Приморский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (16, N'Пушкинский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (17, N'Фрунзенский')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (18, N'Центральный')
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Организатор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Менеджер волонтеров')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Волонтер')
GO
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (1, N'Абрамов', N'Анатолий', N'Вадимович', CAST(N'2002-01-24' AS Date), N'+7(856)580-55-33', N'Мужчина 1.jpg', N'so4^^uh!_2002', N'8:PY%oQD', N'so4^^uh!_2002google.com', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (2, N'Королёв', N'Гавриил', N'Даниилович', CAST(N'1983-07-01' AS Date), N'+7(608)285-51-10', N'Мужчина 2.jpg', N'osfax+0;_1983', N'+LPoMjJl', N'osfax+0;_1983outlool.com', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (3, N'Аксёнова', N'Марьяна', N'Валентиновна', CAST(N'1980-10-23' AS Date), N'+7(076)868-81-18', N'Женщина 1.jpg', N'jgmwhn&!_1980', N'Ag:Y)*Q"', N'jgmwhn&!_1980yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (4, N'Архипова', N'Фая', N'Андреевна', CAST(N'1983-02-10' AS Date), N'+7(045)881-68-34', N'', N'%!qh8nw1_1983', N'N:№i6C(D', N'%!qh8nw1_1983mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (5, N'Афанасьева', N'Роксалана', N'Рудольфовна', CAST(N'1992-09-23' AS Date), N'+7(740)714-43-74', N'Женщина 3.jpg', N'-7ajpjgg_1992', N'JPl9qU7S', N'-7ajpjgg_1992mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (6, N'Пестова', N'Аксинья', N'Антоновна', CAST(N'1991-05-07' AS Date), N'+7(886)184-02-17', N'Женщина 4.jpg', N'su"8bgvs_1991', N'EM^Rowx?', N'su"8bgvs_1991mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (7, N'Петрова', N'Флора', N'Мэлоровна', CAST(N'1991-03-03' AS Date), N'+7(546)147-87-25', N'Женщина 5.jpg', N'?fuszrx3_1991', N'mErhZmQ_', N'?fuszrx3_1991outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (8, N'Сазонов', N'Варлаам', N'Филатович', CAST(N'1986-03-30' AS Date), N'+7(827)371-65-47', N'Мужчина 8.jpg', N'a+_abced_1986', N'K+Fh%C_s', N'a+_abced_1986mail.ru', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (9, N'Тимофеев', N'Лазарь', N'Максимович', CAST(N'1981-11-08' AS Date), N'+7(518)324-01-50', N'Мужчина 9.jpg', N'92-m""rv_1981', N'0&KZZtO+', N'92-m""rv_1981google.com', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (10, N'Селиверстов', N'Ефим', N'Тихонович', CAST(N'1988-09-25' AS Date), N'+7(028)737-80-68', N'Мужчина 10.jpg', N'9_bz1hd5_1988', N'"Z3*)8%s', N'9_bz1hd5_1988mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (11, N'Нестеров', N'Герасим', N'Павлович', CAST(N'1986-03-03' AS Date), N'+7(751)308-71-22', N'Мужчина 11.jpg', N'w878d5ct_1986', N'XdBJE-R%', N'w878d5ct_1986outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (12, N'Самсонов', N'Мстислав', N'Митрофанович', CAST(N'1999-08-12' AS Date), N'+7(470)666-18-00', N'Мужчина 12.jpg', N'!d7%b!!%_1999', N'CyE-NfHe', N'!d7%b!!%_1999google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (13, N'Калинин', N'Влас', N'Максович', CAST(N'1988-12-14' AS Date), N'+7(167)624-46-56', N'Мужчина 13.jpg', N'=4pl!s№;_1988', N'J-V*Lf+?', N'=4pl!s№;_1988yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (14, N'Сергеев', N'Фрол', N'Дмитриевич', CAST(N'1992-12-13' AS Date), N'+7(636)286-04-63', N'Мужчина 14.jpg', N'lxhi*vo(_1992', N'5bFV(wAz', N'lxhi*vo(_1992google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (15, N'Гаврилов', N'Велор', N'Робертович', CAST(N'1991-01-06' AS Date), N'+7(816)853-45-53', N'Мужчина 15.jpg', N'7^ctrn=r_1991', N'EK1L^No-', N'7^ctrn=r_1991mail.ru', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (16, N'Доронин', N'Кондрат', N'Никитевич', CAST(N'1983-10-03' AS Date), N'+7(738)414-81-52', N'Мужчина 16.jpg', N'4;?e21zw_1983', N'r1p&G2Nt', N'4;?e21zw_1983outlool.com', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (17, N'Ситников', N'Феликс', N'Львович', CAST(N'1984-05-30' AS Date), N'+7(421)815-45-42', N'Мужчина 17.jpg', N'&lyme3=z_1984', N';aAaFMo2', N'&lyme3=z_1984outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (18, N'Денисов', N'Гаянэ', N'Федорович', CAST(N'1999-12-20' AS Date), N'+7(152)088-63-78', N'Мужчина 18.jpg', N'x0=%;64!_1999', N'&bTrMXAA', N'x0=%;64!_1999google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (19, N'Наумов', N'Аверкий', N'Лукьевич', CAST(N'1991-02-24' AS Date), N'+7(663)265-22-56', N'Мужчина 19.jpg', N'")*fx*r3_1991', N'06rWPvj%', N'")*fx*r3_1991mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (20, N'Козлов', N'Юстин', N'Федорович', CAST(N'1996-12-01' AS Date), N'+7(227)521-27-71', N'Мужчина 20.jpg', N';&0s2?_8_1996', N'&%OJuHo7', N';&0s2?_8_1996google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (21, N'Тимофеев', N'Ярослав', N'Альвианович', CAST(N'2002-06-21' AS Date), N'+7(537)280-64-84', N'Мужчина 21.jpg', N'xg(?u4un_2002', N'CV^mYSzZ', N'xg(?u4un_2002mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (22, N'Беляков', N'Архип', N'Даниилович', CAST(N'2002-05-29' AS Date), N'+7(450)575-15-37', N'Мужчина 22.jpg', N'24);_?a№_2002', N'=^cKHaxL', N'24);_?a№_2002outlool.com', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (23, N'Горбачёва', N'Лина', N'Федосеевна', CAST(N'1989-02-20' AS Date), N'+7(368)676-14-23', N'Женщина 6.jpg', N'1((=o-7&_1989', N'=(cW"r(B', N'1((=o-7&_1989outlool.com', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (24, N'Данилова', N'Авигея', N'Иринеевна', CAST(N'1992-05-04' AS Date), N'+7(785)064-20-47', N'Женщина 7.jpg', N'wf0a&8c4_1992', N'ZE4qAwF&', N'wf0a&8c4_1992mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (25, N'Дмитриева', N'Гера', N'Станиславовна', CAST(N'1986-11-05' AS Date), N'+7(651)472-71-28', N'Женщина 8.jpg', N'?w+953sl_1986', N'№Av1OzIm', N'?w+953sl_1986google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (26, N'Ефимов', N'Степан', N'Русланович', CAST(N'1992-02-06' AS Date), N'+7(461)713-05-63', N'Мужчина 26.jpg', N'9&?3gth6_1992', N'LBS:fukY', N'9&?3gth6_1992yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (27, N'Мамонтов', N'Фрол', N'Дмитрьевич', CAST(N'1999-05-11' AS Date), N'+7(286)652-66-58', N'Мужчина 27.jpg', N'c0m^^mmy_1999', N'6phvoFCs', N'c0m^^mmy_1999google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (28, N'Селиверстов', N'Всеволод', N'Адольфович', CAST(N'1983-01-23' AS Date), N'+7(652)568-65-75', N'Мужчина 28.jpg', N'*"gxhye!_1983', N'kRekjQL%', N'*"gxhye!_1983yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (29, N'Селиверстова', N'Пелагея', N'Олеговна', CAST(N'1987-05-05' AS Date), N'+7(644)017-54-88', N'Женщина 16.jpg', N'1isn!cab_1987', N'6?VvIXxa', N'1isn!cab_1987google.com', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (30, N'Степанов', N'Борис', N'Романович', CAST(N'1989-04-04' AS Date), N'+7(161)207-81-03', N'Мужчина 30.jpg', N')0y-_y2h_1989', N'OOrR4(0%', N')0y-_y2h_1989outlool.com', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (31, N'Тетерин', N'Юстин', N'Онисимович', CAST(N'2002-03-21' AS Date), N'+7(457)820-34-14', N'Мужчина 3.jpg', N'd5g2camt_2002', N'RjAj^PQk', N'd5g2camt_2002outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (32, N'Третьякова', N'Влада', N'Ефимовна', CAST(N'1992-02-11' AS Date), N'+7(424)838-65-33', N'Женщина 9.jpg', N'r5z-df6s_1992', N'hUNWo)hS', N'r5z-df6s_1992yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (33, N'Трофимова', N'Дания', N'Владленовна', CAST(N'1980-12-27' AS Date), N'+7(153)073-62-18', N'Женщина 10.jpg', N'+№zf:qeo_1980', N'tikm6wbN', N'+№zf:qeo_1980mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (34, N'Фокина', N'Роксалана', N'Вадимовна', CAST(N'1986-01-08' AS Date), N'+7(068)661-10-56', N'Женщина 11.jpg', N'9n7^!r:v_1986', N'rFvHScok', N'9n7^!r:v_1986outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (35, N'Хохлов', N'Назарий', N'Германнович', CAST(N'1982-01-26' AS Date), N'+7(070)652-00-76', N'Мужчина 4.jpg', N'"pw&r*&"_1982', N'wfL-L?Ah', N'"pw&r*&"_1982google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (36, N'Комаров', N'Яков', N'Тимофеевич', CAST(N'1983-07-29' AS Date), N'+7(706)885-70-84', N'Мужчина 5.jpg', N'mrz6_f&m_1983', N'C(bzY-Ry', N'mrz6_f&m_1983outlool.com', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (37, N'Кудряшова', N'Хана', N'Федотовна', CAST(N'2003-10-31' AS Date), N'+7(218)713-85-22', N'Женщина 10.jpg', N'=%s&w8jx_2003', N':yS5IOv"', N'=%s&w8jx_2003yandex.ru', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (38, N'Лыткин', N'Тимофей', N'Семенович', CAST(N'1983-12-11' AS Date), N'+7(035)557-42-56', N'Мужчина 7.jpg', N'ocg&rvta_1983', N'nKfgExVf', N'ocg&rvta_1983yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (39, N'Нестеров', N'Осип', N'Эдуардович', CAST(N'1982-12-29' AS Date), N'+7(304)404-24-46', N'Мужчина 23.jpg', N'0(0biy^u_1982', N'*UKuXZF9', N'0(0biy^u_1982outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (40, N'Орехова', N'Луиза', N'Васильевна', CAST(N'1982-04-25' AS Date), N'+7(100)543-47-13', N'Женщина 11.jpg', N'maiq%r4v_1982', N':h4kBSbh', N'maiq%r4v_1982yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (41, N'Панова', N'Дания', N'Мироновна', CAST(N'1982-05-18' AS Date), N'+7(260)700-65-68', N'Женщина 12.jpg', N'3i1fvuiq_1982', N'r№Xa8k?t', N'3i1fvuiq_1982yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (42, N'Шарапова', N'Айлин', N'Ростиславовна', CAST(N'1982-05-17' AS Date), N'+7(371)086-60-06', N'Женщина 13.jpg', N'tyykz(;1_1982', N'xcH-8wqk', N'tyykz(;1_1982google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (43, N'Шашкова', N'Эльвира', N'Глебовна', CAST(N'1983-03-28' AS Date), N'+7(441)314-27-15', N'Женщина 14.jpg', N'(5(9q_v"_1983', N'(P№166iQ', N'(5(9q_v"_1983yandex.ru', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (44, N'Яковлева', N'Алия', N'Богуславовна', CAST(N'1993-11-10' AS Date), N'+7(316)424-78-24', N'Женщина 15.jpg', N'o00ud=r8_1993', N'№ajKhYQ9', N'o00ud=r8_1993yandex.ru', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (45, N'Богданов', N'Вадим', N'Вячеславович', CAST(N'2001-09-12' AS Date), N'+7(687)721-62-08', N'Мужчина 24.jpg', N'x8&vq(lp_2001', N'm8PQ+wTf', N'x8&vq(lp_2001outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (46, N'Шарапов', N'Казимир', N'Геннадьевич', CAST(N'2001-12-28' AS Date), N'+7(388)250-86-73', N'Мужчина 25.jpg', N'4)4c_xkm_2001', N'gKk*YBQc', N'4)4c_xkm_2001outlool.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (47, N'Большакова', N'Светлана', N'Тимофеевна', CAST(N'1999-12-16' AS Date), N'+7(424)753-05-06', N'Женщина 18.jpg', N'mi)_№g&b_1999', N'Y?%CBPn7', N'mi)_№g&b_1999yandex.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (48, N'Баранова', N'Антонина', N'Владимировна', CAST(N'1992-01-15' AS Date), N'+7(323)644-02-20', N'Женщина 17.jpg', N'gw+:);08_1992', N'l(zqUrT0', N'gw+:);08_1992mail.ru', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (49, N'Елисеева', N'Тала', N'Дмитриевна', CAST(N'1980-10-16' AS Date), N'+7(324)285-41-26', N'Мужчина 6.jpg', N'yyk+"+)q_1980', N'wUs8"g3-', N'yyk+"+)q_1980google.com', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [BirthDate], [Phone], [Photo], [Login], [Password], [Email], [RoleID]) VALUES (50, N'Брагина', N'Силика', N'Еремеевна', CAST(N'1994-01-09' AS Date), N'', N'Женщина 15.jpg', N'y*=?dr7s_1994', N'_Py_%yS%', N'y*=?dr7s_1994mail.ru', 3)
GO
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 1)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 2)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 3)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 4)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 5)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 6)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (1, 7)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 8)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 9)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 10)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 11)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 12)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 13)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (2, 14)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 15)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 16)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 17)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 18)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 19)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 20)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (3, 21)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 22)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 23)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 24)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 25)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 26)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 27)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (4, 28)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 29)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 30)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 31)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 32)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 33)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 34)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (5, 35)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 43)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 44)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 45)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 46)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 47)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 48)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 49)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (10, 50)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 36)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 37)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 38)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 39)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 40)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 41)
INSERT [dbo].[UserDistrict] ([DistrictID], [UserID]) VALUES (12, 42)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__5E55825B3A513E24]    Script Date: 23.03.2023 18:11:46 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_ActionStatus] FOREIGN KEY([ActionStatusID])
REFERENCES [dbo].[ActionStatus] ([ActionStatusID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_ActionStatus]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_ActionType] FOREIGN KEY([ActionTypeID])
REFERENCES [dbo].[ActionType] ([ActionTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_ActionType]
GO
ALTER TABLE [dbo].[ActionDistrict]  WITH CHECK ADD  CONSTRAINT [FK_ActionDistrict_Action] FOREIGN KEY([ActionID])
REFERENCES [dbo].[Action] ([ActionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionDistrict] CHECK CONSTRAINT [FK_ActionDistrict_Action]
GO
ALTER TABLE [dbo].[ActionDistrict]  WITH CHECK ADD  CONSTRAINT [FK_ActionDistrict_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([DistrictID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionDistrict] CHECK CONSTRAINT [FK_ActionDistrict_District]
GO
ALTER TABLE [dbo].[ActionOrganizer]  WITH CHECK ADD  CONSTRAINT [FK_ActionOrganizer_Action] FOREIGN KEY([ActionID])
REFERENCES [dbo].[Action] ([ActionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionOrganizer] CHECK CONSTRAINT [FK_ActionOrganizer_Action]
GO
ALTER TABLE [dbo].[ActionOrganizer]  WITH CHECK ADD  CONSTRAINT [FK_ActionOrganizer_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionOrganizer] CHECK CONSTRAINT [FK_ActionOrganizer_User]
GO
ALTER TABLE [dbo].[ActionParticipant]  WITH CHECK ADD  CONSTRAINT [FK_ActionParticipant_Action] FOREIGN KEY([ActionID])
REFERENCES [dbo].[Action] ([ActionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionParticipant] CHECK CONSTRAINT [FK_ActionParticipant_Action]
GO
ALTER TABLE [dbo].[ActionParticipant]  WITH CHECK ADD  CONSTRAINT [FK_ActionParticipant_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionParticipant] CHECK CONSTRAINT [FK_ActionParticipant_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserDistrict]  WITH CHECK ADD  CONSTRAINT [FK_UserDistrict_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([DistrictID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDistrict] CHECK CONSTRAINT [FK_UserDistrict_District]
GO
ALTER TABLE [dbo].[UserDistrict]  WITH CHECK ADD  CONSTRAINT [FK_UserDistrict_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDistrict] CHECK CONSTRAINT [FK_UserDistrict_User]
GO
USE [master]
GO
ALTER DATABASE [GiveGood] SET  READ_WRITE 
GO
