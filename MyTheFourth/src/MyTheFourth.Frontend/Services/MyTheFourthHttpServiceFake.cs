using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.Models;
using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.Services;

public class MyTheFourthHttpServiceFake :
    IMyTheFourthService
{

    public virtual string ServiceId => BackendServicesIdentifiers.Faker;
    private static Movie[] _movies = [
        new()
        {
            Id = 1,
            Slug = "the-rise-of-the-jedi",
            Title = "The Rise of the Jedi",
            Episode = 10,
            OpeningCrawl = @"Lorem, ipsum dolor sit amet consectetur adipisicing elit. Temporibus, ab alias minima perspiciatis, totam impedit eveniet nulla voluptatibus ad tempora sunt, nisi amet dolorem voluptate. Quae maiores optio magnam beatae!
Ducimus harum voluptatibus neque hic atque natus, aspernatur eaque non nam minus illum voluptate ipsam doloribus ipsum inventore commodi. Veritatis laudantium consequatur omnis iste optio autem facilis impedit similique? Consequuntur.
Ipsam saepe non ratione, odio exercitationem sit, pariatur architecto nemo quae dolor et voluptatem dolorum, deserunt nam. Quaerat, molestias hic. Nostrum magnam, eum delectus quas ad possimus accusamus maxime iure!
Obcaecati, fuga itaque quia reiciendis ab, inventore aliquam iste alias sit adipisci nulla officia illo animi at delectus est? Ea debitis nulla repudiandae ab magni laboriosam pariatur, doloremque porro explicabo.
Maiores laborum dolores dolorem neque suscipit excepturi animi vitae porro nemo repudiandae a, eveniet minima, dignissimos totam eius repellendus. Accusantium minima voluptatibus quod fuga corporis laboriosam ullam ea at animi.",
            Director = "Jana Doe",
            Producer = "Leo Smith",
            ReleaseDate = Convert.ToDateTime("2028-12-15"),
            Characters = [
                new()
                {
                    Id = 1,
                    Name = "Kara Zor-El",
                },
                new()
                {
                    Id = 2,
                    Name = "Mara Jade",
                },
                new()
                {
                    Id = 3,
                    Name = "Thrawn",
                },
                new()
                {
                    Id = 4,
                    Name = "R2-D2",
                }
            ],
            Planets = [
                new()
                {
                    Id = 1,
                    Name = "Coruscant"
                },
                new()
                {
                    Id = 2,
                    Name = "Tatooine"
                },
                new()
                {
                    Id = 3,
                    Name = "Dagobah"
                }
            ],
            Vehicles = [
                new()
                {
                    Id = 1,
                    Name = "Speeder Bikes"
                },
                new()
                {
                    Id = 2,
                    Name = "AT-AT Walkers"
                }
            ],
            Starships = [
                new()
                {
                    Id = 1,
                    Name = "Millennium Falcon"
                },
                new()
                {
                    Id = 2,
                    Name = "X-wing"
                },
                new()
                {
                    Id = 3,
                    Name = "TIE Fighter"
                }
            ]

        }
    ];
    private static Character[] _characters = [
        new()
        {
            Id = 1,
            Name = "Zara Kell",
            Height = "172 cm",
            Weight = "68 kg",
            HairColor = "black",
            SkinColor = "tan",
            EyeColor = "green",
            BirthYear = "242 ABY",
            Gender = "female",
            Planet = new()
            {
                Id = 1,
                Name = "Tatooine"
            },
            Movies = [
                new()
                {
                    Id = 1,
                    Title = "The Battle of the Stars"
                },
                new()
                {
                    Id = 2,
                    Title = "Return of the Light"
                },
                new()
                {
                    Id = 3,
                    Title = "Warriors of the Shadow Realm"
                }
            ]
        }
    ];
    private static Planet[] _planets = [
        new()
        {
            Id = 1,
            Name = "Planetara",
            RotationPeriod = "24 hours",
            OrbitalPeriod = "365 days",
            Diameter = "12742 km",
            Climate = "temperate",
            Gravity = "1 standard",
            Terrain = "forests, mountains, rivers",
            SurfaceWater = "70%",
            Population = "2 billion",
            Characters = [
                new()
                {
                    Id = 1,
                    Name = "Zara Kell",
                },
                new()
                {
                    Id = 2,
                    Name = "Tora Ziyal",
                },
                new()
                {
                    Id = 3,
                    Name = "Finn Varra",
                }
            ],
            Movies = [
                new()
                {
                    Id = 1,
                    Title = "The Galactic Quest"
                },
                new()
                {
                    Id = 2,
                    Title = "Rise of the Planetara"
                },
                new()
                {
                    Id = 3,
                    Title = "Echoes of the Stars"
                }
            ]
        }
    ];
    private static Vehicle[] _vehicles = [
        new()
        {
            Id = 1,
            Name = "Star Voyager",
            ImgUrl = "",
            Model = "SV-2",
            Manufacturer = "Galactic Starcraft",
            CostInCredits = "500000",
            Length = "120 meters",
            MaxSpeed = "950 km/h",
            Crew = "5",
            Passengers = "30",
            CargoCapacity = "150000 kg",
            Consumables = "2 years",
            Class = "Cruiser",
            Movies = [
                new()
                {
                    Id = 1,
                    Title = "The Return of the Voyager",
                },
                new()
                {
                    Id = 2,
                    Title = "Voyager's Endgame",
                }
            ]
        }
    ];
    private static Starship[] _starships = [
        new()
        {
            Id = 1,
            Name = "Galactic Explorer",
            Slug = "galactic-explorer",
            ImgUrl = "/images/sample/starship-galactic-explorer.jpg",
            Model = "GX-3",
            Manufacturer = "Interstellar Shipworks",
            CostInCredits = "800000",
            Length = "85 meters",
            MaxSpeed = "880 km/h",
            Crew = "10",
            Passengers = "40",
            CargoCapacity = "200000 kg",
            HyperdriveRating = "1.5",
            Mglt = "70",
            Consumables = "6 months",
            Class = "Explorer",
            Movies = [
                new()
                {
                    Id = 1,
                    Title = "Galactic Odyssey"
                },
                new()
                {
                    Id = 2,
                    Title = "The Edge of the Universe"
                }
            ]
        }
    ];
    public async Task<Movie?> GetMovieAsync(string movieId)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _movies.FirstOrDefault(x => x.Id == int.Parse(movieId));
    }

    public async Task<IEnumerable<Movie>> ListMoviesAsync(int? page = null, int? pageSize = null)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _movies;
    }

    public async Task<Character?> GetCharacterAsync(string characterId)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _characters.FirstOrDefault(x => x.Id == int.Parse(characterId));
    }

    public async Task<IEnumerable<Character>> ListCharactersAsync(int? page = null, int? pageSize = null)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _characters;
    }

    public async Task<Planet?> GetPlanetAsync(string planetId)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _planets.FirstOrDefault(x => x.Id == int.Parse(planetId));
    }

    public async Task<IEnumerable<Planet>> ListPlanetsAsync(int? page = null, int? pageSize = null)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _planets;
    }

    public async Task<Vehicle?> GetVehicleAsync(string vehicleId)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _vehicles.FirstOrDefault(x => x.Id == int.Parse(vehicleId));
    }

    public async Task<IEnumerable<Vehicle>> ListVehiclesAsync(int? page = null, int? pageSize = null)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _vehicles;
    }

    public async virtual Task<Starship?> GetStarshipAsync(string starshipId)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _starships.FirstOrDefault(x => x.Slug?.Equals(starshipId) is true || (int.TryParse(starshipId, out var id) && x.Id == id));
    }

    public async Task<IEnumerable<Starship>> ListStarshipsAsync(int? page = null, int? pageSize = null)
    {
        await Task.Delay(Random.Shared.Next(500, 5000));

        return _starships;
    }


}