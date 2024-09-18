namespace app.Entities;

public partial class Cargo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Weight { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public virtual ICollection<CargosTransport> CargosTransports { get; set; } = new List<CargosTransport>();
}
