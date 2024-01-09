using BetterCore.Utils;
using BetterExperience.Localizations;
using BetterExperience.Settings;
using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace BetterExperience {
    public class BetterExperience : MBSubModuleBase {

        public static MCMSettings Settings { get; private set; } = new MCMSettings();
        public static string ModName { get; private set; } = "ForgotToSet";
        public static int MaxLevel { get; private set; } = 0;
        public static int[] Levels { get; private set; } = new int[0];

        private bool isInitialized = false;
        private bool isLoaded = false;
        
        //FIRST
        protected override void OnSubModuleLoad() {
            try {
                base.OnSubModuleLoad();

                if (isInitialized)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Harmony h = new("Bannerlord.Shadow." + ModName);

                h.PatchAll(Assembly.GetExecutingAssembly());

                isInitialized = true;
            } catch (Exception e) {
                NotifyHelper.ReportError(ModName, "OnSubModuleLoad threw exception " + e);
            }
        }

        //SECOND
        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            try {
                base.OnBeforeInitialModuleScreenSetAsRoot();

                if (isLoaded)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Settings = MCMSettings.Instance ?? throw new NullReferenceException("Settings are null");

                NotifyHelper.ChatMessage(ModName + " Loaded.", MsgType.Good);
                Integrations.BetterHealthLoaded = true;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.ReportError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        //THIRD
        protected override void OnGameStart(Game game, IGameStarter gameStarter) {
            MaxLevel = CalculateMaxLevel();

            Levels = BuildLevelArray();

            if (Settings.DisplayMax)
                NotifyHelper.ChatMessage(new TextObject(RefValues.LevelReadoutText) + MaxLevel.ToString(), MsgType.Good);
        }

        private static int CalculateMaxLevel() {
            long totalXp = 0;
            long levelXp = 0;
            int level = 0;
            while (totalXp < int.MaxValue) {
                levelXp = Settings.Base * (long)MathF.Pow(level, Settings.Power);
                totalXp += levelXp;
                level++;
            }

            return level - 2;
        }

        private static int[] BuildLevelArray() {
            int[] levels = new int[MaxLevel + 1];

            for (int i = 0; i <= MaxLevel; i++) {

                levels[i] = (int)(Settings.Base * (long)MathF.Pow(i, Settings.Power));
            }

            return levels;
        }
    }
}
