USE [SMK Restaurant]
GO
/****** Object:  Table [dbo].[Detailorder]    Script Date: 14/02/2019 14:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detailorder](
	[Detailid] [int] NOT NULL,
	[Orderid] [nchar](10) NOT NULL,
	[Menuid] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Status] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Detailorder] PRIMARY KEY CLUSTERED 
(
	[Detailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Headerorder]    Script Date: 14/02/2019 14:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Headerorder](
	[OrderID] [nchar](10) NOT NULL,
	[Employeeid] [nchar](6) NOT NULL,
	[Memberid] [nchar](8) NOT NULL,
	[Date] [date] NOT NULL,
	[Payment] [nvarchar](50) NULL,
	[bank] [nvarchar](50) NULL,
	[CardNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Headerorder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Msemployee]    Script Date: 14/02/2019 14:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msemployee](
	[EmployeeID] [nchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Handphone] [nvarchar](13) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Msemployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Msmember]    Script Date: 14/02/2019 14:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msmember](
	[MemberID] [nchar](8) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Handphone] [nvarchar](13) NOT NULL,
	[JoinDate] [date] NOT NULL,
 CONSTRAINT [PK_Msmember] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Msmenu]    Script Date: 14/02/2019 14:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msmenu](
	[MenuID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Photo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Msmenu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Package]    Script Date: 14/02/2019 14:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountMeat] [int] NOT NULL,
	[CountVegetables] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[MaxOrder] [int] NOT NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (1, N'2019020001', 1, 30, 40000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (2, N'2019020002', 2, 20, 20000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (3, N'2019020003', 3, 50, 50000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (4, N'2019020004', 4, 10, 10000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (5, N'2019020005', 5, 25, 25000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (6, N'2019020006', 6, 20, 20000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (7, N'2019020007', 7, 50, 50000, N'Pending')
INSERT [dbo].[Detailorder] ([Detailid], [Orderid], [Menuid], [Qty], [Price], [Status]) VALUES (8, N'2019020008', 8, 10, 15000, N'Pending')
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020001', N'2     ', N'1       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020002', N'2     ', N'2       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020003', N'2     ', N'3       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020004', N'2     ', N'1       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020005', N'2     ', N'1       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020006', N'2     ', N'3       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020007', N'2     ', N'1       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Headerorder] ([OrderID], [Employeeid], [Memberid], [Date], [Payment], [bank], [CardNumber]) VALUES (N'2019020008', N'2     ', N'1       ', CAST(N'2019-02-14' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Msemployee] ([EmployeeID], [Name], [Email], [Password], [Handphone], [Position]) VALUES (N'1     ', N'Hengky', N'hengky@gmail.com', N'Test123', N'08161718191', N'Admin')
INSERT [dbo].[Msemployee] ([EmployeeID], [Name], [Email], [Password], [Handphone], [Position]) VALUES (N'2     ', N'Stanley Giovany', N'stanley.giovany@gmail.com', N'Test123', N'08123456789', N'Cashier')
INSERT [dbo].[Msemployee] ([EmployeeID], [Name], [Email], [Password], [Handphone], [Position]) VALUES (N'3     ', N'Grady Leif', N'grady.leif@gmail.com', N'Test123', N'08976543212', N'Chef')
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'1       ', N'Komala Surya', N'komala.surya@gmail.com', N'01234567891', CAST(N'2019-02-13' AS Date))
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'2       ', N'Alvin Amartya', N'alvin.amartya@gmail.com', N'08127263597', CAST(N'2019-02-14' AS Date))
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'3       ', N'Lailul Rahmaniah', N'lailul.rahmaniah@gmail.com', N'08762186357', CAST(N'2019-02-14' AS Date))
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'4       ', N'Test', N'test@gmail.com', N'08126243682', CAST(N'2019-02-14' AS Date))
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (1, N'Cumi Goreng Terasi', 40000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\cumi-goreng-terasi.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (2, N'Gado Gado', 20000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\Gado2.jpeg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (3, N'Ikan Bakar Bumbu Bali', 50000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\ikan-bakar-bumbu-bali.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (4, N'Lemon Tea', 10000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\lemontea.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (5, N'Mie Ayam', 25000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\MieAyam.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (6, N'Mie Ayam2', 20000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\MieAyam2.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (7, N'Sate Ayam', 50000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\sate-ayam.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (8, N'Teh Poci', 15000, N'C:\Users\ADMIN\source\repos\SMK Restaurant\Resource\tehpoci.jpg')
INSERT [dbo].[Package] ([Id], [Name], [CountMeat], [CountVegetables], [Price], [MaxOrder]) VALUES (1, N'Silver Package', 2, 2, 60000, 100)
INSERT [dbo].[Package] ([Id], [Name], [CountMeat], [CountVegetables], [Price], [MaxOrder]) VALUES (2, N'Gold Package', 2, 3, 75000, 100)
INSERT [dbo].[Package] ([Id], [Name], [CountMeat], [CountVegetables], [Price], [MaxOrder]) VALUES (3, N'Diamond Package', 3, 3, 10000, 100)
ALTER TABLE [dbo].[Detailorder]  WITH CHECK ADD  CONSTRAINT [FK_Detailorder_Headerorder1] FOREIGN KEY([Orderid])
REFERENCES [dbo].[Headerorder] ([OrderID])
GO
ALTER TABLE [dbo].[Detailorder] CHECK CONSTRAINT [FK_Detailorder_Headerorder1]
GO
ALTER TABLE [dbo].[Detailorder]  WITH CHECK ADD  CONSTRAINT [FK_Detailorder_Msmenu1] FOREIGN KEY([Menuid])
REFERENCES [dbo].[Msmenu] ([MenuID])
GO
ALTER TABLE [dbo].[Detailorder] CHECK CONSTRAINT [FK_Detailorder_Msmenu1]
GO
ALTER TABLE [dbo].[Headerorder]  WITH CHECK ADD  CONSTRAINT [FK_Headerorder_Msemployee1] FOREIGN KEY([Employeeid])
REFERENCES [dbo].[Msemployee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Headerorder] CHECK CONSTRAINT [FK_Headerorder_Msemployee1]
GO
ALTER TABLE [dbo].[Headerorder]  WITH CHECK ADD  CONSTRAINT [FK_Headerorder_Msmember1] FOREIGN KEY([Memberid])
REFERENCES [dbo].[Msmember] ([MemberID])
GO
ALTER TABLE [dbo].[Headerorder] CHECK CONSTRAINT [FK_Headerorder_Msmember1]
GO
