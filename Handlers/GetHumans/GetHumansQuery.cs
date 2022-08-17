using Contracts.Humans.GetHumans;
using MediatR;

namespace Handlers.GetHumans;

public record GetHumansQuery(GetHumansRequest Request): IRequest<GetHumansResponse>;