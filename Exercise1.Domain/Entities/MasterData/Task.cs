using Exercise1.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1.Domain.Entities.MasterData;
public class Task : BaseEntity
{
    public long ProjectId { get; set; }
    public string Name { get; set; }

    [ForeignKey("ProjectId")]
    public virtual Project Project { get; set; }
}
