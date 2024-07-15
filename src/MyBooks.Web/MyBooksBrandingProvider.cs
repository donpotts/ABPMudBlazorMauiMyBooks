using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MyBooks.Web;

[Dependency(ReplaceServices = true)]
public class MyBooksBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyBooks";
}
