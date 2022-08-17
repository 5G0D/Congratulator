using Contracts.Humans.GetHumans;

namespace AppServices.Human.Services;

public interface IHumanService
{
    Task<GetHumansResponse> GetHumans(GetHumansRequest request, CancellationToken cancellation);
}