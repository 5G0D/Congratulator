using Contracts.Birthdays.GetBirthdays.Dto;

namespace Contracts.Birthdays.GetBirthdays;

public class GetBirthdaysResponse
{
    public IEnumerable<BirthdayDto> Birthdays { get; set; } = null!;
}