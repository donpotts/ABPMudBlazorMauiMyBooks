using MyBooks.Samples;
using Xunit;

namespace MyBooks.EntityFrameworkCore.Domains;

[Collection(MyBooksTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MyBooksEntityFrameworkCoreTestModule>
{

}
