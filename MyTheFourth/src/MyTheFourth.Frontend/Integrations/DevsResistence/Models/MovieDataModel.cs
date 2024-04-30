using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Integrations.DevsResistence.Models;

public class MovieDataModel
{
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("episode")]
        public int Episode { get; set; }

        [JsonPropertyName("openingCrawl")]
        public string OpeningCrawl { get; set; } = null!;

        [JsonPropertyName("director")]
        public string Director { get; set; } = null!;

        [JsonPropertyName("producer")]
        public string Producer { get; set; } = null!;

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; } = null!;

        [JsonPropertyName("characters")]
        public List<CharacterDataModel> Characters { get; set; }= new();

        [JsonPropertyName("planets")]
        public List<PlanetDataModel> Planets { get; set; }= new();

        [JsonPropertyName("vehicles")]
        public List<VehicleDataModel> Vehicles { get; set; }= new();

        [JsonPropertyName("starships")]
        public List<StarshipDataModel> Starships { get; set; } = new();
}

public class StarshipDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;
    }

    public class VehicleDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;
    }

     public class CharacterDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
    }

    public class PlanetDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;
    }