namespace MyTheFourth.Frontend.Models;

public class Planet : PlanetResume
{

    public string RotationPeriod { get; set; } = null!;

    public string OrbitalPeriod { get; set; } = null!;

    public string Diameter { get; set; } = null!;

    public string Climate { get; set; } = null!;

    public string Gravity { get; set; } = null!;

    public string Terrain { get; set; } = null!;

    public string SurfaceWater { get; set; } = null!;

    public string Population { get; set; } = null!;

    public List<CharacterResume> Characters { get; set; }

    public List<MovieResume> Movies { get; set; }

    public Planet()
    {
        Characters = new List<CharacterResume>();
        Movies = new List<MovieResume>();
    }
}