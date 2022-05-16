using Exercise1.Application.Common.Interfaces;
using Exercise1.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1.Infrastructure.Persistence;
public class AppDataContext : DbContext, IAppDataContext
{
    public AppDataContext(DbContextOptions<AppDataContext> opt)
        : base(opt) { }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        string entityName = "";
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }
            entityName = entry.Entity.GetType().Name;
        }

        var changes = base.SaveChangesAsync(cancellationToken);
        var type = ChangeTracker.GetType();

        return changes;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var typeToRegisters = typeof(BaseEntity).GetTypeInfo().Assembly.DefinedTypes.Select(t => t.AsType());
        modelBuilder.RegisterEntities(typeToRegisters);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }
}
static class CustomConfigurations
{
    internal static void RegisterEntities(this ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
    {
        var entityTypes = typeToRegisters.Where(t => (t.GetTypeInfo().IsSubclassOf(typeof(BaseEntity))) && !t.GetTypeInfo().IsAbstract);
        foreach (var type in entityTypes)
        {
            modelBuilder.Entity(type);
        }
    }
}
