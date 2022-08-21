using Contracts.Humans.CreateHuman;
using MediatR;

namespace Handlers.CreateHuman;

public record CreateHumanCommand(CreateHumanRequest Request): IRequest<CreateHumanResponse>;