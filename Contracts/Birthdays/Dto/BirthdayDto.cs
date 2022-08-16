namespace Contracts.Birthdays.GetBirthdays.Dto;

public class BirthdayDto
{
    public int Id { get; set; }
    public DateTime ModifyDate { get; set; }
    public DateTime BirthDay { get; set; }
    public string Name { get; set; } = null!;
    public string? Photo { get; set; }
}