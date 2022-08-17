using AppServices.Shared.Repositories;
using AutoMapper;
using Contracts.Humans.Dto;
using Contracts.Humans.GetHumans;
using Domain;
using Microsoft.Extensions.Configuration;

namespace AppServices.Human.Services;

public class HumanService : IHumanService
{
    private readonly IHumanRepository _humanRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public HumanService(IHumanRepository humanRepository, IConfiguration configuration, IMapper mapper)
    {
        _humanRepository = humanRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<GetHumansResponse> GetHumans(GetHumansRequest request, CancellationToken cancellation)
    {
        var humans = _humanRepository.GetAll();

        return new GetHumansResponse
        {
            Humans = _mapper.Map<IEnumerable<HumanEntity>, IEnumerable<HumanDto>>(humans)
        };
    }
}