using AutoMapper;
using Exercise1.Application.MasterData.Dtos;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Exercise1.Application.MasterData.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise1.Application.MasterData.Services;
internal class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public Task<EmployeeDto> AddAsync(EmployeeDto model)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<EmployeeDto>> GetAll(string filter = "")
    {
        var res = await _employeeRepository.GetAll();
        if (String.IsNullOrEmpty(filter))
            return _mapper.Map<List<EmployeeDto>>(res);
        return _mapper.Map<List<EmployeeDto>>(res.Where(x => x.Firstname.ToLower().Contains(filter.ToLower()) ||
                                                             x.Middlename.ToLower().Contains(filter.ToLower()) ||
                                                             x.Lastname.ToLower().Contains(filter.ToLower()) ||
                                                             x.Address.ToLower().Contains(filter.ToLower()) ||
                                                             x.Email.ToLower().Contains(filter.ToLower())).ToList());
    }

    public async Task<EmployeeDto> GetAsync(long id)
    {
        var result = await _employeeRepository.GetAsync(id);
        return _mapper.Map<EmployeeDto>(result);
    }

    public Task<EmployeeDto> UpdateAsync(EmployeeDto model)
    {
        throw new System.NotImplementedException();
    }
}
