namespace MyTheFourth.Frontend.Models;

public class Starship : StarshipResume
{

    public string Model { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string CostInCredits { get; set; } = null!;

    public string Length { get; set; } = null!;

    public string MaxSpeed { get; set; } = null!;

    public string Crew { get; set; } = null!;

    public string Passengers { get; set; } = null!;

    public string CargoCapacity { get; set; } = null!;

    public string HyperdriveRating { get; set; } = null!;

    public string Mglt { get; set; } = null!;

    public string Consumables { get; set; } = null!;

    public string Class { get; set; } = null!;

    public IEnumerable<MovieResume> Movies { get; set; }

    public Starship()
    {
        Movies = new List<MovieResume>();
    }
}