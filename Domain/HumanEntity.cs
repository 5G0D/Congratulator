using System.ComponentModel.DataAnnotations;

namespace Domain;

public record HumanEntity : Entity
{
    [Required]
    public DateTime BirthDay { get; set; }
    [Required, StringLength(200)]
    public string? Name { get; set; }
    public string? Photo { get; set; }
}