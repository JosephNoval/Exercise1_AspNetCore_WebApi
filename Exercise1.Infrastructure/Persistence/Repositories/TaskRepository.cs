using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Infrastructure.Persistence.Repositories;
internal class TaskRepository : ITaskRepository
{
    private readonly IAppDataContext _context;
    public TaskRepository(IAppDataContext context)
    {
        _context = context;
    }
    public Task<Domain.Entities.MasterData.Task> AddAsync(Domain.Entities.MasterData.Task model)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Domain.Entities.MasterData.Task>> GetAll()
    {
        return await _context.Set<Domain.Entities.MasterData.Task>()
                             .Include(nameof(Domain.Entities.MasterData.Task.Project))
                             .ToListAsync();
    }

    public async Task<Domain.Entities.MasterData.Task> GetAsync(long id)
    {
        return await _context.Set<Domain.Entities.MasterData.Task>()
                             .Include(nameof(Domain.Entities.MasterData.Task.Project))
                             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Domain.Entities.MasterData.Task> UpdateAsync(Domain.Entities.MasterData.Task model)
    {
        throw new System.NotImplementedException();
    }
}
