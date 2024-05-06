using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSya.ManageInventory.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";

        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEcapcd> GtEcapcds { get; set; } = null!;
        public virtual DbSet<GtEciuom> GtEciuoms { get; set; } = null!;
        public virtual DbSet<GtEiitcd> GtEiitcds { get; set; } = null!;
        public virtual DbSet<GtEiitct> GtEiitcts { get; set; } = null!;
        public virtual DbSet<GtEiitgc> GtEiitgcs { get; set; } = null!;
        public virtual DbSet<GtEiitgr> GtEiitgrs { get; set; } = null!;
        public virtual DbSet<GtEiitsc> GtEiitscs { get; set; } = null!;
        public virtual DbSet<GtEipait> GtEipaits { get; set; } = null!;
        public virtual DbSet<GtEskucd> GtEskucds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);
            });

            modelBuilder.Entity<GtEciuom>(entity =>
            {
                entity.HasKey(e => e.UnitOfMeasure);

                entity.ToTable("GT_ECIUOM");

                entity.Property(e => e.UnitOfMeasure).ValueGeneratedNever();

                entity.Property(e => e.ConversionFactor).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Uompurchase).HasColumnName("UOMPurchase");

                entity.Property(e => e.Uomstock).HasColumnName("UOMStock");
            });

            modelBuilder.Entity<GtEiitcd>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

                entity.ToTable("GT_EIITCD");

                entity.Property(e => e.ItemCode).ValueGeneratedNever();

                entity.Property(e => e.BarcodeCodeId)
                    .HasMaxLength(20)
                    .HasColumnName("BarcodeCodeID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.InventoryClass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsHsnlinked).HasColumnName("IsHSNLinked");

                entity.Property(e => e.ItemClass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemCriticality)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemDescription).HasMaxLength(100);

                entity.Property(e => e.ItemSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEiitct>(entity =>
            {
                entity.HasKey(e => e.ItemCategory);

                entity.ToTable("GT_EIITCT");

                entity.Property(e => e.ItemCategory).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ItemCategoryDesc).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEiitgc>(entity =>
            {
                entity.HasKey(e => new { e.ItemGroup, e.ItemCategory, e.ItemSubCategory });

                entity.ToTable("GT_EIITGC");

                entity.Property(e => e.ComittmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OriginalBudgetAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RevisedBudgetAmount).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.ItemCategoryNavigation)
                    .WithMany(p => p.GtEiitgcs)
                    .HasForeignKey(d => d.ItemCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIITGC_GT_EIITCT");

                entity.HasOne(d => d.ItemGroupNavigation)
                    .WithMany(p => p.GtEiitgcs)
                    .HasForeignKey(d => d.ItemGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIITGC_GT_EIITGR");
            });

            modelBuilder.Entity<GtEiitgr>(entity =>
            {
                entity.HasKey(e => e.ItemGroup);

                entity.ToTable("GT_EIITGR");

                entity.Property(e => e.ItemGroup).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ItemGroupDesc).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEiitsc>(entity =>
            {
                entity.HasKey(e => new { e.ItemCategory, e.ItemSubCategory });

                entity.ToTable("GT_EIITSC");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ItemSubCategoryDesc).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.ItemCategoryNavigation)
                    .WithMany(p => p.GtEiitscs)
                    .HasForeignKey(d => d.ItemCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIITSC_GT_EIITCT");
            });

            modelBuilder.Entity<GtEipait>(entity =>
            {
                entity.HasKey(e => new { e.ItemCode, e.ParameterId });

                entity.ToTable("GT_EIPAIT");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ParmPerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ParmValue).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.GtEipaits)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIPAIT_GT_EIITCD");
            });

            modelBuilder.Entity<GtEskucd>(entity =>
            {
                entity.HasKey(e => e.Skuid);

                entity.ToTable("GT_ESKUCD");

                entity.Property(e => e.Skuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SKUID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Skucode).HasColumnName("SKUCode");

                entity.Property(e => e.Skutype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SKUType")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
