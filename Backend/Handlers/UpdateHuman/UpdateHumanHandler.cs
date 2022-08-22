using AppServices.Human.Services;
using Contracts.Humans.CreateHuman;
using Contracts.Humans.GetHumans;
using Contracts.Humans.UpdateHuman;
using Handlers.CreateHuman;
using Handlers.GetHumans;
using MediatR;

namespace Handlers.UpdateHuman;

public class UpdateHumanHandler: IRequestHandler<UpdateHumanCommand, UpdateHumanResponse>
{
    private readonly IHumanService _humanService;

    public UpdateHumanHandler(IHumanService humanService)
    {
        _humanService = humanService;
    }
    public async Task<UpdateHumanResponse> Handle(UpdateHumanCommand request, CancellationToken cancellation)
    {
        return await _humanService.UpdateHuman(request.Request, cancellation);
    }
}