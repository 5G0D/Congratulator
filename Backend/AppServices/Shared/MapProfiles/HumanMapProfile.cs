using System.Globalization;
using AppServices.Human.Helpers;
using Domain;
using AutoMapper;
using Contracts.GetHumanById;
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
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.ParseExact(src.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

        CreateMap<CreateHumanRequest, CreateHumanResponse>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.NextBirthday, opt => opt.MapFrom(src => HumanHelper.GetNextBirthday(DateTime.ParseExact(src.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture)).ToString("dd.MM.yyyy")));

        CreateMap<UpdateHumanRequest, HumanEntity>()
            .ForMember(dest => dest.ModifyDate, opt => opt.Ignore())
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.ParseExact(src.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

        CreateMap<UpdateHumanRequest, UpdateHumanResponse>()
            .ForMember(dest => dest.NextBirthday, opt => opt.MapFrom(src => HumanHelper.GetNextBirthday(DateTime.ParseExact(src.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture)).ToString("dd.MM.yyyy")));
        
        CreateMap<HumanEntity, HumanDto>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToString("dd.MM.yyyy")))
            .ForMember(dest => dest.NextBirthday, opt => opt.MapFrom(src => HumanHelper.GetNextBirthday(src.Birthday).ToString("dd.MM.yyyy")));
        
        CreateMap<HumanEntity, GetHumanByIdResponse>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToString("dd.MM.yyyy")))
            .ForMember(dest => dest.NextBirthday, opt => opt.MapFrom(src => HumanHelper.GetNextBirthday(src.Birthday).ToString("dd.MM.yyyy")));

    }
}