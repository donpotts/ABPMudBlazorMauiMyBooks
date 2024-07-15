using Xunit;

namespace MyBooks.EntityFrameworkCore;

[CollectionDefinition(MyBooksTestConsts.CollectionDefinitionName)]
public class MyBooksEntityFrameworkCoreCollection : ICollectionFixture<MyBooksEntityFrameworkCoreFixture>
{

}
