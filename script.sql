USE [master]
GO
/****** Object:  Database [MiniProjectTGDD]    Script Date: 22/11/2022 02:10:24 ******/
CREATE DATABASE [MiniProjectTGDD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MiniProjectTGDD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NGUYENTHINH\MSSQL\DATA\MiniProjectTGDD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiniProjectTGDD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NGUYENTHINH\MSSQL\DATA\MiniProjectTGDD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MiniProjectTGDD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiniProjectTGDD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiniProjectTGDD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiniProjectTGDD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiniProjectTGDD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MiniProjectTGDD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiniProjectTGDD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET RECOVERY FULL 
GO
ALTER DATABASE [MiniProjectTGDD] SET  MULTI_USER 
GO
ALTER DATABASE [MiniProjectTGDD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiniProjectTGDD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MiniProjectTGDD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MiniProjectTGDD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MiniProjectTGDD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MiniProjectTGDD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MiniProjectTGDD', N'ON'
GO
ALTER DATABASE [MiniProjectTGDD] SET QUERY_STORE = OFF
GO
USE [MiniProjectTGDD]
GO
/****** Object:  Table [dbo].[comments]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[comment_description] [nvarchar](max) NULL,
	[rating] [int] NULL,
	[customer_name] [nvarchar](200) NULL,
	[user_phone] [char](10) NULL,
	[user_city] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[customer_phone] [char](10) NOT NULL,
	[customer_name] [nvarchar](255) NOT NULL,
	[province_city] [nvarchar](255) NULL,
	[district] [nvarchar](255) NULL,
	[commune_ward] [nvarchar](255) NULL,
	[customer_address] [nvarchar](255) NULL,
	[registration_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[event_detail]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[event_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[event_id] [int] NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[events]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[events](
	[event_id] [int] IDENTITY(1,1) NOT NULL,
	[event_name] [nvarchar](255) NOT NULL,
	[promotion] [int] NOT NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[event_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gift]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gift](
	[gift_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[gift_product] [nvarchar](50) NOT NULL,
	[gift_status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[gift_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gift_detail]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gift_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_detail] [int] NOT NULL,
	[gift_product] [nvarchar](50) NULL,
	[prouct_name] [nvarchar](255) NOT NULL,
	[product_price] [int] NOT NULL,
	[product_photo] [text] NOT NULL,
	[gift_quantiy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hearder_footer]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hearder_footer](
	[id] [int] NOT NULL,
	[information_name] [nvarchar](255) NOT NULL,
	[information] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[information_properties]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[information_properties](
	[properties_id] [int] IDENTITY(1,1) NOT NULL,
	[specifications_id] [int] NOT NULL,
	[properties_name] [nvarchar](255) NOT NULL,
	[properties_description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[properties_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_brands]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_brands](
	[brand_id] [nvarchar](50) NOT NULL,
	[brand_name] [nvarchar](255) NOT NULL,
	[brand_photo] [text] NOT NULL,
	[brand_description] [nvarchar](4000) NULL,
	[brand_status] [int] NULL,
 CONSTRAINT [PK__product___5E5A8E278910C8EB] PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_color]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_color](
	[color_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[color_path] [text] NOT NULL,
	[color_description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[color_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_photos]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_photos](
	[product_photo_id] [int] IDENTITY(1,1) NOT NULL,
	[version_id] [nvarchar](50) NOT NULL,
	[photo_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_photo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_specifications]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_specifications](
	[specifications_id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [nvarchar](50) NOT NULL,
	[specifications_name] [nvarchar](255) NOT NULL,
	[specifications_description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[specifications_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_types]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_types](
	[typeid] [nvarchar](50) NOT NULL,
	[typename] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__product___F0528D02FFC4BADE] PRIMARY KEY CLUSTERED 
(
	[typeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_version]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_version](
	[version_id] [nvarchar](50) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[version_name] [nvarchar](255) NOT NULL,
	[product_price] [int] NULL,
	[product_status] [int] NULL,
 CONSTRAINT [PK__product___07A5886919556EC0] PRIMARY KEY CLUSTERED 
(
	[version_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[product_id] [nvarchar](50) NOT NULL,
	[prouct_name] [nvarchar](255) NOT NULL,
	[product_type] [nvarchar](50) NULL,
	[product_brand] [nvarchar](50) NOT NULL,
	[product_photo] [text] NOT NULL,
	[product_description] [nvarchar](max) NULL,
	[release_time] [datetime] NULL,
 CONSTRAINT [PK__products__47027DF5393A4E2D] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[properties_value]    Script Date: 22/11/2022 02:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[properties_value](
	[value_id] [int] IDENTITY(1,1) NOT NULL,
	[version_id] [nvarchar](50) NOT NULL,
	[properties_id] [int] NOT NULL,
	[value] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[value_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchase_order]    Script Date: 22/11/2022 02:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase_order](
	[order_id] [char](10) NOT NULL,
	[customer_phone] [char](10) NOT NULL,
	[setup_time] [datetime] NULL,
	[total_money] [int] NOT NULL,
	[total_promotional_price] [int] NOT NULL,
	[into_money] [int] NOT NULL,
	[province_city] [nvarchar](255) NOT NULL,
	[district] [nvarchar](255) NOT NULL,
	[commune_ward] [nvarchar](255) NOT NULL,
	[customer_address] [nvarchar](255) NOT NULL,
	[billing_information] [text] NOT NULL,
	[order_status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchase_order_detail]    Script Date: 22/11/2022 02:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase_order_detail](
	[order_detail] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [char](10) NOT NULL,
	[order_product] [nvarchar](50) NULL,
	[order_proudct_name] [nvarchar](255) NOT NULL,
	[order_product_photo] [text] NOT NULL,
	[order_price] [int] NOT NULL,
	[order_promotion] [int] NOT NULL,
	[event_name] [nvarchar](255) NULL,
	[order_quantity] [int] NOT NULL,
	[money_reduced] [int] NOT NULL,
	[total] [int] NOT NULL,
	[money_product] [int] NOT NULL,
	[colorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[photos]    Script Date: 22/11/2022 02:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[photos](
	[photo_id] [int] IDENTITY(1,1) NOT NULL,
	[photo_path] [text] NOT NULL,
	[photo_description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[photo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 22/11/2022 02:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1000,1) NOT NULL,
	[user_name] [nvarchar](255) NOT NULL,
	[user_phone] [char](10) NOT NULL,
	[user_photo] [text] NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[role_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[version_quantity]    Script Date: 22/11/2022 02:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_quantity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[version_id] [nvarchar](50) NOT NULL,
	[color_id] [int] NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comments] ADD  DEFAULT (N'') FOR [comment_description]
GO
ALTER TABLE [dbo].[comments] ADD  DEFAULT ((5)) FOR [rating]
GO
ALTER TABLE [dbo].[comments] ADD  DEFAULT (N'Ẩn danh') FOR [customer_name]
GO
ALTER TABLE [dbo].[comments] ADD  DEFAULT (N'0*********') FOR [user_phone]
GO
ALTER TABLE [dbo].[comments] ADD  DEFAULT (N'Ẩn') FOR [user_city]
GO
ALTER TABLE [dbo].[customers] ADD  DEFAULT (N'') FOR [province_city]
GO
ALTER TABLE [dbo].[customers] ADD  DEFAULT (N'') FOR [district]
GO
ALTER TABLE [dbo].[customers] ADD  DEFAULT (N'') FOR [commune_ward]
GO
ALTER TABLE [dbo].[customers] ADD  DEFAULT (N'') FOR [customer_address]
GO
ALTER TABLE [dbo].[customers] ADD  DEFAULT (getdate()) FOR [registration_time]
GO
ALTER TABLE [dbo].[events] ADD  DEFAULT (getdate()) FOR [start_time]
GO
ALTER TABLE [dbo].[events] ADD  DEFAULT (getdate()+(1)) FOR [end_time]
GO
ALTER TABLE [dbo].[gift] ADD  DEFAULT ((1)) FOR [gift_status]
GO
ALTER TABLE [dbo].[gift_detail] ADD  DEFAULT ((1)) FOR [gift_quantiy]
GO
ALTER TABLE [dbo].[information_properties] ADD  DEFAULT (N'Đang cập nhập') FOR [properties_description]
GO
ALTER TABLE [dbo].[product_brands] ADD  DEFAULT (N'Đang cập nhập') FOR [brand_description]
GO
ALTER TABLE [dbo].[product_brands] ADD  DEFAULT ((0)) FOR [brand_status]
GO
ALTER TABLE [dbo].[product_color] ADD  DEFAULT (N'Đang cập nhập') FOR [color_description]
GO
ALTER TABLE [dbo].[product_specifications] ADD  DEFAULT (N'Đang cập nhập') FOR [specifications_description]
GO
ALTER TABLE [dbo].[product_version] ADD  DEFAULT ((0)) FOR [product_price]
GO
ALTER TABLE [dbo].[product_version] ADD  DEFAULT ((0)) FOR [product_status]
GO
ALTER TABLE [dbo].[products] ADD  DEFAULT (N'Đang cập nhập') FOR [product_description]
GO
ALTER TABLE [dbo].[products] ADD  DEFAULT (getdate()) FOR [release_time]
GO
ALTER TABLE [dbo].[properties_value] ADD  DEFAULT (N'Đang cập nhập') FOR [value]
GO
ALTER TABLE [dbo].[purchase_order] ADD  DEFAULT (getdate()) FOR [setup_time]
GO
ALTER TABLE [dbo].[purchase_order] ADD  DEFAULT ((0)) FOR [order_status]
GO
ALTER TABLE [dbo].[photos] ADD  DEFAULT (N'Đang cập nhập') FOR [photo_description]
GO
ALTER TABLE [dbo].[version_quantity] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [comments_fk] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [comments_fk]
GO
ALTER TABLE [dbo].[event_detail]  WITH CHECK ADD  CONSTRAINT [event_eventdetail_fk] FOREIGN KEY([event_id])
REFERENCES [dbo].[events] ([event_id])
GO
ALTER TABLE [dbo].[event_detail] CHECK CONSTRAINT [event_eventdetail_fk]
GO
ALTER TABLE [dbo].[event_detail]  WITH CHECK ADD  CONSTRAINT [product_eventdetail_fk] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
GO
ALTER TABLE [dbo].[event_detail] CHECK CONSTRAINT [product_eventdetail_fk]
GO
ALTER TABLE [dbo].[gift]  WITH CHECK ADD  CONSTRAINT [product_gift_fk] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
GO
ALTER TABLE [dbo].[gift] CHECK CONSTRAINT [product_gift_fk]
GO
ALTER TABLE [dbo].[gift]  WITH CHECK ADD  CONSTRAINT [productVerion_gift_fk] FOREIGN KEY([gift_product])
REFERENCES [dbo].[product_version] ([version_id])
GO
ALTER TABLE [dbo].[gift] CHECK CONSTRAINT [productVerion_gift_fk]
GO
ALTER TABLE [dbo].[gift_detail]  WITH CHECK ADD  CONSTRAINT [orderdetail_giftdetail_fk] FOREIGN KEY([order_detail])
REFERENCES [dbo].[purchase_order_detail] ([order_detail])
GO
ALTER TABLE [dbo].[gift_detail] CHECK CONSTRAINT [orderdetail_giftdetail_fk]
GO
ALTER TABLE [dbo].[information_properties]  WITH CHECK ADD  CONSTRAINT [specifications_properties_fk] FOREIGN KEY([specifications_id])
REFERENCES [dbo].[product_specifications] ([specifications_id])
GO
ALTER TABLE [dbo].[information_properties] CHECK CONSTRAINT [specifications_properties_fk]
GO
ALTER TABLE [dbo].[product_color]  WITH CHECK ADD  CONSTRAINT [product_color_fk] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
GO
ALTER TABLE [dbo].[product_color] CHECK CONSTRAINT [product_color_fk]
GO
ALTER TABLE [dbo].[product_photos]  WITH CHECK ADD  CONSTRAINT [photo_product_photos_fk] FOREIGN KEY([photo_id])
REFERENCES [dbo].[photos] ([photo_id])
GO
ALTER TABLE [dbo].[product_photos] CHECK CONSTRAINT [photo_product_photos_fk]
GO
ALTER TABLE [dbo].[product_photos]  WITH CHECK ADD  CONSTRAINT [version_photos_fk] FOREIGN KEY([version_id])
REFERENCES [dbo].[product_version] ([version_id])
GO
ALTER TABLE [dbo].[product_photos] CHECK CONSTRAINT [version_photos_fk]
GO
ALTER TABLE [dbo].[product_specifications]  WITH CHECK ADD  CONSTRAINT [type_specifications_fk] FOREIGN KEY([type_id])
REFERENCES [dbo].[product_types] ([typeid])
GO
ALTER TABLE [dbo].[product_specifications] CHECK CONSTRAINT [type_specifications_fk]
GO
ALTER TABLE [dbo].[product_version]  WITH CHECK ADD  CONSTRAINT [product_version_fk] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
GO
ALTER TABLE [dbo].[product_version] CHECK CONSTRAINT [product_version_fk]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [product_brand_fk] FOREIGN KEY([product_brand])
REFERENCES [dbo].[product_brands] ([brand_id])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [product_brand_fk]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [product_type_fk] FOREIGN KEY([product_type])
REFERENCES [dbo].[product_types] ([typeid])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [product_type_fk]
GO
ALTER TABLE [dbo].[properties_value]  WITH CHECK ADD  CONSTRAINT [properties_value_fk] FOREIGN KEY([version_id])
REFERENCES [dbo].[product_version] ([version_id])
GO
ALTER TABLE [dbo].[properties_value] CHECK CONSTRAINT [properties_value_fk]
GO
ALTER TABLE [dbo].[properties_value]  WITH CHECK ADD  CONSTRAINT [properties_value2_fk] FOREIGN KEY([properties_id])
REFERENCES [dbo].[information_properties] ([properties_id])
GO
ALTER TABLE [dbo].[properties_value] CHECK CONSTRAINT [properties_value2_fk]
GO
ALTER TABLE [dbo].[purchase_order]  WITH CHECK ADD  CONSTRAINT [customer_order_fk] FOREIGN KEY([customer_phone])
REFERENCES [dbo].[customers] ([customer_phone])
GO
ALTER TABLE [dbo].[purchase_order] CHECK CONSTRAINT [customer_order_fk]
GO
ALTER TABLE [dbo].[purchase_order_detail]  WITH CHECK ADD  CONSTRAINT [orderdetail_order_fk] FOREIGN KEY([order_id])
REFERENCES [dbo].[purchase_order] ([order_id])
GO
ALTER TABLE [dbo].[purchase_order_detail] CHECK CONSTRAINT [orderdetail_order_fk]
GO
ALTER TABLE [dbo].[version_quantity]  WITH CHECK ADD  CONSTRAINT [version_quantity_fk] FOREIGN KEY([version_id])
REFERENCES [dbo].[product_version] ([version_id])
GO
ALTER TABLE [dbo].[version_quantity] CHECK CONSTRAINT [version_quantity_fk]
GO
ALTER TABLE [dbo].[version_quantity]  WITH CHECK ADD  CONSTRAINT [version_quantity2_fk] FOREIGN KEY([color_id])
REFERENCES [dbo].[product_color] ([color_id])
GO
ALTER TABLE [dbo].[version_quantity] CHECK CONSTRAINT [version_quantity2_fk]
GO
USE [master]
GO
ALTER DATABASE [MiniProjectTGDD] SET  READ_WRITE 
GO
