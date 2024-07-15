using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyBooks.Authors;

public interface IAuthorAppService :
    ICrudAppService< //Defines CRUD methods
        AuthorDto, //Used to show authors
        int, //Primary key of the author entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateAuthorDto> //Used to create/update a author
{
}
