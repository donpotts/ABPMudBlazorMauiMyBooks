using System.Threading.Tasks;
using MyBooks.Categories;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Web.Pages.Categories;

public class CreateModalModel : MyBooksPageModel
{
    [BindProperty]
    public CreateUpdateCategoryDto Category { get; set; } = null!;

    private readonly ICategoryAppService _categoryAppService;

    public CreateModalModel(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    public void OnGet()
    {
        Category = new CreateUpdateCategoryDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _categoryAppService.CreateAsync(Category);
        return NoContent();
    }
}
