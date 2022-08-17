using Contracts.Humans.CreateHuman;
using Contracts.Humans.DeleteHuman;
using Contracts.Humans.GetHumans;
using Contracts.Humans.UpdateHuman;

namespace AppServices.Human.Services;

public interface IHumanService
{
    Task<GetHumansResponse> GetHumans(GetHumansRequest request, CancellationToken cancellation);
    Task<CreateHumanResponse> CreateHuman(CreateHumanRequest request, CancellationToken cancellationToken);
    Task<DeleteHumanResponse> DeleteHuman(DeleteHumanRequest request, CancellationToken cancellationToken);
    Task<UpdateHumanResponse> UpdateHuman(UpdateHumanRequest request, CancellationToken cancellationToken);
}