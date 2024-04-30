namespace MyTheFourth.Frontend.Models;

public class Movie : MovieResume
{
    public int Episode { get; set; }

    public string OpeningCrawl { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Producer { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public IEnumerable<CharacterResume> Characters { get; set; }

    public IEnumerable<PlanetResume> Planets { get; set; }

    public IEnumerable<VehicleResume> Vehicles { get; set; }

    public IEnumerable<StarshipResume> Starships { get; set; }

    public Movie()
    {
        Characters = new List<CharacterResume>();
        Planets = new List<PlanetResume>();
        Vehicles = new List<VehicleResume>();
        Starships = new List<StarshipResume>();
    }
}