namespace Domain;

public record Birthday : Entity
{
    public DateTime BirthDay { get; set; }
    public string Name { get; set; } 
    public string Photo { get; set; }
}