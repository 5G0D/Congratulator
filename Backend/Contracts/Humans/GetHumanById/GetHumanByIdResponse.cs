namespace Contracts.GetHumanById;

public record GetHumanByIdResponse
{
    public int Id { get; set; }
    public string Birthday { get; set; } = null!;
    public string? Name { get; set; }
    public string? Photo { get; set; }
    public string NextBirthday { get; set; } = null!;
}