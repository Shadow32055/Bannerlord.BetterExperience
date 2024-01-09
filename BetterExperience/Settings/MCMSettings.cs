using BetterExperience.Localizations;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterExperience.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup(RefValues.ExperienceText)]
        [SettingPropertyInteger(RefValues.BaseText, 1, 4000, "0", Order = 0, RequireRestart = false, HintText = RefValues.BaseHint)]
        public int Base { get; set; } = 1000;

        [SettingPropertyGroup(RefValues.ExperienceText)]
        [SettingPropertyFloatingInteger(RefValues.PowerText, 0.1f, 4f, "0.0", Order = 0, RequireRestart = false, HintText = RefValues.PowerHint)]
        public float Power { get; set; } = 2.8f;

        [SettingPropertyGroup(RefValues.ExperienceText)]
        [SettingPropertyBool(RefValues.DisplayLevlText, Order = 0, RequireRestart = false, HintText = RefValues.DisplayLevelHint)]
        public bool DisplayMax { get; set; } = false;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
