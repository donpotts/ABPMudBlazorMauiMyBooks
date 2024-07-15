using System;
using System.Threading.Tasks;
using MyBooks.Categories;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Web.Pages.Categories;

public class EditModalModel : MyBooksPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public CreateUpdateCategoryDto Category { get; set; } = null!;

    private readonly ICategoryAppService _categoryAppService;

    public EditModalModel(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    public async Task OnGetAsync()
    {
        var categoryDto = await _categoryAppService.GetAsync(Id);
        Category = ObjectMapper.Map<CategoryDto, CreateUpdateCategoryDto>(categoryDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _categoryAppService.UpdateAsync(Id, Category);
        return NoContent();
    }
}
