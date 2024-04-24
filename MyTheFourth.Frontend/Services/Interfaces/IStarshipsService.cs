using MyTheFourth.Frontend.Models;

namespace MyTheFourth.Frontend.Services.Interfaces;

public interface IStarshipsService
{

    public Task<Starship?> GetStarshipAsync(string starshipId);
    public Task<IEnumerable<Starship>> ListStarshipsAsync(int? page = null, int? pageSize = null);
}