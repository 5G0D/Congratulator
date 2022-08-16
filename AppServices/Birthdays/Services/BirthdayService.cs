using System.Collections;
using AppServices.Birthdays.Repositories;
using AutoMapper;
using Contracts.Birthdays.GetBirthdays;
using Contracts.Birthdays.GetBirthdays.Dto;
using Domain;

namespace AppServices.Birthdays.Services;

public class BirthdayService : IBirthdayService
{
    private readonly IBirthdayRepository _birthdayRepository;
    private readonly IMapper _mapper;

    BirthdayService(IBirthdayRepository birthdayRepository, IMapper mapper)
    {
        _birthdayRepository = birthdayRepository;
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