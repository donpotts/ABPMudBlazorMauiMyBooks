using System;
using MyBooks.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MyBooks.Authors;

public class AuthorAppService :
    CrudAppService<
        Author, //The Author entity
        AuthorDto, //Used to show authors
        int, //Primary key of the author entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateAuthorDto>, //Used to create/update a author
    IAuthorAppService //implement the IAuthorAppService
{
    public AuthorAppService(IRepository<Author, int> repository)
        : base(repository)
    {
        GetPolicyName = MyBooksPermissions.Authors.Default;
        GetListPolicyName = MyBooksPermissions.Authors.Default;
        CreatePolicyName = MyBooksPermissions.Authors.Create;
        UpdatePolicyName = MyBooksPermissions.Authors.Edit;
        DeletePolicyName = MyBooksPermissions.Authors.Delete;
    }
}
