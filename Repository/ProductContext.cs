﻿//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//using Entities;

//namespace Repositories;

//public partial class ProductContext : DbContext
//{
//    public ProductContext()
//    {
//    }

//    public ProductContext(DbContextOptions<ProductContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Category> Categories { get; set; }

//    public virtual DbSet<Order> Orders { get; set; }

//    public virtual DbSet<OrderItem> OrderItems { get; set; }

//    public virtual DbSet<Product> Products { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    public virtual DbSet<Rating> Ratings { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        //=> optionsBuilder.UseSqlServer("Server=SRV2\\PUPILS;Database=Product;Trusted_Connection=True;TrustServerCertificate=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Category>(entity =>
//        {
//            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
//            entity.Property(e => e.CategoryName)
//                .HasMaxLength(50)
//                .HasColumnName("Category_Name");
//        });

//        modelBuilder.Entity<Order>(entity =>
//        {
//            entity.ToTable("Orders");

//            entity.Property(e => e.OrderId).HasColumnName("Order_ID").ValueGeneratedOnAdd();




//            //entity.Property(e => e.OrderId)
//            //    .ValueGeneratedNever()
//            //    .HasColumnName("Order_ID");
//            entity.Property(e => e.OrderSum).HasColumnName("Order_Sum");
//            entity.Property(e => e.OrdetDate)
//                .HasColumnType("datetime")
//                .HasColumnName("Ordet_Date");
//            entity.Property(e => e.UserId).HasColumnName("User_ID");

//            entity.HasOne(d => d.User).WithMany(p => p.Orders)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Orders_Users");
//        });

//        modelBuilder.Entity<OrderItem>(entity =>
//        {
//            entity.ToTable("Order_Item");

//            entity.Property(e => e.OrderItemId).HasColumnName("Order_Item_ID").ValueGeneratedOnAdd();

//                //.HasColumnName("Order_Item_ID");

//            entity.Property(e => e.ProductId).HasColumnName("Product_ID"); 
//            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
//            entity.Property(e => e.Quentity).HasColumnName("Quentity");
//            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
//                .HasForeignKey(d => d.OrderId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Order_Item_Orders");

//            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Order_Item_Products");
//        });

//        modelBuilder.Entity<Product>(entity =>
//        {
//            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
//            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
//            entity.Property(e => e.Decripition).HasMaxLength(50);
//            entity.Property(e => e.ImgPath).HasMaxLength(50);
//            entity.Property(e => e.ProductName)
//                .HasMaxLength(50)
//                .HasColumnName("Product_Name");

//            entity.HasOne(d => d.Category).WithMany(p => p.Products)
//                .HasForeignKey(d => d.CategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Products_Categories");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.Property(e => e.Email)
//                .HasMaxLength(50)
//                .IsFixedLength();
//            entity.Property(e => e.FirstName)
//                .HasMaxLength(50)
//                .IsFixedLength();
//            entity.Property(e => e.LastName)
//                .HasMaxLength(50)
//                .IsFixedLength();
//            entity.Property(e => e.Password)
//                .HasMaxLength(50)
//                .IsFixedLength();
//        });
//        modelBuilder.Entity<Rating>(entity =>
//        {
//            entity.ToTable("RATING");

//            entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

//            entity.Property(e => e.Host)
//                .HasColumnName("HOST")
//                .HasMaxLength(50);

//            entity.Property(e => e.Method)
//                .HasColumnName("METHOD")
//                .HasMaxLength(10)
//                .IsFixedLength();

//            entity.Property(e => e.Path)
//                .HasColumnName("PATH")
//                .HasMaxLength(50);

//            entity.Property(e => e.RecordDate)
//             .HasColumnName("Record_Date")
//             .HasColumnType("datetime");

//            entity.Property(e => e.Referer)
//                .HasColumnName("REFERER")
//                .HasMaxLength(100);

//            entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}


using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public partial class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // הקפד להוציא את מחרוזת ההתחברות מהקוד ולהשתמש בקובץ תצורה
                //=> optionsBuilder.UseSqlServer("Server=SRV2\\PUPILS;Database=Product;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_Name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.OrderSum).HasColumnName("Order_Sum");
                entity.Property(e => e.OrdetDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ordet_Date");
                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");

                entity.Property(e => e.OrderItemId).HasColumnName("Order_Item_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.ProductId).HasColumnName("Product_ID");
                entity.Property(e => e.OrderId).HasColumnName("Order_ID");
                entity.Property(e => e.Quentity).HasColumnName("Quentity");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Orders");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("Product_ID");
                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
                entity.Property(e => e.Decripition).HasMaxLength(50);
                entity.Property(e => e.ImgPath).HasMaxLength(50);
                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Name");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsFixedLength();
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsFixedLength();
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");
                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);
                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);
                entity.Property(e => e.RecordDate)
                    .HasColumnName("Record_Date")
                    .HasColumnType("datetime");
                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);
                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}