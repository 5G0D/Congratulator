using System.Globalization;
using Domain;
using AutoMapper;
using Contracts.Humans.CreateHuman;
using Contracts.Humans.Dto;
using Contracts.Humans.UpdateHuman;

namespace AppServices.Shared.MapProfiles;

public class HumanMapProfile : Profile
{
    public HumanMapProfile()
    {
        CreateMap<CreateHumanRequest, HumanEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ModifyDate, opt => opt.Ignore())
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => DateTime.ParseExact(src.BirthDay, "dd.mm.yyyy", CultureInfo.InvariantCulture)));

        CreateMap<CreateHumanRequest, CreateHumanResponse>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<UpdateHumanRequest, HumanEntity>()
            .ForMember(dest => dest.ModifyDate, opt => opt.Ignore())
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => DateTime.ParseExact(src.BirthDay, "dd.mm.yyyy", CultureInfo.InvariantCulture)));

        CreateMap<UpdateHumanRequest, UpdateHumanResponse>();
        
        CreateMap<HumanEntity, HumanDto>()
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("dd.MM.yyyy")));
        
    }
}