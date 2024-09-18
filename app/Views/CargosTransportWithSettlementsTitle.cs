namespace app.Views;

public partial class CargosTransportWithSettlementsTitle
{
    public string DocumentNumber { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Info { get; set; } = null!;

    public string StartSettlementTitle { get; set; } = null!;

    public string EndSettlementTitle { get; set; } = null!;

    public int Distance { get; set; }
}
