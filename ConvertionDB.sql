Create Database ConvertionDB


USE [ConvertionDB]
GO
/****** Object:  Table [dbo].[ConvertionConfig]    Script Date: 13-09-2022 18:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConvertionConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConvertionType] [varchar](50) NULL,
	[FromUnit] [varchar](100) NULL,
	[ToUnit] [varchar](100) NULL,
	[ToValue] [decimal](18, 4) NULL,
 CONSTRAINT [PK_ConvertionConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ConvertionConfig] ON 
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (1, N'Length', N'Inch', N'CM', CAST(2.5400 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (2, N'Length', N'Inch', N'MM', CAST(25.4000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (3, N'Length', N'Foot', N'Meter', CAST(0.3048 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (4, N'Length', N'Foot', N'CM', CAST(30.4800 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (5, N'Length', N'Foot', N'Inch', CAST(12.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (6, N'Weight', N'Tone', N'KG', CAST(1000.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (9, N'Weight', N'KG', N'Gram', CAST(1000.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (10, N'Weight', N'Gram', N'Miligram', CAST(1000.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (11, N'Length', N'CM', N'Inch', CAST(2.5400 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (12, N'Length', N'MM', N'Inch', CAST(25.4000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ConvertionConfig] ([ID], [ConvertionType], [FromUnit], [ToUnit], [ToValue]) VALUES (13, N'Length', N'Meter', N'Foot', CAST(3.2810 AS Decimal(18, 4)))
GO
SET IDENTITY_INSERT [dbo].[ConvertionConfig] OFF
GO
/****** Object:  StoredProcedure [dbo].[GetConvertionConfig]    Script Date: 13-09-2022 18:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GetConvertionConfig]
(
		@ConvertionType varchar(100),
		@FromUnit varchar(100),
		@ToUnit varchar(100)
)
as begin

select * from ConvertionConfig cc
where cc.ConvertionType = @ConvertionType and cc.FromUnit = @FromUnit
and cc.ToUnit = @ToUnit

end
GO
