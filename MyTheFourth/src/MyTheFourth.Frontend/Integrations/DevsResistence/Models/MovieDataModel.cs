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

        [JsonPropertyName("planetId")]
        public int PlanetId { get; set; }

        [JsonPropertyName("planet")]
        public PlanetDataModel Planet { get; set; } = null!;

        [JsonPropertyName("movies")]
        public List<MovieDataModel> Movies { get; set; } = new();
    }

    public class PlanetDataModel
    {
       [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

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
        public List<CharacterDataModel> Characters { get; set; } = new();

        [JsonPropertyName("movies")]
        public List<MovieDataModel> Movies { get; set; } = new();
    }