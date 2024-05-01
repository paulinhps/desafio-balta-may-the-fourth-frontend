using AutoMapper;
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
    private readonly IMapper _mapper;

    public RebelRenegadesMyTheFourthHttpService(HttpClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public string ServiceId => BackendServicesIdentifiers.RebelRenegades;

    public async Task<Character?> GetCharacterAsync(string characterId)
    {
        if(!Guid.TryParse(characterId, out var guidId))
            return await GetCharacterBySlugAsync(characterId);


        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<PersonDetailsData>>();

        return result?.Data?.DataItem is not null ? _mapper.Map<Character>(result.Data!.DataItem) : default!;
    }

    private async Task<Character?> GetCharacterBySlugAsync(string slug)
    {
          var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.CharactersEndpoint}/slug/{slug}");

        var result = await response.GetContentData<ApiDataResponse<FilmDetailsData>>();

        return result?.Data?.DataItem is not null ? _mapper.Map<Character>(result.Data!.DataItem) : default!;
    }

    public async Task<Movie?> GetMovieAsync(string movieId)
    {

        if(!Guid.TryParse(movieId, out var guidId))
            return await GetMovieBySlugAsync(movieId);


        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/{guidId}");

        var result = await response.GetContentData<ApiDataResponse<FilmDetailsData>>();

        return result?.Data?.DataItem is not null ? _mapper.Map<Movie>(result.Data!.DataItem) : default!;
    }

    private async Task<Movie?> GetMovieBySlugAsync(string slug)
    {
        
        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/slug/{slug}");

        var result = await response.GetContentData<ApiDataResponse<FilmDetailsData>>();

        return result?.Data?.DataItem is not null ? _mapper.Map<Movie>(result.Data!.DataItem) : default!;
    }

    public Task<Planet?> GetPlanetAsync(string planetId)
    {
        throw new NotImplementedException();
    }

    public Task<Starship?> GetStarshipAsync(string starshipId)
    {
        throw new NotImplementedException();
    }

    public Task<Vehicle?> GetVehicleAsync(string vehicleId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Character>> ListCharactersAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.CharactersEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<ApiDataResponse<PeopleListData>>();

            return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Character>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Character>();
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

            return result?.IsSuccess is true ? _mapper.Map<IEnumerable<Movie>>(result.Data!.DataItem!.Items) : Enumerable.Empty<Movie>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);

        }
        return Enumerable.Empty<Movie>();
    }

    public Task<IEnumerable<Planet>> ListPlanetsAsync(int? page = null, int? pageSize = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Starship>> ListStarshipsAsync(int? page = null, int? pageSize = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Vehicle>> ListVehiclesAsync(int? page = null, int? pageSize = null)
    {
        throw new NotImplementedException();
    }
}