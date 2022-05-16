using Exercise1.Application.Common.Interfaces;
using Exercise1.Domain.Entities.TaskManagement;

namespace Exercise1.Application.TaskManagement.Interfaces;
public interface IEmployeeTaskRepository : IBaseRepository<EmployeeTask>
{
}
