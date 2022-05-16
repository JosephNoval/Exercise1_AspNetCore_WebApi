using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.TaskManagement.Interfaces;
using Exercise1.Domain.Entities.TaskManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise1.Infrastructure.Persistence.Repositories;
internal class EmployeeTaskRepository : IEmployeeTaskRepository
{
    private readonly IAppDataContext _context;
    public EmployeeTaskRepository(IAppDataContext context)
    {
        _context = context;
    }
    public async Task<EmployeeTask> AddAsync(EmployeeTask model)
    {
        _context.Set<EmployeeTask>().Add(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await GetAsync(id);
        _context.Set<EmployeeTaskDetail>().RemoveRange(entity.EmployeeTaskDetails.Where(x => x.EmployeeTaskId == entity.Id));
        _context.Set<EmployeeTask>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<EmployeeTask>> GetAll()
    {
        return await _context.Set<EmployeeTask>()
                             .Include(nameof(EmployeeTask.Project))
                             .Include(nameof(EmployeeTask.Task))
                             .Include(nameof(EmployeeTask.EmployeeTaskDetails))
                             .Include($"{nameof(EmployeeTask.EmployeeTaskDetails)}.{nameof(EmployeeTaskDetail.Employee)}")
                             .ToListAsync();
    }

    public async Task<EmployeeTask> GetAsync(long id)
    {
        return await _context.Set<EmployeeTask>()
                             .Include(nameof(EmployeeTask.Project))
                             .Include(nameof(EmployeeTask.Task))
                             .Include(nameof(EmployeeTask.EmployeeTaskDetails))
                             .Include($"{nameof(EmployeeTask.EmployeeTaskDetails)}.{nameof(EmployeeTaskDetail.Employee)}")
                             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<EmployeeTask> UpdateAsync(EmployeeTask model)
    {
        // get old entity
        var oldEntity = await GetAsync(model.Id);

        // update the header
        _context.Entry(oldEntity).CurrentValues.SetValues(model);

        // remove old details
        _context.Set<EmployeeTaskDetail>().RemoveRange(oldEntity.EmployeeTaskDetails.Where(x => x.EmployeeTaskId == model.Id));
        
        // set new details
        model.EmployeeTaskDetails.ForEach(x => { x.EmployeeTaskId = 0; x.Id = 0; });
        // add new employee task details
        _context.Set<EmployeeTaskDetail>().AddRange(model.EmployeeTaskDetails);

        await _context.SaveChangesAsync();
        return model;
    }
}
