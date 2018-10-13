USE [master]
GO
/****** Object:  Database [QuanLyTieuDoan]    Script Date: 10/12/2018 8:18:47 PM ******/
CREATE DATABASE [QuanLyTieuDoan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyTieuDoan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyTieuDoan.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyTieuDoan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyTieuDoan_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyTieuDoan] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyTieuDoan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyTieuDoan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyTieuDoan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyTieuDoan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyTieuDoan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyTieuDoan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyTieuDoan] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyTieuDoan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyTieuDoan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyTieuDoan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyTieuDoan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyTieuDoan] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyTieuDoan', N'ON'
GO
USE [QuanLyTieuDoan]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Type] [nvarchar](50) NULL CONSTRAINT [DF_Account_Type]  DEFAULT (user_name()),
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CongTacDang]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongTacDang](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Dat] [float] NULL,
	[Kha] [float] NULL,
	[Gioi] [float] NULL,
 CONSTRAINT [PK_CongTacDang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DaiDoi]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaiDoi](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[TieuDoanID] [bigint] NULL,
	[GhiChu] [ntext] NULL,
 CONSTRAINT [PK_DaiDoi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[NoiSinh] [nvarchar](200) NULL,
	[QueQuan] [nvarchar](200) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[NgayVaoDoan] [date] NULL,
	[NgayVaoDang] [date] NULL,
	[NgayNhapNgu] [date] NULL,
	[LopID] [bigint] NULL,
	[LopTruong] [bit] NULL,
	[ChucVu] [nvarchar](50) NULL,
	[CapBac] [nvarchar](50) NULL,
 CONSTRAINT [PK_HocVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocVien_CongTacDang]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien_CongTacDang](
	[HocVienID] [bigint] NOT NULL,
	[CongTacDangID] [bigint] NOT NULL,
	[Diem] [float] NULL,
 CONSTRAINT [PK_HocVien_CongTacDang] PRIMARY KEY CLUSTERED 
(
	[HocVienID] ASC,
	[CongTacDangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocVien_MonHoc]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien_MonHoc](
	[HocVienID] [bigint] NOT NULL,
	[MonHocID] [bigint] NOT NULL,
	[Diem] [float] NULL,
 CONSTRAINT [PK_HocVien_MonHoc] PRIMARY KEY CLUSTERED 
(
	[HocVienID] ASC,
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocVien_TheLuc]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien_TheLuc](
	[HocVienID] [bigint] NOT NULL,
	[MonTheLucID] [bigint] NOT NULL,
	[KetQua] [float] NULL,
	[NgayKiemTra] [date] NULL,
 CONSTRAINT [PK_HocVien_TheLuc] PRIMARY KEY CLUSTERED 
(
	[HocVienID] ASC,
	[MonTheLucID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[DaiDoiID] [bigint] NULL,
	[SoLuong] [int] NULL,
	[GhiChu] [ntext] NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop_MonHoc]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop_MonHoc](
	[LopID] [bigint] NOT NULL,
	[MonHocID] [bigint] NOT NULL,
 CONSTRAINT [PK_Lop_MonHoc] PRIMARY KEY CLUSTERED 
(
	[LopID] ASC,
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[KyHoc] [int] NULL,
	[SoTin] [int] NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonTheLuc]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonTheLuc](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[Dat] [float] NULL,
	[Kha] [float] NULL,
	[Gioi] [float] NULL,
 CONSTRAINT [PK_MonTheLuc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TieuDoan]    Script Date: 10/12/2018 8:18:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuDoan](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[GhiChu] [ntext] NULL,
 CONSTRAINT [PK_TieuDoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Account] ([Username], [Password], [Type]) VALUES (N'diagru', N'1', N'Root')
INSERT [dbo].[Account] ([Username], [Password], [Type]) VALUES (N'user1', N'1', N'User')
SET IDENTITY_INSERT [dbo].[CongTacDang] ON 

INSERT [dbo].[CongTacDang] ([ID], [Ten], [Dat], [Kha], [Gioi]) VALUES (1, N'Thực tập chính trị viên', 6.5, 7, 8)
INSERT [dbo].[CongTacDang] ([ID], [Ten], [Dat], [Kha], [Gioi]) VALUES (2, N'sửa 1', 6.5, 7, 8)
SET IDENTITY_INSERT [dbo].[CongTacDang] OFF
SET IDENTITY_INSERT [dbo].[DaiDoi] ON 

INSERT [dbo].[DaiDoi] ([ID], [Ten], [TieuDoanID], [GhiChu]) VALUES (1, N'Đại đội 130', 1, N'dd')
INSERT [dbo].[DaiDoi] ([ID], [Ten], [TieuDoanID], [GhiChu]) VALUES (2, N'Đại đội 234', 2, N'gg')
INSERT [dbo].[DaiDoi] ([ID], [Ten], [TieuDoanID], [GhiChu]) VALUES (4, N'Đại đội 135', 1, N'aa')
SET IDENTITY_INSERT [dbo].[DaiDoi] OFF
SET IDENTITY_INSERT [dbo].[HocVien] ON 

INSERT [dbo].[HocVien] ([ID], [Ten], [NgaySinh], [GioiTinh], [NoiSinh], [QueQuan], [DiaChi], [NgayVaoDoan], [NgayVaoDang], [NgayNhapNgu], [LopID], [LopTruong], [ChucVu], [CapBac]) VALUES (15, N'Nguyễn Văn A', CAST(N'1995-07-14' AS Date), 1, N'Hà Giang', N'Hà Giang', N'Hà Nội', CAST(N'2018-10-08' AS Date), CAST(N'2018-10-08' AS Date), NULL, 1, 0, N'Học viên', N'H3')
INSERT [dbo].[HocVien] ([ID], [Ten], [NgaySinh], [GioiTinh], [NoiSinh], [QueQuan], [DiaChi], [NgayVaoDoan], [NgayVaoDang], [NgayNhapNgu], [LopID], [LopTruong], [ChucVu], [CapBac]) VALUES (16, N'Test 2', CAST(N'1991-07-16' AS Date), 1, N'KKK', N'Â', N'UUUUU', CAST(N'2016-04-12' AS Date), CAST(N'2018-10-08' AS Date), NULL, 5, 0, N'Học viên', N'H2')
SET IDENTITY_INSERT [dbo].[HocVien] OFF
INSERT [dbo].[HocVien_CongTacDang] ([HocVienID], [CongTacDangID], [Diem]) VALUES (15, 1, 8)
INSERT [dbo].[HocVien_CongTacDang] ([HocVienID], [CongTacDangID], [Diem]) VALUES (15, 2, 7)
INSERT [dbo].[HocVien_CongTacDang] ([HocVienID], [CongTacDangID], [Diem]) VALUES (16, 1, 0)
INSERT [dbo].[HocVien_CongTacDang] ([HocVienID], [CongTacDangID], [Diem]) VALUES (16, 2, 0)
INSERT [dbo].[HocVien_MonHoc] ([HocVienID], [MonHocID], [Diem]) VALUES (15, 1, 7)
INSERT [dbo].[HocVien_MonHoc] ([HocVienID], [MonHocID], [Diem]) VALUES (15, 2, 0)
INSERT [dbo].[HocVien_MonHoc] ([HocVienID], [MonHocID], [Diem]) VALUES (16, 1, 0)
INSERT [dbo].[HocVien_MonHoc] ([HocVienID], [MonHocID], [Diem]) VALUES (16, 2, 0)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (0, 1, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (15, 1, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (15, 2, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (15, 3, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (15, 4, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (16, 1, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (16, 2, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (16, 3, 0, NULL)
INSERT [dbo].[HocVien_TheLuc] ([HocVienID], [MonTheLucID], [KetQua], [NgayKiemTra]) VALUES (16, 4, 0, NULL)
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([ID], [Ten], [DaiDoiID], [SoLuong], [GhiChu]) VALUES (1, N'Lớp 1', 1, NULL, N'cc')
INSERT [dbo].[Lop] ([ID], [Ten], [DaiDoiID], [SoLuong], [GhiChu]) VALUES (2, N'Lớp 2', 2, NULL, N'gg')
INSERT [dbo].[Lop] ([ID], [Ten], [DaiDoiID], [SoLuong], [GhiChu]) VALUES (5, N'Lop 3', 4, NULL, N'a')
SET IDENTITY_INSERT [dbo].[Lop] OFF
INSERT [dbo].[Lop_MonHoc] ([LopID], [MonHocID]) VALUES (1, 1)
INSERT [dbo].[Lop_MonHoc] ([LopID], [MonHocID]) VALUES (1, 2)
INSERT [dbo].[Lop_MonHoc] ([LopID], [MonHocID]) VALUES (5, 1)
INSERT [dbo].[Lop_MonHoc] ([LopID], [MonHocID]) VALUES (5, 2)
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([ID], [Ten], [KyHoc], [SoTin]) VALUES (1, N'Toán 1', 2, 4)
INSERT [dbo].[MonHoc] ([ID], [Ten], [KyHoc], [SoTin]) VALUES (2, N'Triết', 4, 4)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
SET IDENTITY_INSERT [dbo].[MonTheLuc] ON 

INSERT [dbo].[MonTheLuc] ([ID], [Ten], [DonViTinh], [Dat], [Kha], [Gioi]) VALUES (1, N'Bơi', N'm', 50, 75, 100)
INSERT [dbo].[MonTheLuc] ([ID], [Ten], [DonViTinh], [Dat], [Kha], [Gioi]) VALUES (2, N'Chạy 100m', N's', 14, 13.6, 13)
INSERT [dbo].[MonTheLuc] ([ID], [Ten], [DonViTinh], [Dat], [Kha], [Gioi]) VALUES (3, N'Chạy 3000m', N'phút', 12.5, 12, 11.5)
INSERT [dbo].[MonTheLuc] ([ID], [Ten], [DonViTinh], [Dat], [Kha], [Gioi]) VALUES (4, N'Nhảy xa', N'm', 6.9, 7.3, 7.7)
SET IDENTITY_INSERT [dbo].[MonTheLuc] OFF
SET IDENTITY_INSERT [dbo].[TieuDoan] ON 

INSERT [dbo].[TieuDoan] ([ID], [Ten], [GhiChu]) VALUES (1, N'Tiểu đoàn 1', N'abcd')
INSERT [dbo].[TieuDoan] ([ID], [Ten], [GhiChu]) VALUES (2, N'Tiểu đoàn 2', N'aaa')
SET IDENTITY_INSERT [dbo].[TieuDoan] OFF
USE [master]
GO
ALTER DATABASE [QuanLyTieuDoan] SET  READ_WRITE 
GO
