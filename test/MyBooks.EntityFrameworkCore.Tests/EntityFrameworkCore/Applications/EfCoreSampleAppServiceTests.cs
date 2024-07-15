using MyBooks.Samples;
using Xunit;

namespace MyBooks.EntityFrameworkCore.Applications;

[Collection(MyBooksTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MyBooksEntityFrameworkCoreTestModule>
{

}
