using System.Threading.Tasks;
using StokTakip.Localization;
using StokTakip.MultiTenancy;
using StokTakip.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace StokTakip.Web.Menus;

public class StokTakipMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async  Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<StokTakipResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                StokTakipMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        var Sales = new ApplicationMenuItem(
               "Sales",
               l["Menu:Admin"],
               icon: "fa fa-book"
           );


        context.Menu.AddItem(Sales);
        if (await context.IsGrantedAsync(StokTakipPermissions.Products.Default))
        {
            Sales.AddItem(new ApplicationMenuItem(
                   "Sales.Products",
                   l["Menu:Products"],
                   url: "/products"
               ));
        }
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


    }
}
