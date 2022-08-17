using Contracts.Humans.Dto;

namespace Contracts.Humans.GetHumans;

public class GetHumansResponse
{
    public IEnumerable<HumanDto> Humans { get; set; } = null!;
}