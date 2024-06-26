USE [Insurance]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 30-04-2024 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[UserName] [varchar](50) NOT NULL,
	[CardNumber] [int] NOT NULL,
	[Expiry] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credentials]    Script Date: 30-04-2024 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credentials](
	[UserName] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pol]    Script Date: 30-04-2024 18:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pol](
	[UserName] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[Polic] [varchar](5000) NOT NULL,
 CONSTRAINT [PK_Pol] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cards] ([UserName], [CardNumber], [Expiry]) VALUES (N'Prasanna', 123, N'123       ')
GO
INSERT [dbo].[Credentials] ([UserName], [UserId], [Password]) VALUES (N'Prasanna', 1, N'Admin321@')
INSERT [dbo].[Credentials] ([UserName], [UserId], [Password]) VALUES (N'Shruthi', 3, N'Enter321@')
GO
INSERT [dbo].[Pol] ([UserName], [UserId], [Polic]) VALUES (N'Prasanna', 1, N'vehicle insurance policy')
INSERT [dbo].[Pol] ([UserName], [UserId], [Polic]) VALUES (N'Shruthi', 3, N'Health Policy')
GO
