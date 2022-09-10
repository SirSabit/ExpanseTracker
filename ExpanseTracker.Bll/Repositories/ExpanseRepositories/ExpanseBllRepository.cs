
using ExpanseTracker.Dal.Repositories.ExpanseRepositories;
using ExpanseTracker.Dto;
using ExpanseTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Update(ExpanseDto dto)
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

        public async Task Delete(ExpanseDto dto)
        {
            var entity = new ExpanseEntity()
            {
                ID = dto.ID,
                ExpanseAmount = dto.ExpanseAmount,
                ExpanseDate = dto.ExpanseDate,
                ExpanseName = dto.ExpanseName,
                IsDeleted = dto.IsDeleted
            };

            await _expanseRepository.DeleteExpanseAsync(entity);
        }

        public async Task<ExpanseDto> GetById(int Id)
        {
            var data = await _expanseRepository.GetExpanseByIdAsync(Id);

            var dto = new ExpanseDto()
            {
                ID = data.ID,
                ExpanseAmount = data.ExpanseAmount,
                ExpanseDate = data.ExpanseDate,
                ExpanseName = data.ExpanseName,
                IsDeleted = data.IsDeleted
            };

            return dto;
        }

        public async Task<List<ExpanseDto>> GetAllExpanses()
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
    }
}
