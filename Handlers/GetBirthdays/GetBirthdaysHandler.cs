using AppServices.Birthdays.Services;
using Contracts.Birthdays.GetBirthdays;
using MediatR;

namespace Handlers.GetBirthdays;

public class GetBirthdaysHandler : IRequestHandler<GetBirthdaysQuery, GetBirthdaysResponse>
{
    private readonly IBirthdayService _birthdayService;

    public GetBirthdaysHandler(IBirthdayService birthdayService)
    {
        _birthdayService = birthdayService;
    }
    public async Task<GetBirthdaysResponse> Handle(GetBirthdaysQuery request, CancellationToken cancellation)
    {
        return await _birthdayService.GetBirthdays(request.request, cancellation);
    }
}