using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Exercise1.Domain.Entities.MasterData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Infrastructure.Persistence.Repositories;
internal class ProjectRepository : IProjectRepository
{
    private readonly IAppDataContext _context;
    public ProjectRepository(IAppDataContext context)
    {
        _context = context;
    }
    public Task<Project> AddAsync(Project model)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Project>> GetAll()
    {
        return await _context.Set<Project>().ToListAsync();
    }

    public async Task<Project> GetAsync(long id)
    {
        return await _context.Set<Project>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Project> UpdateAsync(Project model)
    {
        throw new System.NotImplementedException();
    }
}
