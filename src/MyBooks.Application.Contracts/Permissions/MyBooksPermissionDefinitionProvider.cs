using MyBooks.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyBooks.Permissions;

public class MyBooksPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myBooksGroup = context.AddGroup(MyBooksPermissions.GroupName, L("Permission:MyBooks"));

        var booksPermission = myBooksGroup.AddPermission(MyBooksPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(MyBooksPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(MyBooksPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(MyBooksPermissions.Books.Delete, L("Permission:Books.Delete"));
        var authorsPermission = myBooksGroup.AddPermission(MyBooksPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(MyBooksPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(MyBooksPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(MyBooksPermissions.Authors.Delete, L("Permission:Authors.Delete"));
        var categoriesPermission = myBooksGroup.AddPermission(MyBooksPermissions.Categories.Default, L("Permission:Categories"));
        categoriesPermission.AddChild(MyBooksPermissions.Categories.Create, L("Permission:Categories.Create"));
        categoriesPermission.AddChild(MyBooksPermissions.Categories.Edit, L("Permission:Categories.Edit"));
        categoriesPermission.AddChild(MyBooksPermissions.Categories.Delete, L("Permission:Categories.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MyBooksResource>(name);
    }
}
