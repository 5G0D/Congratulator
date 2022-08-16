using Contracts.Birthdays.GetBirthdays;

namespace AppServices.Birthdays.Services;

public interface IBirthdayService
{
    Task<GetBirthdaysResponse> GetBirthdays(GetBirthdaysRequest request, CancellationToken cancellation);
}