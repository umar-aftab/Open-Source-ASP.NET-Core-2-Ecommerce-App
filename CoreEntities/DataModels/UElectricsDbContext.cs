using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreEntities
{
    public partial class UElectricsDbContext : DbContext
    {
        public UElectricsDbContext()
        {
        }

        public UElectricsDbContext(DbContextOptions<UElectricsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAccesLevel> AdminAccesLevel { get; set; }
        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<BillingInfo> BillingInfo { get; set; }
        public virtual DbSet<DropOffFacility> DropOffFacility { get; set; }
        public virtual DbSet<FacilityEmployee> FacilityEmployee { get; set; }
        public virtual DbSet<FacilityItem> FacilityItem { get; set; }
        public virtual DbSet<FlaggedOrder> FlaggedOrder { get; set; }
        public virtual DbSet<FlaggedProduct> FlaggedProduct { get; set; }
        public virtual DbSet<FlaggedReview> FlaggedReview { get; set; }
        public virtual DbSet<FlaggedUser> FlaggedUser { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }
        public virtual DbSet<WebsiteUser> WebsiteUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=UMARABUHAFS;Initial Catalog=UElectrics;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAccesLevel>(entity =>
            {
                entity.Property(e => e.AdminAccesLevelId).ValueGeneratedNever();

                entity.Property(e => e.AccessLevel)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.Property(e => e.AdminUserId).ValueGeneratedNever();

                entity.Property(e => e.AccessLevelId).HasColumnName("AccessLevelID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(1026);

                entity.HasOne(d => d.AccessLevel)
                    .WithMany(p => p.AdminUser)
                    .HasForeignKey(d => d.AccessLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUser_to_AdminAccessLevel");
            });

            modelBuilder.Entity<BillingInfo>(entity =>
            {
                entity.Property(e => e.BillingInfoId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1026);

                entity.Property(e => e.PayPalEmail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PostalCode).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.HasOne(d => d.WebsiteUser)
                    .WithMany(p => p.BillingInfo)
                    .HasForeignKey(d => d.WebsiteUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillingInfo_to_WebsiteUser");
            });

            modelBuilder.Entity<DropOffFacility>(entity =>
            {
                entity.HasKey(e => e.FacilityId);

                entity.Property(e => e.FacilityId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Hours).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Street).HasMaxLength(50);
            });

            modelBuilder.Entity<FacilityEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PostalCode).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityEmployee)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_FacilityEmployee_to_Facility");
            });

            modelBuilder.Entity<FacilityItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.FacilityItemBuyer)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityItem_to_Buyer");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityItem)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_FacilityItem_to_Facility");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FacilityItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_FacilityItem_to_Order");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.FacilityItemSeller)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityItem_to_Seller");
            });

            modelBuilder.Entity<FlaggedOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.AdminUserId });

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.FlaggedOrder)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedOrder_to_AdminUser");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FlaggedOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedOrder_to_Order");
            });

            modelBuilder.Entity<FlaggedProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.AdminUserId });

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.FlaggedProduct)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedProduct_to_AdminUser");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FlaggedProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedProduct_to_Order");
            });

            modelBuilder.Entity<FlaggedReview>(entity =>
            {
                entity.HasKey(e => new { e.ReviewId, e.AdminUserId });

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.FlaggedReview)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedReview_to_AdminUser");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.FlaggedReview)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedReview_to_Review");
            });

            modelBuilder.Entity<FlaggedUser>(entity =>
            {
                entity.HasKey(e => new { e.WebsiteUserId, e.AdminUserId });

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.FlaggedUser)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedUser_to_AdminUser");

                entity.HasOne(d => d.WebsiteUser)
                    .WithMany(p => p.FlaggedUser)
                    .HasForeignKey(d => d.WebsiteUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlaggedUser_to_WebsiteUser");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasMaxLength(10);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.WebsiteUser)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.WebsiteUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_to_WebsiteUser");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_to_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_to_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Condition).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Price).HasMaxLength(10);

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_to_ProductCategory");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_to_ProductType");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(300);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Stars)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.ReviewedUser)
                    .WithMany(p => p.ReviewReviewedUser)
                    .HasForeignKey(d => d.ReviewedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_to_ReviewedUser");

                entity.HasOne(d => d.ReviewingUser)
                    .WithMany(p => p.ReviewReviewingUser)
                    .HasForeignKey(d => d.ReviewingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_to_ReviewingUser");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.HistoryId).ValueGeneratedNever();

                entity.HasOne(d => d.BillingInfo)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.BillingInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_to_BillingInfo");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_to_Product");

                entity.HasOne(d => d.WebsiteUser)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.WebsiteUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_to_WebsiteUser");
            });

            modelBuilder.Entity<WebsiteUser>(entity =>
            {
                entity.Property(e => e.WebsiteUserId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(1026);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
