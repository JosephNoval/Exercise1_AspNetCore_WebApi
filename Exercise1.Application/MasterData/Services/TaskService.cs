using AutoMapper;
using Exercise1.Application.MasterData.Dtos;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Exercise1.Application.MasterData.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise1.Application.MasterData.Services;
internal class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;
    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    public Task<TaskDto> AddAsync(TaskDto model)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<TaskDto>> GetAll(string filter = "")
    {
        var res = await _taskRepository.GetAll();
        if (String.IsNullOrEmpty(filter))
            return _mapper.Map<List<TaskDto>>(res);
        return _mapper.Map<List<TaskDto>>(res.Where(x => x.Name.ToLower().Contains(filter.ToLower()) ||
                                                                 x.Project.Name.ToLower().Contains(filter.ToLower())).ToList());
    }

    public async Task<TaskDto> GetAsync(long id)
    {
        var result = await _taskRepository.GetAsync(id);
        return _mapper.Map<TaskDto>(result);
    }

    public async Task<List<TaskDto>> GetByProjectAsync(long projectId)
    {
        var result = await _taskRepository.GetAll();
        return _mapper.Map<List<TaskDto>>(result.Where(x => x.ProjectId == projectId).ToList());
    }

    public Task<TaskDto> UpdateAsync(TaskDto model)
    {
        throw new System.NotImplementedException();
    }
}
