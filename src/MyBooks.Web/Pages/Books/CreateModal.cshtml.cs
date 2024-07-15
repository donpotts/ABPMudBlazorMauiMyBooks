using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyBooks.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MyBooks.Web.Pages.Books;

public class CreateModalModel : MyBooksPageModel
{
    [BindProperty]
    public CreateBookViewModel Book { get; set; } = null!;

    public List<SelectListItem> Authors { get; set; } = null!;
    public List<SelectListItem> Categories { get; set; } = null!;

    private readonly IBookAppService _bookAppService;

    public CreateModalModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public async Task OnGetAsync()
    {
        Book = new CreateBookViewModel();

        var authorLookup = await _bookAppService.GetAuthorLookupAsync();
        Authors = authorLookup.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        var categoryLookup = await _bookAppService.GetCategoryLookupAsync();
        Categories = categoryLookup.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _bookAppService.CreateAsync(
            ObjectMapper.Map<CreateBookViewModel, CreateUpdateBookDto>(Book)
            );
        return NoContent();
    }

    public class CreateBookViewModel
    {

        public string? Name { get; set; }

        public DateTime PublishDate { get; set; }

        public double Price { get; set; }

        [SelectItems(nameof(Authors))]
        [DisplayName("Authors")]
        public List<int>? AuthorIds { get; set; }

        [SelectItems(nameof(Categories))]
        [DisplayName("Categories")]
        public List<int>? CategoryIds { get; set; }
    }
}
