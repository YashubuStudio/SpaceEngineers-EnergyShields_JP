using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.Utils;
using System.IO;

namespace Cython.EnergyShields
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class LocalizationLoader : MySessionComponentBase
    {
        public override void LoadData()
        {
            try
            {
                var modPath = ModContext.ModPath;
                var baseFile = Path.Combine(modPath, "Localization/MyTexts.resx");
                if (File.Exists(baseFile))
                    MyTexts.RegisterFromResX(baseFile);
                var lang = MyAPIGateway.Session?.Language;
                if (!string.IsNullOrEmpty(lang))
                {
                    var langFile = Path.Combine(modPath, $"Localization/MyTexts.{lang}.resx");
                    if (File.Exists(langFile))
                        MyTexts.RegisterFromResX(langFile);
                }
            }
            catch
            {
                // ignore any errors, default localization will remain
            }
        }
    }
}
