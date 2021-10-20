USE [master]
GO
/****** Object:  Database [ShopRuou] ******/
CREATE DATABASE [ShopRuou]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopRuou', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopRuou.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopRuou_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopRuou_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopRuou] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopRuou].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopRuou] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopRuou] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopRuou] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopRuou] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopRuou] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopRuou] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopRuou] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopRuou] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopRuou] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopRuou] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopRuou] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopRuou] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopRuou] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopRuou] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopRuou] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopRuou] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopRuou] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopRuou] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopRuou] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopRuou] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopRuou] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopRuou] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopRuou] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopRuou] SET  MULTI_USER 
GO
ALTER DATABASE [ShopRuou] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopRuou] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopRuou] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopRuou] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopRuou] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopRuou] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopRuou] SET QUERY_STORE = OFF
GO
USE [ShopRuou]
GO
/****** Object:  Table [dbo].[DatHang]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan_ID] [int] NULL,
	[KhachHang_ID] [int] NULL,
	[DienThoaiGiaoHang] [nvarchar](255) NULL,
	[DiaChiGiaoHang] [nvarchar](255) NULL,
	[NgayDatHang] [datetime] NULL,
	[TinhTrang] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatHang_ChiTiet]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang_ChiTiet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DatHang_ID] [int] NULL,
	[SanPham_ID] [int] NULL,
	[SoLuong] [smallint] NULL,
	[DonGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hang]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenHang] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](255) NOT NULL,
	[SoDienThoai] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[TenDangNhap] [nvarchar](255) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoiSanXuat]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoiSanXuat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[XuatXu] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Loai_ID] [int] NULL,
	[Hang_ID] [int] NULL,
	[NoiSanXuat_ID] [int] NULL,
	[TenSanPham] [nvarchar](255) NULL,
	[NgayNhap] [datetime] NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,	
	[MoTa] [nvarchar](255) NULL,
	[HinhAnhBia] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/8/2021 2:31:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChucVu] [int] NOT NULL,
	[HoTen] [nvarchar](255) NOT NULL,
	[TenDangNhap] [nvarchar](255) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[SoDienThoai] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DatHang] ON 

INSERT [dbo].[DatHang] ([ID], [TaiKhoan_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (1, NULL, 1, N'0944444444', N'Long Xuyên', CAST(N'2021-06-06T23:00:38.363' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [TaiKhoan_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (2, NULL, 1, N'0944444444', N'Long Xuyên', CAST(N'2021-06-06T23:43:56.877' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [TaiKhoan_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (3, NULL, 1, N'0944444444', N'Long Xuyên', CAST(N'2021-06-08T12:59:07.540' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [TaiKhoan_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (4, NULL, 4, N'0944444444', N'Long Xuyên', CAST(N'2021-06-08T13:53:26.170' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [TaiKhoan_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (5, NULL, 1, N'0944444444', N'Long Xuyên', CAST(N'2021-06-08T14:03:52.280' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[DatHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DatHang_ChiTiet] ON 

INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [SanPham_ID], [SoLuong], [DonGia]) VALUES (1, 1, 1, 1, 16000000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [SanPham_ID], [SoLuong], [DonGia]) VALUES (4, 4, 2, 1, 12000000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [SanPham_ID], [SoLuong], [DonGia]) VALUES (5, 5, 3, 3, 18000000)
SET IDENTITY_INSERT [dbo].[DatHang_ChiTiet] OFF
GO
SET IDENTITY_INSERT [dbo].[Hang] ON 

INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (1, N'Iphone')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (2, N'Oppo')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (3, N'Xiaomi')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (4, N'Bphone')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (5, N'SamSung')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (6, N'Huawei')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (7, N'Vivo')
SET IDENTITY_INSERT [dbo].[Hang] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [HoTen], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (1, N'Trần quốc đạt', N'0373856186', N'Long Xuyên', N'user', N'356a192b7913b04c54574d18c28d46e6395428ab')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (4, N'Trương quốc duy', N'0373856186', N'Long Xuyên', N'user1', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (5, N'Nguyễn Hoàng Long', N'0373856186', N'Long Xuyên', N'user2', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([ID], [TenLoai]) VALUES (1, N'Cảm ứng')
INSERT [dbo].[Loai] ([ID], [TenLoai]) VALUES (2, N'Phím Thường')
SET IDENTITY_INSERT [dbo].[Loai] OFF
GO
SET IDENTITY_INSERT [dbo].[NoiSanXuat] ON 

INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (1, N'Mỹ')
INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (2, N'Hàn Quốc')
INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (3, N'Việt Nam')
INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (4, N'Trung Quốc')
SET IDENTITY_INSERT [dbo].[NoiSanXuat] OFF
GO

SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [DiaChi]) VALUES (1, 1, N'Trần quốc đạt', N'admin', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0373856186', N'Long Xuyên')
INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [DiaChi]) VALUES (2, 1, N'Trương quốc duy', N'duy', N'8cb2237d0679ca88db6464eac60da96345513964', N'0373856186', N'Long Xuyên')
INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [DiaChi]) VALUES (3, 0, N'Nguyễn Hoàng Long', N'staff', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0373856186', N'Long Xuyên')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[DatHang]  WITH CHECK ADD FOREIGN KEY([KhachHang_ID])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[DatHang]  WITH CHECK ADD FOREIGN KEY([TaiKhoan_ID])
REFERENCES [dbo].[TaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[DatHang_ChiTiet]  WITH CHECK ADD FOREIGN KEY([DatHang_ID])
REFERENCES [dbo].[DatHang] ([ID])
GO
ALTER TABLE [dbo].[DatHang_ChiTiet]  WITH CHECK ADD FOREIGN KEY([SanPham_ID])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([Hang_ID])
REFERENCES [dbo].[Hang] ([id])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([Loai_ID])
REFERENCES [dbo].[Loai] ([ID])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([NoiSanXuat_ID])
REFERENCES [dbo].[NoiSanXuat] ([id])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [CHK_POSITION] CHECK  (([ChucVu]=(1) OR [ChucVu]=(0)))
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [CHK_POSITION]
GO
USE [master]
GO
ALTER DATABASE [ShopRuou] SET  READ_WRITE 
GO
