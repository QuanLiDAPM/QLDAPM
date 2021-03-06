USE [master]
GO
/****** Object:  Database [LiquorStores]    Script Date: 12/4/2021 10:49:09 AM ******/
CREATE DATABASE [LiquorStores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LiquorStores', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LiquorStores.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LiquorStores_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LiquorStores_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LiquorStores] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LiquorStores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LiquorStores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LiquorStores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LiquorStores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LiquorStores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LiquorStores] SET ARITHABORT OFF 
GO
ALTER DATABASE [LiquorStores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LiquorStores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LiquorStores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LiquorStores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LiquorStores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LiquorStores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LiquorStores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LiquorStores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LiquorStores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LiquorStores] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LiquorStores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LiquorStores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LiquorStores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LiquorStores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LiquorStores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LiquorStores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LiquorStores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LiquorStores] SET RECOVERY FULL 
GO
ALTER DATABASE [LiquorStores] SET  MULTI_USER 
GO
ALTER DATABASE [LiquorStores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LiquorStores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LiquorStores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LiquorStores] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LiquorStores] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LiquorStores] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LiquorStores', N'ON'
GO
ALTER DATABASE [LiquorStores] SET QUERY_STORE = OFF
GO
USE [LiquorStores]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/4/2021 10:49:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatHang]    Script Date: 12/4/2021 10:49:10 AM ******/
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
/****** Object:  Table [dbo].[DatHang_ChiTiet]    Script Date: 12/4/2021 10:49:10 AM ******/
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
/****** Object:  Table [dbo].[Hang]    Script Date: 12/4/2021 10:49:10 AM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/4/2021 10:49:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](255) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SoDienThoai] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[TenDangNhap] [nvarchar](255) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[Mail] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 12/4/2021 10:49:10 AM ******/
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
/****** Object:  Table [dbo].[NoiSanXuat]    Script Date: 12/4/2021 10:49:10 AM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 12/4/2021 10:49:10 AM ******/
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
	[NongDoCon] [text] NULL,
	[TheTich] [text] NULL,
	[NgayNhap] [datetime] NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,
	[MoTa] [nvarchar](255) NULL,
	[HinhAnhBia] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/4/2021 10:49:10 AM ******/
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
	[HinhAnhBia] [nvarchar](255) NULL,
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
SET IDENTITY_INSERT [dbo].[Hang] ON 

INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (1, N'Wishkey Scotland')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (2, N'Chateau')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (3, N'Cognac')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (4, N'Gin')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (5, N'Sake')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (6, N'Sherry')
INSERT [dbo].[Hang] ([id], [TenHang]) VALUES (7, N'Gò Công')
SET IDENTITY_INSERT [dbo].[Hang] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (1, N'Trần Quốc Đạt', CAST(N'2021-06-06' AS Date), N'0373856186', N'Long Xuyên', N'user', N'356a192b7913b04c54574d18c28d46e6395428ab', N'a@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (4, N'Trương Quốc Duy', CAST(N'2021-06-06' AS Date), N'0373856186', N'Long Xuyên', N'user1', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220', N'a@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (5, N'Nguyễn Hoàng Long', CAST(N'2021-06-06' AS Date), N'0373856186', N'Long Xuyên', N'user2', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220', N'a@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (1006, N'Trương Quốc Duy', CAST(N'0001-01-01' AS Date), N'0796645799', N'Long Xiên', N'Duy3', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220', N'a@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (1007, N'Trương Quốc Duy 2', CAST(N'0001-01-01' AS Date), N'0796645799', N'Long Xiên', N'user4', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'b@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (1008, N'Trương Quốc Duy', CAST(N'2000-07-25' AS Date), N'0796645799', N'Long Xiên', N'user6', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220', N'c@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [HoTen], [NgaySinh], [SoDienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Mail]) VALUES (1009, N'Trương Quốc Duy', CAST(N'2000-07-25' AS Date), N'0796645799', N'Long Xiên', N'user7', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'd@gmail.com')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([ID], [TenLoai]) VALUES (1, N'Rượu vang')
INSERT [dbo].[Loai] ([ID], [TenLoai]) VALUES (2, N'Wishke')
INSERT [dbo].[Loai] ([ID], [TenLoai]) VALUES (3, N'Rượu nhẹ')
SET IDENTITY_INSERT [dbo].[Loai] OFF
GO
SET IDENTITY_INSERT [dbo].[NoiSanXuat] ON 

INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (1, N'Mỹ')
INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (2, N'Hàn Quốc')
INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (3, N'Việt Nam')
INSERT [dbo].[NoiSanXuat] ([id], [XuatXu]) VALUES (4, N'Trung Quốc')
SET IDENTITY_INSERT [dbo].[NoiSanXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([ID], [Loai_ID], [Hang_ID], [NoiSanXuat_ID], [TenSanPham], [NongDoCon], [TheTich], [NgayNhap], [DonGia], [SoLuong], [MoTa], [HinhAnhBia]) VALUES (2, 1, 2, 1, N'WHISHKEY Kangoru1', N'35%', N'2L', CAST(N'2021-11-20T16:03:00.000' AS DateTime), 3000000, 21, N'Thơm ngon', N'Images\prod-2.jpg')
INSERT [dbo].[SanPham] ([ID], [Loai_ID], [Hang_ID], [NoiSanXuat_ID], [TenSanPham], [NongDoCon], [TheTich], [NgayNhap], [DonGia], [SoLuong], [MoTa], [HinhAnhBia]) VALUES (3, 1, 1, 1, N'WHISHKEY Kangoru2', N'35%', N'2L', CAST(N'2021-11-21T16:13:00.000' AS DateTime), 1000000, 3, N'Thơm ngon', N'Images\prod-3.jpg')
INSERT [dbo].[SanPham] ([ID], [Loai_ID], [Hang_ID], [NoiSanXuat_ID], [TenSanPham], [NongDoCon], [TheTich], [NgayNhap], [DonGia], [SoLuong], [MoTa], [HinhAnhBia]) VALUES (4, 1, 3, 1, N'WHISHKEY Kangoru4', N'45%', N'2.5L', CAST(N'2021-11-28T16:40:00.000' AS DateTime), 1000000, 12, N'Thơm ngon', N'Images\prod-4.jpg')
INSERT [dbo].[SanPham] ([ID], [Loai_ID], [Hang_ID], [NoiSanXuat_ID], [TenSanPham], [NongDoCon], [TheTich], [NgayNhap], [DonGia], [SoLuong], [MoTa], [HinhAnhBia]) VALUES (6, 1, 6, 1, N'WHISHKEY Kangoru6', N'35%', N'2.5L', CAST(N'2021-11-21T16:42:00.000' AS DateTime), 1200000, 13, N'Thơm ngon', N'Images\prod-9.jpg')
INSERT [dbo].[SanPham] ([ID], [Loai_ID], [Hang_ID], [NoiSanXuat_ID], [TenSanPham], [NongDoCon], [TheTich], [NgayNhap], [DonGia], [SoLuong], [MoTa], [HinhAnhBia]) VALUES (7, 3, 5, 1, N'WHISHKEY Kangoru7', N'15%', N'2L', CAST(N'2021-11-21T16:43:00.000' AS DateTime), 1400000, 12, N'Thơm ngon', N'Images\prod-7.jpg')
INSERT [dbo].[SanPham] ([ID], [Loai_ID], [Hang_ID], [NoiSanXuat_ID], [TenSanPham], [NongDoCon], [TheTich], [NgayNhap], [DonGia], [SoLuong], [MoTa], [HinhAnhBia]) VALUES (8, 1, NULL, 1, N'WHISHKEY Kangoru7', N'55%', N'2L', CAST(N'2021-11-25T23:49:00.000' AS DateTime), 2000000, 12, N'Thơm ngon', N'Images\prod-8.jpg')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [HinhAnhBia]) VALUES (1, 1, N'Trần Quốc Đạt', N'admin', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0373856186', N'Images\e462a500-c2b7-4fbc-9c3a-e0b1d3f59d45_est2021.png')
INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [HinhAnhBia]) VALUES (2, 1, N'Trương Quốc Duy', N'admin3', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0373856186', N'Images\e462a500-c2b7-4fbc-9c3a-e0b1d3f59d45_est2021.png')
INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [HinhAnhBia]) VALUES (3, 0, N'Nguyễn Hoàng Long', N'staff', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0373856186', N'Images\e462a500-c2b7-4fbc-9c3a-e0b1d3f59d45_est2021.png')
INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [HinhAnhBia]) VALUES (1004, 0, N'Trương Quốc Duy', N'staff1', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0796645799', N'Images\e462a500-c2b7-4fbc-9c3a-e0b1d3f59d45_est2021.png')
INSERT [dbo].[TaiKhoan] ([ID], [ChucVu], [HoTen], [TenDangNhap], [MatKhau], [SoDienThoai], [HinhAnhBia]) VALUES (1005, 0, N'Trương Quốc Duy 1', N'staff2', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'0796645799', N'Images\bd60ec74-4ed2-4f8d-ba55-d8adde2c5e4b_background-3-1.jpg')
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
ALTER DATABASE [LiquorStores] SET  READ_WRITE 
GO
