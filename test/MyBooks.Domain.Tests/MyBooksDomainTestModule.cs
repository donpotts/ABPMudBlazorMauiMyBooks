using Volo.Abp.Modularity;

namespace MyBooks;

[DependsOn(
    typeof(MyBooksDomainModule),
    typeof(MyBooksTestBaseModule)
)]
public class MyBooksDomainTestModule : AbpModule
{

}
