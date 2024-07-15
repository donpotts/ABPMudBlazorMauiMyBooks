using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBooks.Data;
using Volo.Abp.DependencyInjection;

namespace MyBooks.EntityFrameworkCore;

public class EntityFrameworkCoreMyBooksDbSchemaMigrator
    : IMyBooksDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMyBooksDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MyBooksDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MyBooksDbContext>()
            .Database
            .MigrateAsync();
    }
}
