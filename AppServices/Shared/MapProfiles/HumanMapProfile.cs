using Domain;
using AutoMapper;
using Contracts.Humans.Dto;

namespace AppServices.Shared.MapProfiles;

public class HumanMapProfile : Profile
{
    public HumanMapProfile()
    {
        CreateMap<HumanEntity, HumanDto>()
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("dd.MM.yyyy")));
    }
}