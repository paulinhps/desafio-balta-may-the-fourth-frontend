namespace MyTheFourth.Frontend.Models;

public class Movie : MovieResume
{
    public int Episode { get; set; }

    public string OpeningCrawl { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Producer { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public List<CharacterResume> Characters { get; set; }

    public List<PlanetResume> Planets { get; set; }

    public List<VehicleResume> Vehicles { get; set; }

    public List<StarshipResume> Starships { get; set; }

    public Movie()
    {
        Characters = new List<CharacterResume>();
        Planets = new List<PlanetResume>();
        Vehicles = new List<VehicleResume>();
        Starships = new List<StarshipResume>();
    }
}