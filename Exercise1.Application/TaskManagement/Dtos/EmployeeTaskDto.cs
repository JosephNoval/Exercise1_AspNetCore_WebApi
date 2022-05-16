using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Dtos;
using Exercise1.Domain.Entities.TaskManagement;
using System;
using System.Collections.Generic;

namespace Exercise1.Application.TaskManagement.Dtos;
public class EmployeeTaskDto : IMapFrom<EmployeeTask>
{
    public long Id { get; set; }
    public long ProjectId { get; set; }
    public long TaskId { get; set; }
    public int TotalEstimate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public List<EmployeeTaskDetailDto> EmployeeTaskDetails { get; set; }

    public virtual ProjectDto Project { get; set; }
    public virtual TaskDto Task { get; set; }
}
