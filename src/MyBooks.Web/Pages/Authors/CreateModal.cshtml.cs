using System.Threading.Tasks;
using MyBooks.Authors;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Web.Pages.Authors;

public class CreateModalModel : MyBooksPageModel
{
    [BindProperty]
    public CreateUpdateAuthorDto Author { get; set; } = null!;

    private readonly IAuthorAppService _authorAppService;

    public CreateModalModel(IAuthorAppService authorAppService)
    {
        _authorAppService = authorAppService;
    }

    public void OnGet()
    {
        Author = new CreateUpdateAuthorDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _authorAppService.CreateAsync(Author);
        return NoContent();
    }
}
