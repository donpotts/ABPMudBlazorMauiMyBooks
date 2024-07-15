using System.Threading.Tasks;
using MyBooks.Localization;
using MyBooks.MultiTenancy;
using MyBooks.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace MyBooks.Web.Menus;

public class MyBooksMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<MyBooksResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MyBooksMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "MyBooks",
                l["Menu:MyBooks"],
                icon: "fa fa-database")
            .AddItem(
                new ApplicationMenuItem(
                    "MyBooks.Books",
                    l["Menu:Books"],
                    url: "/Books"
                ).RequirePermissions(MyBooksPermissions.Books.Default) // Check the permission!
            )
            .AddItem(
                new ApplicationMenuItem(
                    "MyBooks.Authors",
                    l["Menu:Authors"],
                    url: "/Authors"
                ).RequirePermissions(MyBooksPermissions.Authors.Default) // Check the permission!
            )
            .AddItem(
                new ApplicationMenuItem(
                    "MyBooks.Categories",
                    l["Menu:Categories"],
                    url: "/Categories"
                ).RequirePermissions(MyBooksPermissions.Categories.Default) // Check the permission!
            )
        );

        return Task.CompletedTask;
    }
}
