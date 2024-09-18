namespace app.Entities;

public partial class Route
{
    public int Id { get; set; }

    public int StartSettlementId { get; set; }

    public int EndSettlementId { get; set; }

    public int Distance { get; set; }

    public virtual ICollection<CargosTransport> CargosTransports { get; set; } = new List<CargosTransport>();

    public virtual Settlement EndSettlement { get; set; } = null!;

    public virtual Settlement StartSettlement { get; set; } = null!;
}
