namespace MyTheFourth.Frontend.Integrations.DevsResistence.Models;

public class MovieDataModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public short Episode { get; set; }
    public string OpeningCrawl { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Producer { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;
}
