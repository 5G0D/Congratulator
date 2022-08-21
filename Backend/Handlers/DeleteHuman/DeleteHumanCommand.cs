using Contracts.Humans.CreateHuman;
using Contracts.Humans.DeleteHuman;
using MediatR;

namespace Handlers.DeleteHuman;

public record DeleteHumanCommand(DeleteHumanRequest Request): IRequest<DeleteHumanResponse>;