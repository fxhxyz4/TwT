using System;

namespace TwT
{
    internal class Settings
    {
        public static bool WriteLogs { get; set; }
        public static bool RootPrivileges { get; set; }
    }

    class GetSettings
    {
        public static void Get()
        {
            Messages.Info($"\n\nSetup TwT settings");

            Settings.WriteLogs = GetBooleanSetting(
                "WriteLogs: creates log files with all actions",
                "WriteLogs"
            );

            Settings.RootPrivileges = GetBooleanSetting(
                "RootPrivileges: gives access to all commands",
                "RootPrivileges"
            );

            Messages.Log("\nSettings successfully configured!");
        }

        private static bool GetBooleanSetting(string desc, string settingName)
        {
            bool res;
            while (true)
            {
                Messages.Info($"\n\n{desc}\n");
                Messages.Log($"Enter value for {settingName} (true/false): ");

                string input = Console.ReadLine();

                if (bool.TryParse(input, out res))
                {
                    return res;
                }

                Messages.Error($"\n\nInvalid input for {settingName}. Please type 'true' or 'false'.");
            }
        }
    }
}

