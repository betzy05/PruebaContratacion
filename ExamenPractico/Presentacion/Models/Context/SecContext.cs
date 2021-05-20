using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Presentacion.Models.Models;

#nullable disable

namespace Presentacion.Models.Context
{
    public partial class SecContext : DbContext
    {
        public SecContext()
        {
        }

        public SecContext(DbContextOptions<SecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<RelClienteTiendum> RelClienteTienda { get; set; }
        public virtual DbSet<Tiendum> Tienda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HJVRIV6;Database=Mlg;User Id=sa;Password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RelClienteTiendum>(entity =>
            {
                entity.HasKey(e => e.IdRel)
                    .HasName("PK__RelClien__3C8791D29DC24AF7");

                entity.Property(e => e.IdRel).HasColumnName("idRel");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.IdTienda).HasColumnName("id_Tienda");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.RelClienteTienda)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__RelClient__id_Cl__3A81B327");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.RelClienteTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("FK__RelClient__id_Ti__3B75D760");
            });

            modelBuilder.Entity<Tiendum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
