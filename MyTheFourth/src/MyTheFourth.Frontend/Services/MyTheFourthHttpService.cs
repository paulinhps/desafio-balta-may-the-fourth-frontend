using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.Extensions;
using MyTheFourth.Frontend.Services.Interfaces;
using MyTheFourth.Frontend.Models;

namespace MyTheFourth.Frontend.Services;

public class MyTheFourthHttpService :
IMoviesService,
ICharactersService,
IPlanetsService,
IVehiclesService,
IStarshipsService
{
    private readonly HttpClient _client;

    public MyTheFourthHttpService(HttpClient client)
    {
        _client = client;
    }

    public async Task<Movie?> GetMovieAsync(string movieId)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Movies}/{movieId}");

        return await response.GetContentData<Movie>();
    }

    //TODO: criar feature para verificar a existencia de parametros e incluir
    public async Task<IEnumerable<Movie>> ListMoviesAsync(int? page = null, int? pageSize = null)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Movies}");

        return await response.GetContentData<IEnumerable<Movie>>() ?? Enumerable.Empty<Movie>();
    }

    public async Task<Character?> GetCharacterAsync(string characterId)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Characters}/{characterId}");

        return await response.GetContentData<Character>();
    }


    //TODO: criar feature para verificar a existencia de parametros e incluir
    public async Task<IEnumerable<Character>> ListCharactersAsync(int? page = null, int? pageSize = null)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Characters}");

        return await response.GetContentData<IEnumerable<Character>>() ?? Enumerable.Empty<Character>();
    }

    public async Task<Planet?> GetPlanetAsync(string planetId)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Planets}/{planetId}");

        return await response.GetContentData<Planet>();
    }

    //TODO: criar feature para verificar a existencia de parametros e incluir
    public async Task<IEnumerable<Planet>> ListPlanetsAsync(int? page = null, int? pageSize = null)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Planets}");

        return await response.GetContentData<IEnumerable<Planet>>() ?? Enumerable.Empty<Planet>();
    }


    public async Task<Vehicle?> GetVehicleAsync(string vehicleId)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Vehicles}/{vehicleId}");

        return await response.GetContentData<Vehicle>();
    }


    //TODO: criar feature para verificar a existencia de parametros e incluir
    public async Task<IEnumerable<Vehicle>> ListVehiclesAsync(int? page = null, int? pageSize = null)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Vehicles}");

        return await response.GetContentData<IEnumerable<Vehicle>>() ?? Enumerable.Empty<Vehicle>();
    }

    public async Task<Starship?> GetStarshipAsync(string starshipId)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Starships}/{starshipId}");

        return await response.GetContentData<Starship>();
    }

    public async Task<IEnumerable<Starship>> ListStarshipsAsync(int? page = null, int? pageSize = null)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServicePath.Starships}");

        return await response.GetContentData<IEnumerable<Starship>>() ?? Enumerable.Empty<Starship>();
    }
}


