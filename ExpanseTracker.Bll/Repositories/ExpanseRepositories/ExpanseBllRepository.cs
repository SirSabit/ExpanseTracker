
using ExpanseTracker.Dal.Repositories.ExpanseRepositories;
using ExpanseTracker.Dto;
using ExpanseTracker.Entities;

namespace ExpanseTracker.Bll.Repositories.ExpanseRepositories
{
    public class ExpanseBllRepository : IExpanseBllRepository
    {
        private readonly IExpanseRepository _expanseRepository;

        public ExpanseBllRepository(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;

        }

        public async Task Insert(ExpanseDto dto)
        {
            try
            {
                var entity = new ExpanseEntity()
                {
                    ID = dto.ID,
                    ExpanseAmount = dto.ExpanseAmount,
                    ExpanseDate = dto.ExpanseDate,
                    ExpanseName = dto.ExpanseName,
                    IsDeleted = dto.IsDeleted
                };
                await _expanseRepository.InsertExpanseAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(ExpanseDto dto)
        {
            try
            {
                var entity = new ExpanseEntity()
                {
                    ID = dto.ID,
                    ExpanseAmount = dto.ExpanseAmount,
                    ExpanseDate = dto.ExpanseDate,
                    ExpanseName = dto.ExpanseName,
                    IsDeleted = dto.IsDeleted
                };

                await _expanseRepository.UpdateExpanseAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(ExpanseDto dto)
        {
            try
            {
                var entity = new ExpanseEntity()
                {
                    ID = dto.ID,
                    ExpanseAmount = dto.ExpanseAmount,
                    ExpanseDate = dto.ExpanseDate,
                    ExpanseName = dto.ExpanseName,
                    IsDeleted = true
                };

                await _expanseRepository.DeleteExpanseAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ExpanseDto> GetById(int Id)
        {
            try
            {
                var data = await _expanseRepository.GetExpanseByIdAsync(Id);

                var dto = new ExpanseDto()
                {
                    ID = data.ID,
                    ExpanseAmount = data.ExpanseAmount,
                    ExpanseDate = data.ExpanseDate.Date,
                    ExpanseName = data.ExpanseName,
                    IsDeleted = data.IsDeleted
                };
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<ExpanseDto>> GetAllExpanses()
        {
            try
            {
                List<ExpanseDto> expanses = new List<ExpanseDto>();
                var data = await _expanseRepository.GetAllExpansesAsync();
                foreach (var item in data)
                {
                    var dto = new ExpanseDto()
                    {
                        ID = item.ID,
                        ExpanseAmount = item.ExpanseAmount,
                        ExpanseDate = item.ExpanseDate,
                        ExpanseName = item.ExpanseName,
                        IsDeleted = item.IsDeleted
                    };

                    expanses.Add(dto);
                }
                return expanses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
