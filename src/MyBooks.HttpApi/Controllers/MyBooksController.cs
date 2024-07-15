using MyBooks.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyBooks.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MyBooksController : AbpControllerBase
{
    protected MyBooksController()
    {
        LocalizationResource = typeof(MyBooksResource);
    }
}
