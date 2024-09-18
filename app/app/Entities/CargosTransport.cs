namespace app.Entities;

public partial class CargosTransport
{
    public int Id { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Info { get; set; } = null!;

    public int DriverId { get; set; }

    public int CarId { get; set; }

    public int TariffId { get; set; }

    public int RouteId { get; set; }

    public int CargoId { get; set; }

    public int CustomerId { get; set; }

    public int PaymentAmount { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Route Route { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;
}
