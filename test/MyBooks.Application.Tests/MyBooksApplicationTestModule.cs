using Volo.Abp.Modularity;

namespace MyBooks;

[DependsOn(
    typeof(MyBooksApplicationModule),
    typeof(MyBooksDomainTestModule)
)]
public class MyBooksApplicationTestModule : AbpModule
{

}
