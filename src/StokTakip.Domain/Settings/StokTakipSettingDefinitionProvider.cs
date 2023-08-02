using Volo.Abp.Settings;

namespace StokTakip.Settings;

public class StokTakipSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(StokTakipSettings.MySetting1));
    }
}
