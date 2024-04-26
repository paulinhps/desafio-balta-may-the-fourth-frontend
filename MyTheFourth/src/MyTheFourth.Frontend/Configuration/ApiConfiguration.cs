namespace MyTheFourth.Frontend.Configuration;

public class ApiConfiguration
{
    public string ServiceId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BaseAddress { get; set; } = null!;
    public bool AllowCrud { get; set; }
}
