namespace Contracts.Humans.CreateHuman;

public record CreateHumanRequest
{
    public string BirthDay { get; set; }
    public string? Name { get; set; }
    public string? Photo { get; set; }
}