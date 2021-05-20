using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Datos.Models;

#nullable disable

namespace Datos.Context
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
        public virtual DbSet<myStoreProcedure> MyProcedure {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-HJVRIV6;Database=Mlg;User Id=sa;Password=123456789;")
                 .EnableSensitiveDataLogging(true) ;
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
            modelBuilder.Entity<myStoreProcedure>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id_Cliente).HasColumnName("id_Cliente");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComprasHechas)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ComprasHechas");
                
            });

            modelBuilder.Entity<RelClienteTiendum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.IdTienda).HasColumnName("id_Tienda");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__RelClient__id_Cl__3A81B327");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany()
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
