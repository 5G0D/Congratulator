namespace Domain;

public record HumanEntity : Entity
{
    public DateTime BirthDay { get; set; }
    public string Name { get; set; } = null!;
    public string? Photo { get; set; }
}