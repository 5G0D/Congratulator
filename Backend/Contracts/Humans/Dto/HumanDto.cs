namespace Contracts.Humans.Dto;

public class HumanDto
{
    public int Id { get; set; }
    public string Birthday { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Photo { get; set; }
    public string NextBirthday { get; set; } = null!;
}