using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

public partial class SystemTaimsalDevsContext : DbContext
{
    public SystemTaimsalDevsContext()
    {
    }

    public SystemTaimsalDevsContext(DbContextOptions<SystemTaimsalDevsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<UserDev> UserDevs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;persist security info=False;TrustServerCertificate=True;initial catalog=DbSysTaimsalDev");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__C1961B33DCE0E9AB");

            entity.Property(e => e.IdClient).ValueGeneratedNever();
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.IdMachine).HasName("PK__Machine__7C237E9AE11B040C");

            entity.Property(e => e.IdMachine).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__2E8946D4EBA67E6F");

            entity.Property(e => e.IdProduct).ValueGeneratedNever();
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.IdReport).HasName("PK__Report__46F9D6CE7E091114");

            entity.Property(e => e.IdReport).ValueGeneratedNever();

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reports).HasConstraintName("FK__Report__IdClient__4E88ABD4");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Reports).HasConstraintName("FK__Report__IdMachin__5070F446");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Reports).HasConstraintName("FK__Report__IdProduc__4F7CD00D");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Report__IdUser__4D94879B");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C47628D78");

            entity.Property(e => e.IdRol).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserDev>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__UserDev__B7C92638F9B0B8CC");

            entity.Property(e => e.IdUser).ValueGeneratedNever();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserDevs).HasConstraintName("FK__UserDev__IdRol__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
