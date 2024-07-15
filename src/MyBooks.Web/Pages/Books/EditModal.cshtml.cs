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

public class EditModalModel : MyBooksPageModel
{

    [BindProperty]
    public EditBookViewModel Book { get; set; } = null!;

    public List<SelectListItem> Authors { get; set; } = null!;
    public List<SelectListItem> Categories { get; set; } = null!;

    private readonly IBookAppService _bookAppService;

    public EditModalModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public async Task OnGetAsync(int id)
    {
        var bookDto = await _bookAppService.GetAsync(id);
        Book = ObjectMapper.Map<BookDto, EditBookViewModel>(bookDto);
        Book.AuthorIds = bookDto.Authors?.Select(x => x.Id).ToList();
        Book.CategoryIds = bookDto.Categories?.Select(x => x.Id).ToList();

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
        await _bookAppService.UpdateAsync(
            Book.Id,
            ObjectMapper.Map<EditBookViewModel, CreateUpdateBookDto>(Book)
        );

        return NoContent();
    }

    public class EditBookViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

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
