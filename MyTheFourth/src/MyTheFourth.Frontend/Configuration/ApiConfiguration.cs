public class ApiConfiguration
{
    public string Name { get; set; } = "Nome do Batalhao";
    public string  BaseAddress { get; set; } = "http://www.batalhao.com.br";
    public PathConfiguration Path { get; set; }  = new();
}

public class PathConfiguration
{
    public string Movies { get; set; } = "/api/movies";
    public string Characters { get; set; } = "/api/characters";
    public string Planets { get; set; } = "/api/planets";
    public string Vericles { get; set; } = "/api/vericles";
    public string Starships { get; set; } = "/api/starships";
}