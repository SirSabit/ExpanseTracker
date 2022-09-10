using ExpanseTracker.Dto;

namespace ExpanseTracker.Bll.Repositories.ExpanseRepositories
{
    public interface IExpanseBllRepository
    {
        Task Delete(ExpanseDto dto);
        Task<List<ExpanseDto>> GetAllExpanses();
        Task<ExpanseDto> GetById(int Id);
        Task Insert(ExpanseDto dto);
        Task Update(ExpanseDto dto);
    }
}