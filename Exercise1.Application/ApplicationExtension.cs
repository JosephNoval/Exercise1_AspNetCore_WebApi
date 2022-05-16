using Exercise1.Application.MasterData.Interfaces.Services;
using Exercise1.Application.MasterData.Services;
using Exercise1.Application.TaskManagement.Interfaces;
using Exercise1.Application.TaskManagement.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Exercise1.Application;
public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IEmployeeTaskService, EmployeeTaskService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IProjectService, ProjectService>();

        return services;
    }
}
