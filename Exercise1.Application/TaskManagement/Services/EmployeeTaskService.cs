using AutoMapper;
using Exercise1.Application.TaskManagement.Dtos;
using Exercise1.Application.TaskManagement.Interfaces;
using Exercise1.Application.TaskManagement.Validators;
using Exercise1.Domain.Entities.TaskManagement;
using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1.Application.TaskManagement.Services;
internal class EmployeeTaskService : IEmployeeTaskService
{
    private readonly IEmployeeTaskRepository _employeeTaskRepository;
    private readonly IMapper _mapper;
    public EmployeeTaskService(IEmployeeTaskRepository employeeTaskRepository, IMapper mapper)
    {
        _employeeTaskRepository = employeeTaskRepository;
        _mapper = mapper;
    }
    public async Task<EmployeeTaskDto> AddAsync(EmployeeTaskDto model)
    {
        var validator = new EmployeeTaskValidator();
        var validatorResult = validator.Validate(model);
        if (!validatorResult.IsValid)
            throw new ValidationException(validatorResult.Errors);
        model.Project = null;
        model.Task = null;
        model.EmployeeTaskDetails.ForEach(x => { x.Employee = null; });
        var result = await _employeeTaskRepository.AddAsync(_mapper.Map<EmployeeTask>(model));

        return _mapper.Map<EmployeeTaskDto>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        if (await GetAsync(id) == null)
            throw new ArgumentException($"Employee Task Id '{id}' not found");
        return await _employeeTaskRepository.DeleteAsync(id);
    }

    public async Task<List<EmployeeTaskDto>> GetAll(string filter = "")
    {
        var res = await _employeeTaskRepository.GetAll();
        if (String.IsNullOrEmpty(filter))
            return _mapper.Map<List<EmployeeTaskDto>>(res);
        return _mapper.Map<List<EmployeeTaskDto>>(res.Where(x => x.Project.Name.ToLower().Contains(filter.ToLower()) ||
                                                                 x.Task.Name.ToLower().Contains(filter.ToLower())).ToList());
    }

    public async Task<EmployeeTaskDto> GetAsync(long id)
    {
        var result = await _employeeTaskRepository.GetAsync(id);
        return _mapper.Map<EmployeeTaskDto>(result);
    }

    public async Task<EmployeeTaskDto> UpdateAsync(EmployeeTaskDto model)
    {
        var validator = new EmployeeTaskValidator();
        var validatorResult = validator.Validate(model);
        if (!validatorResult.IsValid)
            throw new ValidationException(validatorResult.Errors);
        if (await GetAsync(model.Id) == null)
            throw new ArgumentException($"Employee Task Id '{model.Id}' not found");
        model.Project = null;
        model.Task = null;
        model.EmployeeTaskDetails.ForEach(x => { x.Employee = null; });
        var result = await _employeeTaskRepository.UpdateAsync(_mapper.Map<EmployeeTask>(model));
        return _mapper.Map<EmployeeTaskDto>(result);
    }
}
