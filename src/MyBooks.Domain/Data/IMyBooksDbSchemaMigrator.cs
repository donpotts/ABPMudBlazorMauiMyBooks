using System.Threading.Tasks;

namespace MyBooks.Data;

public interface IMyBooksDbSchemaMigrator
{
    Task MigrateAsync();
}
