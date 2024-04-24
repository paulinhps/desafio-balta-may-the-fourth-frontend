using MyTheFourth.Frontend.Models;

namespace MyTheFourth.Frontend.Services.Interfaces;

public interface ICharactersService
{

    public Task<Character?> GetCharacterAsync(string characterId);
    public Task<IEnumerable<Character>> ListCharactersAsync(int? page = null, int? pageSize = null);
}