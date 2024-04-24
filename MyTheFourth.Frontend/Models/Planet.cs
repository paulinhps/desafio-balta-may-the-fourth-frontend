using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Models;

public class Planet : PlanetResume
{

    [JsonPropertyName("rotationPeriod")]
    public string RotationPeriod { get; set; } = null!;

    [JsonPropertyName("orbitalPeriod")]
    public string OrbitalPeriod { get; set; } = null!;

    [JsonPropertyName("diameter")]
    public string Diameter { get; set; } = null!;

    [JsonPropertyName("climate")]
    public string Climate { get; set; } = null!;

    [JsonPropertyName("gravity")]
    public string Gravity { get; set; } = null!;

    [JsonPropertyName("terrain")]
    public string Terrain { get; set; } = null!;

    [JsonPropertyName("surfaceWater")]
    public string SurfaceWater { get; set; } = null!;

    [JsonPropertyName("population")]
    public string Population { get; set; } = null!;

    [JsonPropertyName("characters")]
    public List<CharacterResume> Characters { get; set; }

    [JsonPropertyName("movies")]
    public List<MovieResume> Movies { get; set; }

    public Planet()
    {
        Characters = new List<CharacterResume>();
        Movies = new List<MovieResume>();
    }
}