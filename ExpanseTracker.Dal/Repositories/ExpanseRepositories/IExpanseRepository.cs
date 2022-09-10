using ExpanseTracker.Entities;

namespace ExpanseTracker.Dal.Repositories.ExpanseRepositories
{
    public interface IExpanseRepository
    {
        Task DeleteExpanseAsync(ExpanseEntity entity);
        Task<IEnumerable<ExpanseEntity>> GetAllExpansesAsync();
        Task<ExpanseEntity> GetExpanseByIdAsync(int id);
        Task InsertExpanseAsync(ExpanseEntity entity);
        Task UpdateExpanseAsync(ExpanseEntity entity);
    }
}