namespace app.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public int LoadCapacity { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public virtual ICollection<CargosTransport> CargosTransports { get; set; } = new List<CargosTransport>();
}
