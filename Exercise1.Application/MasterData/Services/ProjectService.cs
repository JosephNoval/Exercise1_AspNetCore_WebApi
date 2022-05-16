using AutoMapper;
using Exercise1.Application.MasterData.Dtos;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Exercise1.Application.MasterData.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise1.Application.MasterData.Services;
internal class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    public Task<ProjectDto> AddAsync(ProjectDto model)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<ProjectDto>> GetAll(string filter = "")
    {
        var res = await _projectRepository.GetAll();
        if (String.IsNullOrEmpty(filter))
            return _mapper.Map<List<ProjectDto>>(res);
        return _mapper.Map<List<ProjectDto>>(res.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList());
    }

    public async Task<ProjectDto> GetAsync(long id)
    {
        var result = await _projectRepository.GetAsync(id);
        return _mapper.Map<ProjectDto>(result);
    }

    public Task<ProjectDto> UpdateAsync(ProjectDto model)
    {
        throw new System.NotImplementedException();
    }
}
