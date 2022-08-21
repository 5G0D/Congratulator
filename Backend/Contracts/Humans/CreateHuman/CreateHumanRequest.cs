namespace Contracts.Humans.CreateHuman;

public record CreateHumanRequest
{
    public string Birthday { get; set; }
    public string? Name { get; set; }
    public string? Photo { get; set; }
}