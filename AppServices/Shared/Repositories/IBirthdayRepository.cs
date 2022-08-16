using System.Linq.Expressions;
using Domain;

namespace AppServices.Birthdays.Repositories;

public interface IBirthdayRepository
{
    Task<BirthdayEntity> GetByIdAsync(int id, CancellationToken cancellation);
    IQueryable<BirthdayEntity> Where(Expression<Func<BirthdayEntity, bool>> predicate);
    Task<int> AddAsync(BirthdayEntity birthday, CancellationToken cancellation);
    Task AddRangeAsync(IEnumerable<BirthdayEntity> birthdays, CancellationToken cancellation);
    Task DeleteAsync(int id, CancellationToken cancellation);
    Task UpdateAsync(BirthdayEntity category, CancellationToken cancellation);
    IQueryable<BirthdayEntity> GetAll();
}