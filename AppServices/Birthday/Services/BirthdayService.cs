using System.Collections;
using AppServices.Birthdays.Repositories;
using AutoMapper;
using Contracts.Birthdays.GetBirthdays;
using Contracts.Birthdays.GetBirthdays.Dto;
using Domain;
using Microsoft.Extensions.Configuration;

namespace AppServices.Birthdays.Services;

public class BirthdayService : IBirthdayService
{
    private readonly IBirthdayRepository _birthdayRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public BirthdayService(IBirthdayRepository birthdayRepository, IConfiguration configuration, IMapper mapper)
    {
        _birthdayRepository = birthdayRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<GetBirthdaysResponse> GetBirthdays(GetBirthdaysRequest request, CancellationToken cancellation)
    {
        var birthdays = _birthdayRepository.GetAll();

        return new GetBirthdaysResponse
        {
            Birthdays = _mapper.Map<IEnumerable<BirthdayEntity>, IEnumerable<BirthdayDto>>(birthdays)
        };
    }
}