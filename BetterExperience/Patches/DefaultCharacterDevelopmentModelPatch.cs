using HarmonyLib;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterExperience.Patches {
    [HarmonyPatch]
    internal class DefaultCharacterDevelopmentModelPatch {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.SkillsRequiredForLevel))]
        public static void SkillsRequiredForLevel(ref int __result, int level) {

            if (level > BetterExperience.MaxLevel) {
                __result = int.MaxValue;
            } else {
                __result = BetterExperience.Levels[level];
            }
        }
    }
}
