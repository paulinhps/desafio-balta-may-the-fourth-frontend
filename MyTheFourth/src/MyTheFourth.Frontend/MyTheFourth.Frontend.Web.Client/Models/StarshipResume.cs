using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Web.Models;

public class StarshipResume : AbstractItemModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
}