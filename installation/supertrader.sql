
/****** Object:  Table [dbo].[Portfolios]    Script Date: 6/18/2024 9:54:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ShareId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Portfolios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShareOwners]    Script Date: 6/18/2024 9:54:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShareOwners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ShareId] [int] NOT NULL,
	[TotalQuantity] [decimal](18, 2) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ShareOwners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharePriceDetails]    Script Date: 6/18/2024 9:54:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharePriceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShareId] [int] NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SharePrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shares]    Script Date: 6/18/2024 9:54:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shares](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Sold] [decimal](18, 2) NOT NULL,
	[Remain]  AS ([Quantity]-[Sold]),
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Shares] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 6/18/2024 9:54:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ShareId] [int] NOT NULL,
	[TransactionType] [int] NOT NULL,
	[Sold] [decimal](18, 2) NOT NULL,
	[Remain] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/18/2024 9:54:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Pwd] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[UserType] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Portfolios] ON 
GO
INSERT [dbo].[Portfolios] ([Id], [UserId], [ShareId], [Quantity], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (1, 2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-17T14:29:15.8009320' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Portfolios] ([Id], [UserId], [ShareId], [Quantity], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (2, 2, 5, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-17T19:31:27.1238017' AS DateTime2), 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Portfolios] OFF
GO
SET IDENTITY_INSERT [dbo].[SharePriceDetails] ON 
GO
INSERT [dbo].[SharePriceDetails] ([Id], [ShareId], [Date], [Price], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (1, 2, CAST(N'2024-01-01T00:00:00' AS SmallDateTime), CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[SharePriceDetails] ([Id], [ShareId], [Date], [Price], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (5, 2, CAST(N'2024-06-17T18:15:00' AS SmallDateTime), CAST(120.00 AS Decimal(18, 2)), CAST(N'2024-06-17T18:15:12.9621401' AS DateTime2), 1, 0)
GO
INSERT [dbo].[SharePriceDetails] ([Id], [ShareId], [Date], [Price], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (6, 5, CAST(N'2024-06-17T19:30:00' AS SmallDateTime), CAST(120.00 AS Decimal(18, 2)), CAST(N'2024-06-17T19:30:23.2492205' AS DateTime2), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[SharePriceDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Shares] ON 
GO
INSERT [dbo].[Shares] ([Id], [Name], [Code], [OwnerId], [Quantity], [Sold], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (1, N'kamuran', N'KAM', 1, CAST(1112.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-15T18:34:58.7415540' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Shares] ([Id], [Name], [Code], [OwnerId], [Quantity], [Sold], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (2, N'kamuran', N'KA2', 1, CAST(1112.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-17T00:21:50.2062949' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Shares] ([Id], [Name], [Code], [OwnerId], [Quantity], [Sold], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (3, N'kamuran', N'KA3', 1, CAST(1112.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-17T10:17:58.0748419' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Shares] ([Id], [Name], [Code], [OwnerId], [Quantity], [Sold], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (4, N'kamuran', N'KAS', 1, CAST(1112.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-17T14:27:31.9727240' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Shares] ([Id], [Name], [Code], [OwnerId], [Quantity], [Sold], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (5, N'kamuran', N'KAQ', 2, CAST(12.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-17T19:26:53.0669761' AS DateTime2), 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Shares] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FullName], [Pwd], [Email], [UserType], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (1, N'Alice', N'1234', N'alice@example.com', 1, CAST(N'2024-06-12T22:59:03.2500000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([Id], [FullName], [Pwd], [Email], [UserType], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (2, N'Bob', N'1234', N'bob@example.com', 2, CAST(N'2024-06-12T23:00:30.3200000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([Id], [FullName], [Pwd], [Email], [UserType], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (3, N'Charlie', N'1234', N'charlie@example.com', 2, CAST(N'2024-06-12T23:00:30.3200000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([Id], [FullName], [Pwd], [Email], [UserType], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (4, N'David', N'1234', N'david@example.com', 3, CAST(N'2024-06-12T23:00:30.3200000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([Id], [FullName], [Pwd], [Email], [UserType], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (5, N'Eve', N'1234', N'eve@example.com', 1, CAST(N'2024-06-12T23:00:30.3200000' AS DateTime2), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Portfolios_ShareId]    Script Date: 6/18/2024 9:54:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Portfolios_ShareId] ON [dbo].[Portfolios]
(
	[ShareId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Portfolios_UserId]    Script Date: 6/18/2024 9:54:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Portfolios_UserId] ON [dbo].[Portfolios]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShareOwners_UserId]    Script Date: 6/18/2024 9:54:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_ShareOwners_UserId] ON [dbo].[ShareOwners]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Shares_OwnerId]    Script Date: 6/18/2024 9:54:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Shares_OwnerId] ON [dbo].[Shares]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_ShareId]    Script Date: 6/18/2024 9:54:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_ShareId] ON [dbo].[Transactions]
(
	[ShareId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_UserId]    Script Date: 6/18/2024 9:54:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_UserId] ON [dbo].[Transactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_Portfolios_Shares] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_Portfolios_Shares]
GO
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_Portfolios_Shares_ShareId] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_Portfolios_Shares_ShareId]
GO
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_Portfolios_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_Portfolios_Users]
GO
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_Portfolios_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_Portfolios_Users_UserId]
GO
ALTER TABLE [dbo].[ShareOwners]  WITH CHECK ADD  CONSTRAINT [FK_ShareOwners_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShareOwners] CHECK CONSTRAINT [FK_ShareOwners_Users_UserId]
GO
ALTER TABLE [dbo].[SharePriceDetails]  WITH CHECK ADD  CONSTRAINT [FK_SharePrices_Shares] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[SharePriceDetails] CHECK CONSTRAINT [FK_SharePrices_Shares]
GO
ALTER TABLE [dbo].[Shares]  WITH CHECK ADD  CONSTRAINT [FK_Shares_Users] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Shares] CHECK CONSTRAINT [FK_Shares_Users]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Shares] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Shares]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Shares_ShareId] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Shares_ShareId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
USE [master]
GO
ALTER DATABASE [SuperTraderDB] SET  READ_WRITE 
GO
