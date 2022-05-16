using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Dtos;
using Exercise1.Domain.Entities.TaskManagement;
using System;

namespace Exercise1.Application.TaskManagement.Dtos;
public class EmployeeTaskDetailDto : IMapFrom<EmployeeTaskDetail>
{
    public long Id { get; set; }
    public long EmployeeTaskId { get; set; }
    public long EmployeeId { get; set; }
    public int EmployeeEstimation { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public virtual EmployeeDto Employee { get; set; }
}
