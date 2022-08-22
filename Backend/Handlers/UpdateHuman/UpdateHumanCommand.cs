using Contracts.Humans.CreateHuman;
using Contracts.Humans.UpdateHuman;
using MediatR;

namespace Handlers.UpdateHuman;

public record UpdateHumanCommand(UpdateHumanRequest Request): IRequest<UpdateHumanResponse>;