namespace MyTheFourth.Frontend.Services.Interfaces;

public interface IMyTheFourthService : IMoviesService,
    ICharactersService,
    IPlanetsService,
    IVehiclesService,
    IStarshipsService
{
    string ServiceId { get; }
}
