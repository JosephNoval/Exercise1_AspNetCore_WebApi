using Exercise1.Application.TaskManagement.Dtos;
using FluentValidation;

namespace Exercise1.Application.TaskManagement.Validators;
public class EmployeeTaskValidator : AbstractValidator<EmployeeTaskDto>
{
    public EmployeeTaskValidator()
    {
        RuleFor(x => x.ProjectId).NotEmpty();
        RuleFor(x => x.TaskId).NotEmpty();
        RuleFor(x => x.TotalEstimate).NotEmpty();
    }
}
