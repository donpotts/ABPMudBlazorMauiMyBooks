using System;
using System.Collections.Generic;
using System.Text;
using MyBooks.Localization;
using Volo.Abp.Application.Services;

namespace MyBooks;

/* Inherit your application services from this class.
 */
public abstract class MyBooksAppService : ApplicationService
{
    protected MyBooksAppService()
    {
        LocalizationResource = typeof(MyBooksResource);
    }
}
