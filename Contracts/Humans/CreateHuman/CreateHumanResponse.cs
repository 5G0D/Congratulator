namespace Contracts.Humans.CreateHuman;

public record CreateHumanResponse
{
    public int Id { get; set; }
    public string BirthDay { get; set; }
    public string? Name { get; set; }
    public string? Photo { get; set; }
}