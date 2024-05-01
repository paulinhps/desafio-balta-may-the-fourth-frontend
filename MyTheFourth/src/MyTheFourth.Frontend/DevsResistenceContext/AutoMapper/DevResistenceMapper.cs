using AutoMapper;
using MyTheFourth.Frontend.DevsResistenceContext.Models;
using MyTheFourth.Frontend.Models;

namespace MyTheFourth.Frontend.DevsResistenceContext.AutoMapper;

public class DevResistenceMapper : Profile
{

    public DevResistenceMapper()
    {

        CreateMap<MovieDataModel, MovieResume>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.Id.ToString()));

        CreateMap<MovieDataModel, Movie>()
        .IncludeBase<MovieDataModel, MovieResume>();

        CreateMap<StarshipDataModel, StarshipResume>();

        CreateMap<StarshipDataModel, Starship>()
        .IncludeBase<StarshipDataModel, StarshipResume>();

        CreateMap<VehicleDataModel, VehicleResume>();

        CreateMap<VehicleDataModel, Vehicle>()
        .IncludeBase<VehicleDataModel, VehicleResume>();

        CreateMap<PlanetDataModel, PlanetResume>();

        CreateMap<PlanetDataModel, Planet>()
       .IncludeBase<PlanetDataModel, PlanetResume>();

        CreateMap<CharacterDataModel, CharacterResume>();

        CreateMap<CharacterDataModel, Character>()
        .IncludeBase<CharacterDataModel, CharacterResume>();




    }
}
