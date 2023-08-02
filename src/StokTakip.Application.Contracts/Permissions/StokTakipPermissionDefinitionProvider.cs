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
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StokTakipResource>(name);
    }
}
