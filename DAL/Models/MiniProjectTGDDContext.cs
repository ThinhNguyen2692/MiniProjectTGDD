using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class MiniProjectTGDDContext : DbContext
    {
        public MiniProjectTGDDContext()
        {
        }

        public MiniProjectTGDDContext(DbContextOptions<MiniProjectTGDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventDetail> EventDetails { get; set; } = null!;
        public virtual DbSet<Gift> Gifts { get; set; } = null!;
        public virtual DbSet<GiftDetail> GiftDetails { get; set; } = null!;
        public virtual DbSet<HearderFooter> HearderFooters { get; set; } = null!;
        public virtual DbSet<InformationProperty> InformationProperties { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductBrand> ProductBrands { get; set; } = null!;
        public virtual DbSet<ProductColor> ProductColors { get; set; } = null!;
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; } = null!;
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<ProductVersion> ProductVersions { get; set; } = null!;
        public virtual DbSet<PropertiesValue> PropertiesValues { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VersionQuantity> VersionQuantities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5DKEKQQ7\\NGUYENTHINH;Database=MiniProjectTGDD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentDescription)
                    .HasColumnName("comment_description")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("customer_name")
                    .HasDefaultValueSql("(N'Ẩn danh')");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_id")
                    .IsFixedLength();

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.UserCity)
                    .HasMaxLength(250)
                    .HasColumnName("user_city")
                    .HasDefaultValueSql("(N'Ẩn')");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_phone")
                    .HasDefaultValueSql("(N'0*********')")
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_fk");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerPhone)
                    .HasName("PK__customer__CE0EE0E774B66467");

                entity.ToTable("customers");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone")
                    .IsFixedLength();

                entity.Property(e => e.CommuneWard)
                    .HasMaxLength(255)
                    .HasColumnName("commune_ward")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name");

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .HasColumnName("district")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.ProvinceCity)
                    .HasMaxLength(255)
                    .HasColumnName("province_city")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.RegistrationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_time")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time")
                    .HasDefaultValueSql("(getdate()+(1))");

                entity.Property(e => e.EventName)
                    .HasMaxLength(255)
                    .HasColumnName("event_name");

                entity.Property(e => e.Promotion).HasColumnName("promotion");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EventDetail>(entity =>
            {
                entity.ToTable("event_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventDetails)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_eventdetail_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.EventDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_eventdetail_fk");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.ToTable("gift");

                entity.Property(e => e.GiftId).HasColumnName("gift_id");

                entity.Property(e => e.GiftProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gift_product")
                    .IsFixedLength();

                entity.Property(e => e.GiftStatus)
                    .HasColumnName("gift_status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_id")
                    .IsFixedLength();

                entity.HasOne(d => d.GiftProductNavigation)
                    .WithMany(p => p.GiftGiftProductNavigations)
                    .HasForeignKey(d => d.GiftProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_gift_gift_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.GiftProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_gift_fk");
            });

            modelBuilder.Entity<GiftDetail>(entity =>
            {
                entity.ToTable("gift_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiftProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gift_product")
                    .IsFixedLength();

                entity.Property(e => e.GiftQuantiy)
                    .HasColumnName("gift_quantiy")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDetail).HasColumnName("order_detail");

                entity.Property(e => e.ProductPhoto)
                    .HasColumnType("text")
                    .HasColumnName("product_photo");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProuctName)
                    .HasMaxLength(255)
                    .HasColumnName("prouct_name");

                entity.HasOne(d => d.OrderDetailNavigation)
                    .WithMany(p => p.GiftDetails)
                    .HasForeignKey(d => d.OrderDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetail_giftdetail_fk");
            });

            modelBuilder.Entity<HearderFooter>(entity =>
            {
                entity.ToTable("hearder_footer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Information)
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.InformationName)
                    .HasMaxLength(255)
                    .HasColumnName("information_name");
            });

            modelBuilder.Entity<InformationProperty>(entity =>
            {
                entity.HasKey(e => e.PropertiesId)
                    .HasName("PK__informat__E0FD831CE6584F4E");

                entity.ToTable("information_properties");

                entity.Property(e => e.PropertiesId).HasColumnName("properties_id");

                entity.Property(e => e.PropertiesDescription)
                    .HasColumnName("properties_description")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.PropertiesName)
                    .HasMaxLength(255)
                    .HasColumnName("properties_name");

                entity.Property(e => e.SpecificationsId).HasColumnName("specifications_id");

                entity.HasOne(d => d.Specifications)
                    .WithMany(p => p.InformationProperties)
                    .HasForeignKey(d => d.SpecificationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specifications_properties_fk");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.Property(e => e.PhotoDescription)
                    .HasColumnName("photo_description")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.PhotoPath)
                    .HasColumnType("text")
                    .HasColumnName("photo_path");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_id")
                    .IsFixedLength();

                entity.Property(e => e.ProductBrand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_brand")
                    .IsFixedLength();

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.ProductPhoto)
                    .HasColumnType("text")
                    .HasColumnName("product_photo");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_type")
                    .IsFixedLength();

                entity.Property(e => e.ProuctName)
                    .HasMaxLength(255)
                    .HasColumnName("prouct_name");

                entity.Property(e => e.ReleaseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("release_time")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductBrandNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_brand_fk");

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_type_fk");
            });

            modelBuilder.Entity<ProductBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__product___5E5A8E278910C8EB");

                entity.ToTable("product_brands");

                entity.Property(e => e.BrandId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand_id")
                    .IsFixedLength();

                entity.Property(e => e.BrandDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("brand_description")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(255)
                    .HasColumnName("brand_name");

                entity.Property(e => e.BrandPhoto)
                    .HasColumnType("text")
                    .HasColumnName("brand_photo");

                entity.Property(e => e.BrandStatus)
                    .HasColumnName("brand_status")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(e => e.ColorId)
                    .HasName("PK__product___1143CECB0BDCA804");

                entity.ToTable("product_color");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ColorDescription)
                    .HasColumnName("color_description")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.ColorPath)
                    .HasColumnType("text")
                    .HasColumnName("color_path");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_color_fk");
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.ToTable("product_photos");

                entity.Property(e => e.ProductPhotoId).HasColumnName("product_photo_id");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.Property(e => e.VersionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("version_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.ProductPhotos)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("photo_product_photos_fk");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.ProductPhotos)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("version_photos_fk");
            });

            modelBuilder.Entity<ProductSpecification>(entity =>
            {
                entity.HasKey(e => e.SpecificationsId)
                    .HasName("PK__product___C095C1DE44558099");

                entity.ToTable("product_specifications");

                entity.Property(e => e.SpecificationsId).HasColumnName("specifications_id");

                entity.Property(e => e.SpecificationsDescription)
                    .HasColumnName("specifications_description")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.SpecificationsName)
                    .HasMaxLength(255)
                    .HasColumnName("specifications_name");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ProductSpecifications)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("type_specifications_fk");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.Typeid)
                    .HasName("PK__product___F0528D02FFC4BADE");

                entity.ToTable("product_types");

                entity.Property(e => e.Typeid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeid")
                    .IsFixedLength();

                entity.Property(e => e.Typename)
                    .HasMaxLength(255)
                    .HasColumnName("typename");
            });

            modelBuilder.Entity<ProductVersion>(entity =>
            {
                entity.HasKey(e => e.VersionId)
                    .HasName("PK__product___07A5886919556EC0");

                entity.ToTable("product_version");

                entity.Property(e => e.VersionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("version_id")
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_id")
                    .IsFixedLength();

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("product_price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductStatus)
                    .HasColumnName("product_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionName)
                    .HasMaxLength(255)
                    .HasColumnName("version_name");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVersions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_version_fk");
            });

            modelBuilder.Entity<PropertiesValue>(entity =>
            {
                entity.HasKey(e => e.ValueId)
                    .HasName("PK__properti__0FECE2825ED8756B");

                entity.ToTable("properties_value");

                entity.Property(e => e.ValueId).HasColumnName("value_id");

                entity.Property(e => e.PropertiesId).HasColumnName("properties_id");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasDefaultValueSql("(N'Đang cập nhập')");

                entity.Property(e => e.VersionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("version_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Properties)
                    .WithMany(p => p.PropertiesValues)
                    .HasForeignKey(d => d.PropertiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("properties_value2_fk");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.PropertiesValues)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("properties_value_fk");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__purchase__46596229963E6AF7");

                entity.ToTable("purchase_order");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("order_id")
                    .IsFixedLength();

                entity.Property(e => e.BillingInformation)
                    .HasColumnType("text")
                    .HasColumnName("billing_information");

                entity.Property(e => e.CommuneWard)
                    .HasMaxLength(255)
                    .HasColumnName("commune_ward");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone")
                    .IsFixedLength();

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .HasColumnName("district");

                entity.Property(e => e.IntoMoney).HasColumnName("into_money");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProvinceCity)
                    .HasMaxLength(255)
                    .HasColumnName("province_city");

                entity.Property(e => e.SetupTime)
                    .HasColumnType("datetime")
                    .HasColumnName("setup_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalMoney).HasColumnName("total_money");

                entity.Property(e => e.TotalPromotionalPrice).HasColumnName("total_promotional_price");

                entity.HasOne(d => d.CustomerPhoneNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.CustomerPhone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_order_fk");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetail)
                    .HasName("PK__purchase__3850B0139588FCF5");

                entity.ToTable("purchase_order_detail");

                entity.Property(e => e.OrderDetail).HasColumnName("order_detail");

                entity.Property(e => e.EventName).HasColumnName("event_name");

                entity.Property(e => e.MoneyProduct).HasColumnName("money_product");

                entity.Property(e => e.MoneyReduced).HasColumnName("money_reduced");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("order_id")
                    .IsFixedLength();

                entity.Property(e => e.OrderPrice).HasColumnName("order_price");

                entity.Property(e => e.OrderProduct)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("order_product")
                    .IsFixedLength();

                entity.Property(e => e.OrderProductPhoto)
                    .HasColumnType("text")
                    .HasColumnName("order_product_photo");

                entity.Property(e => e.OrderPromotion).HasColumnName("order_promotion");

                entity.Property(e => e.OrderProudctName)
                    .HasMaxLength(255)
                    .HasColumnName("order_proudct_name");

                entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetail_order_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_phone")
                    .IsFixedLength();

                entity.Property(e => e.UserPhoto)
                    .HasColumnType("text")
                    .HasColumnName("user_photo");
            });

            modelBuilder.Entity<VersionQuantity>(entity =>
            {
                entity.ToTable("version_quantity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("version_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.VersionQuantities)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("version_quantity2_fk");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.VersionQuantities)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("version_quantity_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
