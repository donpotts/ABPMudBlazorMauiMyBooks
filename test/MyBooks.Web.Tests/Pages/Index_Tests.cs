using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MyBooks.Pages;

public class Index_Tests : MyBooksWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
