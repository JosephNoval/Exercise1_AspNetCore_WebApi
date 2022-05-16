using Exercise1.Application.Common.Interfaces;
using Exercise1.Application.MasterData.Interfaces.Repository;
using Exercise1.Application.TaskManagement.Interfaces;
using Exercise1.Infrastructure.Persistence;
using Exercise1.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise1.Infrastructure;
public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDataContext>(opt =>
                                                opt.UseSqlServer(configuration.GetConnectionString("AppDataContext")));
        services.AddTransient<IAppDataContext>(provider => provider.GetService<AppDataContext>());

        services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();

        return services;
    }
}
