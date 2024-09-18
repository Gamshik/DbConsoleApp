namespace app.Entities;

public partial class Tariff
{
    public int Id { get; set; }

    public int MinWeight { get; set; }

    public int MaxWeight { get; set; }

    public int CostPerKm { get; set; }

    public virtual ICollection<CargosTransport> CargosTransports { get; set; } = new List<CargosTransport>();
}
