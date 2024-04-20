using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Web.Models;

public class MovieResume : AbstractItemModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;
}