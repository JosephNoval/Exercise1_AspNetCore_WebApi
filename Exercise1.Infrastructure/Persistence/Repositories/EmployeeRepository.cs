using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Exercise1.Domain.Entities.MasterData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Infrastructure.Persistence.Repositories;
internal class EmployeeRepository : IEmployeeRepository
{
    private readonly IAppDataContext _context;
    public EmployeeRepository(IAppDataContext context)
    {
        _context = context;
    }
    public Task<Employee> AddAsync(Employee model)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Set<Employee>().ToListAsync();
    }

    public async Task<Employee> GetAsync(long id)
    {
        return await _context.Set<Employee>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Employee> UpdateAsync(Employee model)
    {
        throw new System.NotImplementedException();
    }
}
