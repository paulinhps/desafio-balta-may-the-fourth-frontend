using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.Extensions;
using MyTheFourth.Frontend.Models;
using MyTheFourth.Frontend.RebelRenegadesContext.Constants;
using MyTheFourth.Frontend.RebelRenegadesContext.Models;
using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.RebelRenegadesContext.Services;

public class RebelRenegadesMyTheFourthHttpService :
IMyTheFourthService
{
    private readonly HttpClient _client;

    public RebelRenegadesMyTheFourthHttpService(HttpClient client)
    {
        _client = client;
    }

    public string ServiceId => BackendServicesIdentifiers.RebelRenegades;

    private void ThrowNotImplementedException() => throw new NotImplementedException("Mapper not implemented!");

    public async Task<Character?> GetCharacterAsync(string characterId)
    {
        if (!Guid.TryParse(characterId, out var guidId))
            return await GetCharacterBySlugAsync(characterId);


        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<PersonDetailsData>>();
        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Character>(result.Data!.DataItem) : default!;
    }

    private async Task<Character?> GetCharacterBySlugAsync(string slug)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.CharactersEndpoint}/slug/{slug}");

        var result = await response.GetContentData<ApiDataResponse<PersonDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Character>(result.Data!.DataItem) : default!;
    }

    public async Task<Movie?> GetMovieAsync(string movieId)
    {

        if (!Guid.TryParse(movieId, out var guidId))
            return await GetMovieBySlugAsync(movieId);

        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<FilmDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Movie>(result.Data!.DataItem) : default!;
    }

    private async Task<Movie?> GetMovieBySlugAsync(string slug)
    {

        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/slug/{slug}");

        var result = await response.GetContentData<ApiDataResponse<FilmDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Movie>(result.Data!.DataItem) : default!;
    }

    public async Task<Planet?> GetPlanetAsync(string planetId)
    {
        if (!Guid.TryParse(planetId, out var guidId))
            return await GetPlanetBySlugAsync(planetId);

        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.PlanetsEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<PlanetDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Planet>(result.Data!.DataItem) : default!;
    }

    private async Task<Planet?> GetPlanetBySlugAsync(string slug)
    {
        try
        {
            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.PlanetsEndpoint}/slug/{slug}");

            var result = await response.GetContentData<ApiDataResponse<PlanetDetailsData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.Data?.DataItem is not null ? _mapper.Map<Planet>(result.Data!.DataItem) : default!;

        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            throw;
        }
    }

    public async Task<Starship?> GetStarshipAsync(string starshipId)
    {
        if (!Guid.TryParse(starshipId, out var guidId))
            return await GetStarshipBySlugAsync(starshipId);

        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.StarshipsEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<StarshipDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Starship>(result.Data!.DataItem) : default!;
    }

    private async Task<Starship?> GetStarshipBySlugAsync(string slug)
    {
        try
        {
            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.StarshipsEndpoint}/slug/{slug}");

            var result = await response.GetContentData<ApiDataResponse<StarshipDetailsData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.Data?.DataItem is not null ? _mapper.Map<Starship>(result.Data!.DataItem) : default!;

        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            throw;
        }
    }
    public async Task<Vehicle?> GetVehicleAsync(string vehicleId)
    {
        if (!Guid.TryParse(vehicleId, out var guidId))
            return await GetVehicleBySlugAsync(vehicleId);

        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.VehiclesEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<VehicleDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Vehicle>(result.Data!.DataItem) : default!;
    }

    private async Task<Vehicle?> GetVehicleBySlugAsync(string slug)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.VehiclesEndpoint}/slug/{slug}");

        var result = await response.GetContentData<ApiDataResponse<VehicleDetailsData>>();

        ThrowNotImplementedException();
        return default!;
        // return result?.Data?.DataItem is not null ? _mapper.Map<Vehicle>(result.Data!.DataItem) : default!;
    }

    public async Task<IEnumerable<Character>> ListCharactersAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.CharactersEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<ApiDataResponse<PeopleListData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Character>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Character>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);

        }
        return Enumerable.Empty<Character>();
    }

    public async Task<IEnumerable<Movie>> ListMoviesAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<ApiDataResponse<FilmsListData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Movie>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Movie>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);

        }
        return Enumerable.Empty<Movie>();
    }

    public async Task<IEnumerable<Planet>> ListPlanetsAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.PlanetsEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<ApiDataResponse<PlanetsListData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Planet>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Planet>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);

        }
        return Enumerable.Empty<Planet>();
    }

    public async Task<IEnumerable<Starship>> ListStarshipsAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.StarshipsEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<ApiDataResponse<StarshipsListData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Starship>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Starship>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);

        }
        return Enumerable.Empty<Starship>();
    }

    public async Task<IEnumerable<Vehicle>> ListVehiclesAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.VehiclesEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<ApiDataResponse<VehiclesListData>>();

            ThrowNotImplementedException();
            return default!;
            // return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Vehicle>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Vehicle>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);

        }
        return Enumerable.Empty<Vehicle>();
    }
}