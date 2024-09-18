namespace app.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CargosTransport> CargosTransports { get; set; } = new List<CargosTransport>();
}
