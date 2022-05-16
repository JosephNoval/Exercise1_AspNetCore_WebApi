using Exercise1.Application.Common.Interfaces;
using Exercise1.Domain.Entities.MasterData;
using System;

namespace Exercise1.Application.MasterData.Dtos;
public class TaskDto : IMapFrom<Task>
{
    public long ProjectId { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public virtual ProjectDto Project { get; set; }
}
