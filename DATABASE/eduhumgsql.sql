USE [HUMGEDU]
GO
/****** Object:  Table [dbo].[baihoc]    Script Date: 9/22/2021 10:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[baihoc](
	[idbaihoc] [int] IDENTITY(1,1) NOT NULL,
	[tieudebaihoc] [text] NOT NULL,
	[motabaihoc] [text] NOT NULL,
	[linkvideobaihoc] [text] NOT NULL,
	[linkbaihoc] [text] NOT NULL,
	[thoigiantaobaihoc] [date] NULL,
	[thoigiansuabaihoc] [date] NULL,
	[nguoitaobaihoc] [nvarchar](50) NULL,
	[nguoisuabaihoc] [nvarchar](50) NULL,
	[trangthaibaihoc] [bit] NULL,
	[idkhoahoc] [int] NOT NULL,
 CONSTRAINT [PK_chitietbaihoc] PRIMARY KEY CLUSTERED 
(
	[idbaihoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danhmuc]    Script Date: 9/22/2021 10:13:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhmuc](
	[iddanhmuc] [int] IDENTITY(1,1) NOT NULL,
	[tendanhmuc] [nvarchar](250) NOT NULL,
	[linkdanhmuc] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_danhmuc] PRIMARY KEY CLUSTERED 
(
	[iddanhmuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khoahoc]    Script Date: 9/22/2021 10:13:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khoahoc](
	[idkhoahoc] [int] IDENTITY(1,1) NOT NULL,
	[tenkhoahoc] [nvarchar](100) NOT NULL,
	[linkkhoahoc] [nvarchar](100) NOT NULL,
	[motakhoahoc] [text] NOT NULL,
	[anhkhoahoc] [text] NOT NULL,
	[thoigiantaokhoahoc] [date] NULL,
	[thoigiansuakhoahoc] [date] NULL,
	[nguoitaokhoahoc] [nvarchar](50) NULL,
	[nguoisuakhoahoc] [nvarchar](50) NULL,
	[trangthaikhoahoc] [bit] NOT NULL,
	[iddanhmuc] [int] NOT NULL,
 CONSTRAINT [PK_khoahoc] PRIMARY KEY CLUSTERED 
(
	[idkhoahoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taikhoan]    Script Date: 9/22/2021 10:13:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[iduser] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[mail] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongbao]    Script Date: 9/22/2021 10:13:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongbao](
	[idthongbao] [int] IDENTITY(1,1) NOT NULL,
	[motathongbao] [text] NULL,
	[linkthongbao] [text] NULL,
 CONSTRAINT [PK_thongbao] PRIMARY KEY CLUSTERED 
(
	[idthongbao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[baihoc]  WITH CHECK ADD  CONSTRAINT [FK_baihoc_khoahoc] FOREIGN KEY([idkhoahoc])
REFERENCES [dbo].[khoahoc] ([idkhoahoc])
GO
ALTER TABLE [dbo].[baihoc] CHECK CONSTRAINT [FK_baihoc_khoahoc]
GO
ALTER TABLE [dbo].[khoahoc]  WITH CHECK ADD  CONSTRAINT [FK_khoahoc_danhmuc] FOREIGN KEY([iddanhmuc])
REFERENCES [dbo].[danhmuc] ([iddanhmuc])
GO
ALTER TABLE [dbo].[khoahoc] CHECK CONSTRAINT [FK_khoahoc_danhmuc]
GO
