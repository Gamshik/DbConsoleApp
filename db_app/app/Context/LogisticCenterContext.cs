using app.Entities;
using app.Views;
using Microsoft.EntityFrameworkCore;

namespace app.Context;

public partial class LogisticCenterContext : DbContext
{
    public LogisticCenterContext()
    {
    }

    public LogisticCenterContext(DbContextOptions<LogisticCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CargosTransport> CargosTransports { get; set; }

    public virtual DbSet<CargosTransportWithCarInfo> CargosTransportWithCarInfos { get; set; }

    public virtual DbSet<CargosTransportWithCargoInfo> CargosTransportWithCargoInfos { get; set; }

    public virtual DbSet<CargosTransportWithSettlementsTitle> CargosTransportWithSettlementsTitles { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Settlement> Settlements { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HOTDCIK;Database=LogisticCenter;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC0771B789B9");

            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargos__3214EC071862EB37");

            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CargosTransport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CargosTr__3214EC074D02B317");

            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Info).IsUnicode(false);

            entity.HasOne(d => d.Car).WithMany(p => p.CargosTransports)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK_CargosTransport_To_Cars");

            entity.HasOne(d => d.Cargo).WithMany(p => p.CargosTransports)
                .HasForeignKey(d => d.CargoId)
                .HasConstraintName("FK_CargosTransport_To_Cargos");

            entity.HasOne(d => d.Customer).WithMany(p => p.CargosTransports)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CargosTransport_To_Organizations");

            entity.HasOne(d => d.Driver).WithMany(p => p.CargosTransports)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK_CargosTransport_To_Drivers");

            entity.HasOne(d => d.Route).WithMany(p => p.CargosTransports)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK_CargosTransport_To_Routes");

            entity.HasOne(d => d.Tariff).WithMany(p => p.CargosTransports)
                .HasForeignKey(d => d.TariffId)
                .HasConstraintName("FK_CargosTransport_To_Tariffs");
        });

        modelBuilder.Entity<CargosTransportWithCarInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CargosTransportWithCarInfo");

            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Info).IsUnicode(false);
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CargosTransportWithCargoInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CargosTransportWithCargoInfo");

            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Info).IsUnicode(false);
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CargosTransportWithSettlementsTitle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CargosTransportWithSettlementsTitle");

            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EndSettlementTitle)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Info).IsUnicode(false);
            entity.Property(e => e.StartSettlementTitle)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07DC6BE031");

            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drivers__3214EC07C0D3AA1E");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Routes__3214EC07CB05F5C2");

            entity.HasOne(d => d.EndSettlement).WithMany(p => p.RouteEndSettlements)
                .HasForeignKey(d => d.EndSettlementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distances_To_Settlements_End");

            entity.HasOne(d => d.StartSettlement).WithMany(p => p.RouteStartSettlements)
                .HasForeignKey(d => d.StartSettlementId)
                .HasConstraintName("FK_Distances_To_Settlements_Start");
        });

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Settleme__3214EC07C94E2A40");

            entity.Property(e => e.Title)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tariffs__3214EC0737E28747");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
