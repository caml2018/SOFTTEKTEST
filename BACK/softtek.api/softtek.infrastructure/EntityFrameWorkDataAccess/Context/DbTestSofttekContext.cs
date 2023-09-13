using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using softtek.infrastructure.EntityFrameWorkDataAccess.Models;

#nullable disable

namespace softtek.infrastructure.EntityFrameWorkDataAccess.Context
{
    public partial class DbTestSofttekContext : DbContext
    {
        public DbTestSofttekContext()
        {
        }

        public DbTestSofttekContext(DbContextOptions<DbTestSofttekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Excepcione> Excepciones { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Result> Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TN31B2J;Database=DbTestSofttek;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.ToTable("cuentas", "reports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuentaPadre).HasColumnName("cuentaPadre");

                entity.Property(e => e.TipoCuentaId).HasColumnName("tipoCuentaId");

                entity.HasOne(d => d.TipoCuenta)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.TipoCuentaId)
                    .HasConstraintName("Fk_tipocuenta_cuenta");
            });

            modelBuilder.Entity<Excepcione>(entity =>
            {
                entity.ToTable("excepciones", "reports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cuenta).HasColumnName("cuenta");

                entity.Property(e => e.Tercero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tercero");

                entity.Property(e => e.TipoCuentaId).HasColumnName("tipoCuentaId");

                entity.Property(e => e.ValorAjustePeso)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorAjustePeso");

                entity.HasOne(d => d.TipoCuenta)
                    .WithMany(p => p.Excepciones)
                    .HasForeignKey(d => d.TipoCuentaId)
                    .HasConstraintName("FK_cuentas_excepciones");
            });

            modelBuilder.Entity<Report>(entity =>
            {

                entity.ToTable("report", "reports");

                entity.Property(e => e.Credito)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("credito");

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cuenta");

                entity.Property(e => e.Debito)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("debito");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.NombreCuena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreCuena");

                entity.Property(e => e.SaldoFinal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldoFinal");

                entity.Property(e => e.SaldoInicial)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldoInicial");

                entity.Property(e => e.Tercero)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tercero");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo", "reports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
