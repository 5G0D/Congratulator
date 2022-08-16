using System.Linq.Expressions;
using AppServices.Birthdays.Repositories;
using Domain;

namespace DataAccess.Repositories;

public class BirthdayRepository : IBirthdayRepository
{
    private readonly IRepository<BirthdayEntity> _birthdayRepository;

    public BirthdayRepository(IRepository<BirthdayEntity> birthdayRepository)
    {
        _birthdayRepository = birthdayRepository;
    }

    public Task<BirthdayEntity> GetByIdAsync(int userId, CancellationToken cancellation)
    {
        return _birthdayRepository.FindAsync(userId, cancellation);
    }

    public IQueryable<BirthdayEntity> Where(Expression<Func<BirthdayEntity, bool>> predicate)
    {
        return _birthdayRepository.Where(predicate);
    }

    public async Task<int> AddAsync(BirthdayEntity birthday, CancellationToken cancellation)
    {
        return await _birthdayRepository.AddAsync(birthday, cancellation);
    }

    public async Task AddRangeAsync(IEnumerable<BirthdayEntity> birthdays, CancellationToken cancellation)
    {
        await _birthdayRepository.AddRangeAsync(birthdays, cancellation);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellation)
    {
        await _birthdayRepository.DeleteAsync(id, false, cancellation);
    }

    public async Task UpdateAsync(BirthdayEntity birthday, CancellationToken cancellation)
    {
        await _birthdayRepository.UpdateAsync(birthday, cancellation);
    }

    public IQueryable<BirthdayEntity> GetAll()
    {
        return _birthdayRepository.Query();
    }
}