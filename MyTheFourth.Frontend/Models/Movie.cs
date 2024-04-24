using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Models;

public class Movie : MovieResume
{
    [JsonPropertyName("episode")]
    public int Episode { get; set; }

    [JsonPropertyName("openingCrawl")]
    public string OpeningCrawl { get; set; } = null!;

    [JsonPropertyName("director")]
    public string Director { get; set; } = null!;

    [JsonPropertyName("producer")]
    public string Producer { get; set; } = null!;

    [JsonPropertyName("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    [JsonPropertyName("characters")]
    public List<CharacterResume> Characters { get; set; }

    [JsonPropertyName("planets")]
    public List<PlanetResume> Planets { get; set; }

    [JsonPropertyName("vehicles")]
    public List<VehicleResume> Vehicles { get; set; }

    [JsonPropertyName("starships")]
    public List<StarshipResume> Starships { get; set; }

    public Movie()
    {
        Characters = new List<CharacterResume>();
        Planets = new List<PlanetResume>();
        Vehicles = new List<VehicleResume>();
        Starships = new List<StarshipResume>();
    }
}