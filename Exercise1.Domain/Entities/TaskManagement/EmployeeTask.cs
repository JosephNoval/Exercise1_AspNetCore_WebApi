using Exercise1.Domain.Common;
using Exercise1.Domain.Entities.MasterData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1.Domain.Entities.TaskManagement;
public class EmployeeTask : BaseEntity
{
    public long ProjectId { get; set; }
    public long TaskId { get; set; }
    public int TotalEstimate { get; set; }
    public List<EmployeeTaskDetail> EmployeeTaskDetails { get; set; }


    [ForeignKey("ProjectId")]
    public virtual Project Project { get; set; }

    [ForeignKey("TaskId")]
    public virtual Task Task { get; set; }
}
