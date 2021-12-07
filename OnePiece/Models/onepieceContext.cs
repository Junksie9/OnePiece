using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OnePiece.Models
{
    public partial class onepieceContext : DbContext
    {
        public onepieceContext()
        {
        }

        public onepieceContext(DbContextOptions<onepieceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arco> Arcos { get; set; }
        public virtual DbSet<Capitulo> Capitulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<Arco>(entity =>
            {
                entity.HasKey(e => e.IdArco)
                    .HasName("PRIMARY");

                entity.ToTable("arcos");

                entity.Property(e => e.IdArco).HasColumnName("idArco");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NombreArco)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Capitulo>(entity =>
            {
                entity.HasKey(e => e.IdCapitulo)
                    .HasName("PRIMARY");

                entity.ToTable("capitulos");

                entity.HasIndex(e => e.IdArcosToCap, "idArcosToCap");

                entity.Property(e => e.IdCapitulo).HasColumnName("idCapitulo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdArcosToCap).HasColumnName("idArcosToCap");

                entity.Property(e => e.NombreCapitulo)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdArcosToCapNavigation)
                    .WithMany(p => p.Capitulos)
                    .HasForeignKey(d => d.IdArcosToCap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("capitulos_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
