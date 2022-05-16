using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Application.Common.Interfaces;
public interface IBaseService<T> where T : class
{
    Task<bool> DeleteAsync(long id);
    Task<T> GetAsync(long id);
    Task<List<T>> GetAll(string filter="");
    Task<T> AddAsync(T model);
    Task<T> UpdateAsync(T model);
}
