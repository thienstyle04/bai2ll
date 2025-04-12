using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using bai2ll.Models.Domain;

namespace bai2ll.Data;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Mssv).HasName("PK__Student__23B8178770C10D1E");

            entity.ToTable("Student");

            entity.Property(e => e.Mssv)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ImgUrl).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
