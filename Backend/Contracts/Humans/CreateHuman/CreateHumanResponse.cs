namespace Contracts.Humans.CreateHuman;

public record CreateHumanResponse
{
    public int Id { get; set; }
    public string Birthday { get; set; } = null!;
    public string? Name { get; set; }
    public string? Photo { get; set; }
    public string NextBirthday { get; set; } = null!;
}