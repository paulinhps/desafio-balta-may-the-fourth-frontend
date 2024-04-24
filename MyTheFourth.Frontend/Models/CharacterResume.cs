using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Models;


public class CharacterResume : AbstractItemModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Name { get; set; } = null!;
}
