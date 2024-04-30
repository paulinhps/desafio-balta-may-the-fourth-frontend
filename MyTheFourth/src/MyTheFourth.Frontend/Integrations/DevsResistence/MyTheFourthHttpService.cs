using AutoMapper;
using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.Extensions;
using MyTheFourth.Frontend.Integrations.DevsResistence.Models;
using MyTheFourth.Frontend.Models;
using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.Integrations.DevsResistence;

public static class MyTheFourthHttpServiceEndpoints {
    public const string MoviesEndpoint = "/movies";
    public const string CharacterEndpoint = "/characters";
}


public class MyTheFourthHttpService :
IMyTheFourthService
{
    private readonly HttpClient _client;
    private readonly IMapper _mapper;

    public MyTheFourthHttpService(HttpClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public string ServiceId => BackendServicesIdentifiers.DevResistence;

    public async Task<Character?> GetCharacterAsync(string characterId)
    {
        var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.CharacterEndpoint}/{characterId}");

            var result = await response.GetContentData<CharacterDataModel>();

            return  result is not null ? _mapper.Map<Character>(result) : default!;
    }

    public async Task<Movie?> GetMovieAsync(string movieId)
    {
            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}/{movieId}");

            var result = await response.GetContentData<MovieDataModel>();

            return  result is not null ? _mapper.Map<Movie>(result) : default!;
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

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.CharacterEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<CharacterListResponse>();

            return  result?.Results?.Any() is true ? _mapper.Map<IEnumerable<Character>>(result.Results) : Enumerable.Empty<Character>();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
            return Enumerable.Empty<Character>();
    }

    public async Task<IEnumerable<Movie>> ListMoviesAsync(int? page = null, int? pageSize = null)
    {
        try
        {

            var response = await _client.GetAsync($"{MyTheFourthHttpServiceEndpoints.MoviesEndpoint}?pageNumber={page ?? 1}&pageSize={pageSize ?? 10}");

            var result = await response.GetContentData<MovieListResponse>();

            return  result?.Results?.Any() is true ? _mapper.Map<IEnumerable<Movie>>(result.Results) : Enumerable.Empty<Movie>();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);

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

public class DevResistenceMapper : Profile {

    public DevResistenceMapper() {

        CreateMap<MovieDataModel, MovieResume>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.Id.ToString()));

        CreateMap<MovieDataModel, Movie>()
        .IncludeBase<MovieDataModel, MovieResume>();

        CreateMap<StarshipDataModel, StarshipResume>();

        CreateMap<VehicleDataModel, VehicleResume>();

        CreateMap<PlanetDataModel, PlanetResume>();

        CreateMap<CharacterDataModel, CharacterResume>();

        CreateMap<CharacterDataModel, Character>()
        .IncludeBase<CharacterDataModel, CharacterResume>();

        



    }
}
