using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MyBooks.Data;

/* This is used if database provider does't define
 * IMyBooksDbSchemaMigrator implementation.
 */
public class NullMyBooksDbSchemaMigrator : IMyBooksDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
