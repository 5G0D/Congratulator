using AppServices.Human.Services;
using Contracts.Humans.CreateHuman;
using Contracts.Humans.GetHumans;
using Handlers.GetHumans;
using MediatR;

namespace Handlers.CreateHuman;

public class CreateHumanHandler: IRequestHandler<CreateHumanCommand, CreateHumanResponse>
{
    private readonly IHumanService _humanService;

    public CreateHumanHandler(IHumanService humanService)
    {
        _humanService = humanService;
    }
    public async Task<CreateHumanResponse> Handle(CreateHumanCommand request, CancellationToken cancellation)
    {
        return await _humanService.CreateHuman(request.Request, cancellation);
    }
}