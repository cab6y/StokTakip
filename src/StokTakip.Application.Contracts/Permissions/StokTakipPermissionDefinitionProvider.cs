using StokTakip.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace StokTakip.Permissions;

public class StokTakipPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StokTakipPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StokTakipPermissions.MyPermission1, L("Permission:MyPermission1"));

        var products = myGroup.AddPermission(StokTakipPermissions.Products.Default, L("Permission:Products"));
        products.AddChild(StokTakipPermissions.Products.Create, L("Permission:Products.Create"));
        products.AddChild(StokTakipPermissions.Products.Edit, L("Permission:Products.Edit"));
        products.AddChild(StokTakipPermissions.Products.Delete, L("Permission:Products.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StokTakipResource>(name);
    }
}
