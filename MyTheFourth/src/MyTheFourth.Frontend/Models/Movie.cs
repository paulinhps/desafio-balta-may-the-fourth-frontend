using MyTheFourth.Frontend.DevsResistenceContext.Models;
using MyTheFourth.Frontend.Extensions;

namespace MyTheFourth.Frontend.Models;

public class Movie : MovieResume
{
    public int Episode { get; set; }

    public string OpeningCrawl { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Producer { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public IEnumerable<CharacterResume> Characters { get; set; }

    public IEnumerable<PlanetResume> Planets { get; set; }

    public IEnumerable<VehicleResume> Vehicles { get; set; }

    public IEnumerable<StarshipResume> Starships { get; set; }

    public Movie()
    {
        Characters = new List<CharacterResume>();
        Planets = new List<PlanetResume>();
        Vehicles = new List<VehicleResume>();
        Starships = new List<StarshipResume>();
    }

    public static Movie ConvertMovie(MovieDataModel result)
    {
        Movie movie = new Movie()
        {
            Id = result.Id.ToString(),
            ImgUrl = string.Empty,
            Slug = string.Empty,
            Title = result.Title,
            Episode = result.Episode,
            OpeningCrawl = result.OpeningCrawl,
            Director = result.Director,
            Producer = result.Producer,
            ReleaseDate = result.ReleaseDate.DateToPtBR(),
            Characters = result.Characters.Select(character => new CharacterResume
                {
                    Id = character.Id.ToString(),
                    ImgUrl = string.Empty,
                    Slug = string.Empty,
                    Name = character.Name,
                }).ToList(),
            Planets = result.Planets.Select(planet => new PlanetResume
                {
                    Id = planet.Id.ToString(),
                    ImgUrl = string.Empty,
                    Slug = string.Empty,
                    Name = planet.Name,
                }).ToList(),
            Vehicles = result.Vehicles.Select(vehicle => new VehicleResume
                {
                    Id = vehicle.Id.ToString(),
                    ImgUrl = string.Empty,
                    Slug = string.Empty,
                    Name = vehicle.Name,
                }).ToList(),
            Starships = result.Starships.Select(starship => new StarshipResume
                {
                    Id = starship.Id.ToString(),
                    ImgUrl = string.Empty,
                    Slug = string.Empty,
                    Name = starship.Name,
                }).ToList(),
        };

        return movie;
    }

    public static List<Movie> ConvertListCharacter(MovieListResponse result)
    {
        if (result.Results is null)
            return new List<Movie>();

        return 
            result.Results.Select(movie => new Movie
            {
                Id = movie.Id.ToString(),
                ImgUrl = string.Empty,
                Slug = string.Empty,
                Title = movie.Title,
                Episode = movie.Episode,
                OpeningCrawl = movie.OpeningCrawl,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate.DateToPtBR(),
                Characters = movie.Characters.Select(character => new CharacterResume
                    {
                        Id = character.Id.ToString(),
                        ImgUrl = string.Empty,
                        Slug = string.Empty,
                        Name = character.Name,
                    }).ToList(),
                Planets = movie.Planets.Select(planet => new PlanetResume
                    {
                        Id = planet.Id.ToString(),
                        ImgUrl = string.Empty,
                        Slug = string.Empty,
                        Name = planet.Name,
                    }).ToList(),
                Vehicles = movie.Vehicles.Select(vehicle => new VehicleResume
                    {
                        Id = vehicle.Id.ToString(),
                        ImgUrl = string.Empty,
                        Slug = string.Empty,
                        Name = vehicle.Name,
                    }).ToList(),
                Starships = movie.Starships.Select(starship => new StarshipResume
                    {
                        Id = starship.Id.ToString(),
                        ImgUrl = string.Empty,
                        Slug = string.Empty,
                        Name = starship.Name,
                    }).ToList(),
            }).ToList();
    }
}