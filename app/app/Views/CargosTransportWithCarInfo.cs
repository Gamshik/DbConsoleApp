namespace app.Views;

public partial class CargosTransportWithCarInfo
{
    public string DocumentNumber { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Info { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public int LoadCapacity { get; set; }
}
