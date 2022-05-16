using Exercise1.Application.Common.Interfaces;
using Exercise1.Domain.Entities.MasterData;
using System;

namespace Exercise1.Application.MasterData.Dtos;
public class ProjectDto : IMapFrom<Project>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
