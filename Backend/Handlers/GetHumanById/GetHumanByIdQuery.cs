using Contracts.GetHumanById;
using MediatR;

namespace Handlers.GetHumanById;

public record GetHumanByIdQuery(GetHumanByIdRequest Request): IRequest<GetHumanByIdResponse>;