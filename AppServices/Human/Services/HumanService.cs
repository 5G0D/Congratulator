using AppServices.Shared.Repositories;
using AutoMapper;
using Contracts.Humans.CreateHuman;
using Contracts.Humans.DeleteHuman;
using Contracts.Humans.Dto;
using Contracts.Humans.GetHumans;
using Contracts.Humans.UpdateHuman;
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

    public async Task<CreateHumanResponse> CreateHuman(CreateHumanRequest request, CancellationToken cancellationToken)
    {
        var human = _mapper.Map<HumanEntity>(request);
        var humanId = await _humanRepository.AddAsync(human, cancellationToken);

        var createHumanResponse = _mapper.Map<CreateHumanResponse>(request);
        createHumanResponse.Id = humanId;

        return createHumanResponse;
    }
    
    public async Task<DeleteHumanResponse> DeleteHuman(DeleteHumanRequest request, CancellationToken cancellationToken)
    {
        await _humanRepository.DeleteAsync(request.Id, cancellationToken);
        
        return new DeleteHumanResponse();
    }
    
    public async Task<UpdateHumanResponse> UpdateHuman(UpdateHumanRequest request, CancellationToken cancellationToken)
    {
        await _humanRepository.UpdateAsync(_mapper.Map<HumanEntity>(request), cancellationToken);

        return _mapper.Map<UpdateHumanResponse>(request);
    }
}