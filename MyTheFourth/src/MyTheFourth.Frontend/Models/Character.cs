namespace MyTheFourth.Frontend.Models;

public class Character : CharacterResume
{

    public string Height { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string HairColor { get; set; } = null!;

    public string SkinColor { get; set; } = null!;

    public string EyeColor { get; set; } = null!;

    public string BirthYear { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public PlanetResume Planet { get; set; } = null!;

    public List<MovieResume> Movies { get; set; }

    public Character()
    {
        Movies = new List<MovieResume>();
    }
}