using BlazorBootstrap;

public struct PagesNavigationModule(EPagesNavigationsKey moduleKey, string Name, IEnumerable<BreadcrumbItem> navigationItems)
{


    public EPagesNavigationsKey ModuleKey { get; } = moduleKey;
    public string Name { get; } = Name;
    public IEnumerable<BreadcrumbItem> NavigationItems { get; } = navigationItems;

    public static implicit operator PagesNavigationModule(EPagesNavigationsKey moduleKey)
        => GetAvaliablesModules().First(i => i.ModuleKey == moduleKey);

    private static PagesNavigationModule None = new(EPagesNavigationsKey.None, string.Empty, []);
    private static PagesNavigationModule Home = new(
            EPagesNavigationsKey.Home,
            "Início",
            [new BreadcrumbItem { Text = "Início", Href = "/" }]);

    private static PagesNavigationModule Movies = new(
        EPagesNavigationsKey.Movies,
        "Filmes",
        [.. Home.NavigationItems, new BreadcrumbItem { Text = "Filmes", Href = "/movies" }]);

    private static PagesNavigationModule Characters = new(
        EPagesNavigationsKey.Characters,
        "Personagens",
        [.. Home.NavigationItems, new BreadcrumbItem { Text = "Personagens", Href = "/characters" }]);

    private static PagesNavigationModule Planets = new(
        EPagesNavigationsKey.Planets,
        "Planetas",
        [.. Home.NavigationItems, new BreadcrumbItem { Text = "Planetas", Href = "/planets" }]);

    private static PagesNavigationModule Vericles = new(
        EPagesNavigationsKey.Vehicles,
        "Veículos",
        [.. Home.NavigationItems, new BreadcrumbItem { Text = "Veiculos", Href = "/vericles" }]);

    private static PagesNavigationModule Starships = new(
        EPagesNavigationsKey.Starships,
        "Naves Espaciais",
        [.. Home.NavigationItems, new BreadcrumbItem { Text = "Naves Espaciais", Href = "/starships" }]);


    private static IEnumerable<PagesNavigationModule> GetAvaliablesModules()
    {
        yield return None;
        yield return Home;
        yield return Movies;
        yield return Characters;
        yield return Planets;
        yield return Vericles;
        yield return Starships;
    }
}

public enum EPagesNavigationsKey
{
    None,
    Home,
    Movies,
    Characters,
    Planets,
    Vehicles,
    Starships,

}