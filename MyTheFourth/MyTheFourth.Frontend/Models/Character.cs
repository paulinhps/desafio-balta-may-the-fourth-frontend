using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Models;

public class Character : CharacterResume
{

    [JsonPropertyName("height")]
    public string Height { get; set; } = null!;

    [JsonPropertyName("weight")]
    public string Weight { get; set; } = null!;

    [JsonPropertyName("hairColor")]
    public string HairColor { get; set; } = null!;

    [JsonPropertyName("skinColor")]
    public string SkinColor { get; set; } = null!;

    [JsonPropertyName("eyeColor")]
    public string EyeColor { get; set; } = null!;

    [JsonPropertyName("birthYear")]
    public string BirthYear { get; set; } = null!;

    [JsonPropertyName("gender")]
    public string Gender { get; set; } = null!;

    [JsonPropertyName("planet")]
    public PlanetResume Planet { get; set; } = null!;

    [JsonPropertyName("movies")]
    public List<MovieResume> Movies { get; set; }

    public Character()
    {
        Movies = new List<MovieResume>();
    }
}