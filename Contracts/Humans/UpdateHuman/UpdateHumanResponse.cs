namespace Contracts.Humans.UpdateHuman;

public record UpdateHumanResponse()
{
    public int Id { get; set; }
    public string BirthDay { get; set; } = null!;
    public string? Name { get; set; }
    public string? Photo { get; set; }
}