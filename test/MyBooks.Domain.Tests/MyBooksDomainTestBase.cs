using Volo.Abp.Modularity;

namespace MyBooks;

/* Inherit from this class for your domain layer tests. */
public abstract class MyBooksDomainTestBase<TStartupModule> : MyBooksTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
