using System;
using MyBooks.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MyBooks.Categories;

public class CategoryAppService :
    CrudAppService<
        Category, //The Category entity
        CategoryDto, //Used to show categories
        int, //Primary key of the category entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryDto>, //Used to create/update a category
    ICategoryAppService //implement the ICategoryAppService
{
    public CategoryAppService(IRepository<Category, int> repository)
        : base(repository)
    {
        GetPolicyName = MyBooksPermissions.Categories.Default;
        GetListPolicyName = MyBooksPermissions.Categories.Default;
        CreatePolicyName = MyBooksPermissions.Categories.Create;
        UpdatePolicyName = MyBooksPermissions.Categories.Edit;
        DeletePolicyName = MyBooksPermissions.Categories.Delete;
    }
}
