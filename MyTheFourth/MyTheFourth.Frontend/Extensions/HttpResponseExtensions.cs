using System.Text.Json;

namespace MyTheFourth.Frontend.Extensions;

public static class HttpResponseExtensions
{
    public static async Task<T?> GetContentData<T>(this HttpResponseMessage response) where T : class
    {

        if (!response.IsSuccessStatusCode) return null!;

        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonSerializer.Deserialize<T>(content);

    }
}