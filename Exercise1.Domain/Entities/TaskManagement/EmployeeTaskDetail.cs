using Exercise1.Domain.Common;
using Exercise1.Domain.Entities.MasterData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1.Domain.Entities.TaskManagement;
public class EmployeeTaskDetail : BaseEntity
{
    public long EmployeeTaskId { get; set; }
    public long EmployeeId { get; set; }
    public int EmployeeEstimation { get; set; }


    [ForeignKey("EmployeeTaskId")]
    public virtual EmployeeTask EmployeeTask { get; set; }

    [ForeignKey("EmployeeId")]
    public virtual Employee Employee { get; set; }
}
