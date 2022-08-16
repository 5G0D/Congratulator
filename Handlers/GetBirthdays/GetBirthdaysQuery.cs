using Contracts.Birthdays.GetBirthdays;
using MediatR;

namespace Handlers.GetBirthdays;

public record GetBirthdaysQuery(GetBirthdaysRequest request): IRequest<GetBirthdaysResponse>;