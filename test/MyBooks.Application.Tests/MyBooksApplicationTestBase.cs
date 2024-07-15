using Volo.Abp.Modularity;

namespace MyBooks;

public abstract class MyBooksApplicationTestBase<TStartupModule> : MyBooksTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
