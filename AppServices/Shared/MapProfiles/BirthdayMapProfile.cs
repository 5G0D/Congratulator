﻿using Contracts.Birthdays.GetBirthdays.Dto;
using Domain;
using AutoMapper;

namespace AppServices.Shared.MapProfiles;

public class BirthdayMapProfile : Profile
{
    public BirthdayMapProfile()
    {
        CreateMap<BirthdayEntity, BirthdayDto>()
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("dd.MM.yyyy")));
    }
}