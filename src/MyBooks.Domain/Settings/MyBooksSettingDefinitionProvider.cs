using Volo.Abp.Settings;

namespace MyBooks.Settings;

public class MyBooksSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MyBooksSettings.MySetting1));
    }
}
