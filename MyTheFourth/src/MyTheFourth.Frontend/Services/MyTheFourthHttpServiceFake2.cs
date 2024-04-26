using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.Models;

namespace MyTheFourth.Frontend.Services;

public class MyTheFourthHttpServiceFake2 : MyTheFourthHttpServiceFake
{

    public override string ServiceId => BackendServicesIdentifiers.Faker2;
    public override async Task<Starship?> GetStarshipAsync(string starshipId)
    {
        var result = await base.GetStarshipAsync(starshipId);

        if (result != null)
        {
            result.Name = "Resultado do Fake2";
        }

        return result;
    }
}
