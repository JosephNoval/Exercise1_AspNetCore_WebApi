using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Application.MasterData.Interfaces.Services;
public interface ITaskService : IBaseService<TaskDto>
{

    Task<List<TaskDto>> GetByProjectAsync(long projectId);
}
