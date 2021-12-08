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

        public virtual DbSet<Arcos> Arcos { get; set; }
        public virtual DbSet<Capitulos> Capitulos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<Arcos>(entity =>
            {
                entity.ToTable("arcos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600);

                entity.Property(e => e.NombreArco)
                    .IsRequired()
                    .HasMaxLength(600);
            });

            modelBuilder.Entity<Capitulos>(entity =>
            {
                entity.ToTable("capitulos");

                entity.HasIndex(e => e.IdArco, "idArco");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600);

                entity.Property(e => e.IdArco).HasColumnName("idArco");

                entity.Property(e => e.NombreCapitulo)
                    .IsRequired()
                    .HasMaxLength(600);

                entity.HasOne(d => d.IdArcoNavigation)
                    .WithMany(p => p.Capitulos)
                    .HasForeignKey(d => d.IdArco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("capitulos_ibfk_1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreReal)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
