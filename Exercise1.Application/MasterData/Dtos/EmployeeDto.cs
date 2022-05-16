using Exercise1.Application.Common.Interfaces;
using Exercise1.Domain.Entities.MasterData;
using System;

namespace Exercise1.Application.MasterData.Dtos;
public class EmployeeDto : IMapFrom<Employee>
{
    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
