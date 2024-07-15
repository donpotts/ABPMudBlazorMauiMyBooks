using MyBooks.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MyBooks.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyBooksEntityFrameworkCoreModule),
    typeof(MyBooksApplicationContractsModule)
    )]
public class MyBooksDbMigratorModule : AbpModule
{
}
