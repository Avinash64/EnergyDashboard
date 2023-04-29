using System;
using System.Collections.Generic;
using EnergyDashboardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyDashboardAPI.Models;

public partial class EnergyContext : DbContext
{
    // public EnergyContext()
    // {
    // }

    public EnergyContext(DbContextOptions<EnergyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Energy2015> Energy2015s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Energy2015>(entity =>
        {
            entity.HasKey(e => e.Bbl).HasName("PK__energy.2__C6DD4BDE75501970");

            entity.ToTable("energy.2015");

            entity.Property(e => e.Bbl)
                .ValueGeneratedNever()
                .HasColumnName("BBL");
            entity.Property(e => e.Bin).HasColumnName("BIN");
            entity.Property(e => e.Borough)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BoroughNumber).HasColumnName("Borough Number");
            entity.Property(e => e.BuildingAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Building Address");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Building Name");
            entity.Property(e => e.CensusTract).HasColumnName("Census Tract");
            entity.Property(e => e.CommunityBoard).HasColumnName("Community Board");
            entity.Property(e => e.CouncilDistrict).HasColumnName("Council District");
            entity.Property(e => e.EnergyUsage).HasColumnName("Energy Usage");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Nta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NTA");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
