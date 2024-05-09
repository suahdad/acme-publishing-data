using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace acme_publishing_data;

public partial class AcmePublishingDbContext : DbContext
{
    public AcmePublishingDbContext()
    {
    }

    public AcmePublishingDbContext(DbContextOptions<AcmePublishingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }

    public virtual DbSet<Distributor> Distributors { get; set; }

    public virtual DbSet<Magazine> Magazines { get; set; }

    public virtual DbSet<MagazineSubscription> MagazineSubscriptions { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionsHistory> SubscriptionsHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;Database=acme_publishing_db;Uid=root;Pwd=Init@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("countries");

            entity.Property(e => e.Id)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.Id)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CountryId)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("country_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middleName");
        });

        modelBuilder.Entity<CustomerSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customer_subscriptions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CountryId)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("country_id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("customer_id");
            entity.Property(e => e.SubscriptionId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("subscription_id");
        });

        modelBuilder.Entity<Distributor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("distributors");

            entity.Property(e => e.Id)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CountryId)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("magazine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IssueDate)
                .HasColumnType("date")
                .HasColumnName("issue_date");
            entity.Property(e => e.IssueNumber).HasColumnName("issue_number");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MagazineSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("magazine_subscriptions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("date")
                .HasColumnName("added_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MagazineId).HasColumnName("magazine_id");
            entity.Property(e => e.SubscriptionId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("subscription_id");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscriptions");

            entity.Property(e => e.Id)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SubscriptionsHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscriptions_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DistributorId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("distributor_id");
            entity.Property(e => e.SubscriptionId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("subscription_id");
            entity.Property(e => e.TimeTriggered)
                .HasColumnType("datetime")
                .HasColumnName("time_triggered");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
