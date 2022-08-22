using Contracts.Humans.Dto;

namespace Contracts.Humans.GetHumans;

public record GetHumansResponse
{
    public IEnumerable<HumanDto> Humans { get; set; } = null!;
}