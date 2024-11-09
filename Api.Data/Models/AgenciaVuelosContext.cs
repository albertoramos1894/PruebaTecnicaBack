using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Models;

public partial class AgenciaVuelosContext : DbContext
{
    public AgenciaVuelosContext()
    {
    }

    public AgenciaVuelosContext(DbContextOptions<AgenciaVuelosContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Aerolinea> Aerolineas { get; set; }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CostoPlaza> CostoPlazas { get; set; }

    public virtual DbSet<Itinerario> Itinerarios { get; set; }

    public virtual DbSet<ItinerarioVuelo> ItinerarioVuelos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    //Stored Procedures
    public virtual DbSet<stpListItinerario> StpListItinerarios { get; set; }
    public virtual DbSet<StpListVuelos> stpListVuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var connectionString = configuration.GetConnectionString("AppDb");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aerolinea>(entity =>
        {
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Boletos_Categorias");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Boletos_Clientes");

            entity.HasOne(d => d.Itinerario).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.ItinerarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Boletos_Itinerarios");

            entity.HasOne(d => d.Venta).WithMany(p => p.Boletos)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK_Boletos_Ventas");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CostoPlaza>(entity =>
        {
            entity.HasKey(e => e.CostoId);

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.CostoPlazas)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CostoPlazas_Categorias1");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.CostoPlazas)
                .HasForeignKey(d => d.VueloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CostoPlazas_Vuelos");
        });

        modelBuilder.Entity<Itinerario>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Destino).WithMany(p => p.ItinerarioDestinos)
                .HasForeignKey(d => d.DestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Itinerarios_Aeropuertos1");

            entity.HasOne(d => d.Origen).WithMany(p => p.ItinerarioOrigens)
                .HasForeignKey(d => d.OrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Itinerarios_Aeropuertos");
        });

        modelBuilder.Entity<ItinerarioVuelo>(entity =>
        {
            entity.HasKey(e => new { e.ItinerarioId, e.VueloId });

            entity.ToTable("ItinerarioVuelo");

            entity.HasOne(d => d.Itinerario).WithMany(p => p.ItinerarioVuelos)
                .HasForeignKey(d => d.ItinerarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItinerarioVuelo_Itinerarios1");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.ItinerarioVuelos)
                .HasForeignKey(d => d.VueloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItinerarioVuelo_Vuelos");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.Property(e => e.VentaId).ValueGeneratedNever();
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Clientes");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Hora).HasPrecision(4);

            entity.HasOne(d => d.AeropuertoDestino).WithMany(p => p.VueloAeropuertoDestinos)
                .HasForeignKey(d => d.AeropuertoDestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vuelos_Aeropuertos");

            entity.HasOne(d => d.AeropuertoOrigen).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.AeropuertoOrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vuelos_Aerolineas");

            entity.HasOne(d => d.AeropuertoOrigenNavigation).WithMany(p => p.VueloAeropuertoOrigenNavigations)
                .HasForeignKey(d => d.AeropuertoOrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vuelos_Aeropuertos1");
        });

        modelBuilder.Entity<stpListItinerario>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<StpListVuelos>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
