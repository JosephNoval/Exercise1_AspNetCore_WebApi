using Exercise1.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Application.Common.Interfaces;
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<bool> DeleteAsync(long id);
    Task<T> GetAsync(long id);
    Task<List<T>> GetAll();
    Task<T> AddAsync(T model);
    Task<T> UpdateAsync(T model);
}
