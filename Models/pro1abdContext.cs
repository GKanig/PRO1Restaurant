using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRO1Restaurant.Models
{
    public partial class pro1abdContext : DbContext
    {
        public pro1abdContext()
        {
        }

        public pro1abdContext(DbContextOptions<pro1abdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Additives> Additives { get; set; }
        public virtual DbSet<AdditivesList> AdditivesList { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<PayMethodDict> PayMethodDict { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<StatusDict> StatusDict { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.0.104;Initial Catalog=pro1abd;User ID=Sa; Password=St@rt123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Additives>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NetPrice)
                    .HasColumnName("net_price")
                    .HasColumnType("decimal(2, 2)");
            });

            modelBuilder.Entity<AdditivesList>(entity =>
            {
                entity.ToTable("Additives_list");

                entity.Property(e => e.AdditivesListId)
                    .HasColumnName("additives_list_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditivesId).HasColumnName("additives_id");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.HasOne(d => d.Additives)
                    .WithMany(p => p.AdditivesList)
                    .HasForeignKey(d => d.AdditivesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingridients_Ingredients_list");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.AdditivesList)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_item_Ingredients_list");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.IsPaid).HasColumnName("is_paid");

                entity.Property(e => e.PayMethodId).HasColumnName("pay_method_id");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Client");

                entity.HasOne(d => d.PayMethod)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PayMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_pay_method_dict");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_promotion");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_status_dict");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("Order_item_Order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_item_Pizza");
            });

            modelBuilder.Entity<PayMethodDict>(entity =>
            {
                entity.ToTable("Pay_method_dict");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NetPrice)
                    .HasColumnName("net_price")
                    .HasColumnType("decimal(2, 2)");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<StatusDict>(entity =>
            {
                entity.ToTable("Status_dict");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
