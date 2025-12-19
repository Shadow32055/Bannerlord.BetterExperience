using BetterCore.Utils;
using BetterExperience.Localizations;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterExperience.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        private int _base = 1000;
        private float _power = 2.8f;

        [SettingPropertyGroup(RefValues.ExperienceText)]
        [SettingPropertyInteger(RefValues.BaseText, 1, 4000, "0", Order = 0, RequireRestart = true, HintText = RefValues.BaseHint)]
        public int Base {
            get => _base;
            set {
                if (_base != value) {
                    _base = value;
                    OnPropertyChanged();
                }
            }
        }

        [SettingPropertyGroup(RefValues.ExperienceText)]
        [SettingPropertyFloatingInteger(RefValues.PowerText, 0.1f, 4f, "0.0", Order = 0, RequireRestart = true, HintText = RefValues.PowerHint)]
        public float Power {
            get => _power;
            set {
                if (_power != value) {
                    _power = value;
                    OnPropertyChanged();
                }
            }
        }

        [SettingPropertyGroup(RefValues.ExperienceText)]
        [SettingPropertyBool(RefValues.DisplayLevelInformationText, Order = 0, RequireRestart = true, HintText = RefValues.DisplayLevelInformationHint)]
        public bool DisplayLevelInformation { get; set; } = false;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
