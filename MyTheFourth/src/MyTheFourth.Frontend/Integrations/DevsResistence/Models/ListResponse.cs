using System.Text.Json.Serialization;

namespace MyTheFourth.Frontend.Integrations.DevsResistence.Models;

public abstract class ListResponse<T>{
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<T>? Results { get; set; }

    }

public class MovieListResponse : ListResponse<MovieDataModel> {
    
}

public class CharacterListResponse : ListResponse<CharacterDataModel> {
    
}

public class PlanetListResponse : ListResponse<PlanetDataModel> {
    
}

public class StarshipListResponse : ListResponse<StarshipDataModel> {
    
}

public class VehicleListResponse : ListResponse<VehicleDataModel> {
    
}