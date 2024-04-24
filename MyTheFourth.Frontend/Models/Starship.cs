using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Models;

public class Starship : StarshipResume
{

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = null!;

    [JsonPropertyName("costInCredits")]
    public string CostInCredits { get; set; } = null!;

    [JsonPropertyName("length")]
    public string Length { get; set; } = null!;

    [JsonPropertyName("maxSpeed")]
    public string MaxSpeed { get; set; } = null!;

    [JsonPropertyName("crew")]
    public string Crew { get; set; } = null!;

    [JsonPropertyName("passengers")]
    public string Passengers { get; set; } = null!;

    [JsonPropertyName("cargoCapacity")]
    public string CargoCapacity { get; set; } = null!;

    [JsonPropertyName("hyperdriveRating")]
    public string HyperdriveRating { get; set; } = null!;

    [JsonPropertyName("mglt")]
    public string Mglt { get; set; } = null!;

    [JsonPropertyName("consumables")]
    public string Consumables { get; set; } = null!;

    [JsonPropertyName("class")]
    public string Class { get; set; } = null!;

    [JsonPropertyName("movies")]
    public IEnumerable<MovieResume> Movies { get; set; }

    public Starship()
    {
        Movies = new List<MovieResume>();
    }
}