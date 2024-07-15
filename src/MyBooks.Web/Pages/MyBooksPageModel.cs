using MyBooks.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MyBooks.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MyBooksPageModel : AbpPageModel
{
    protected MyBooksPageModel()
    {
        LocalizationResourceType = typeof(MyBooksResource);
    }
}
