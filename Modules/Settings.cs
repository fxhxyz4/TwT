using System;
using System.Runtime.InteropServices.JavaScript;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwT
{
    public class PhraseCommand
    {
      public string Date { get; set; }
      public string Command { get; set; }
      public string Phrase { get; set; }

    }

    internal class Settings
    {
        public static bool WriteLogs { get; set; }
        public static bool DisplayMsg { get; set; }
        public static bool RootPrivileges { get; set; }
    }

    internal class Auth
    {
        public static string ChannelName { get; set; }
        public static string OAuthKey { get; set; }
    }

    internal class Credentials
    {
        /*
        * @public
        */
        public static void Configure()
        {
            GetSettings();
            GetAuth();
        }

        /*
        * @private
        */
        private static void GetSettings()
        {
            Messages.Info($"Setup TwT settings");

            Settings.WriteLogs = GetBooleanSetting(
                "WriteLogs: creates log files with all actions",
                "WriteLogs"
            );

            Settings.DisplayMsg = GetBooleanSetting(
              "DisplayMsg: displayed messages in terminal",
              "DisplayMsg"
            );

            Settings.RootPrivileges = GetBooleanSetting(
                "RootPrivileges: gives access to all commands",
                "RootPrivileges"
            );

            Messages.Log("Settings successfully configured!");
        }

        /*
        * @private
        */
        private static void GetAuth()
        {
            Messages.Info($"\n\nType login credentials");

            Auth.ChannelName = GetCredentials(
                "Type bot channel name",
                "ChannelName"
            );

            Auth.OAuthKey = GetCredentials(
                "Type oauth key",
                "OAuthKey"
            );

            try
            {
              Messages.Log("\n\nTried to connect...");
              Program.TwitchService.Connect();
            }
            catch (Exception e)
            {
              Messages.Error($"{e.StackTrace} + {e.Message}");
            }
        }

        /*
        * @private
         *
         * @params {string desc}
         * @params {string settingName}
         *
         * @returns {bool}
       */
        private static bool GetBooleanSetting(string desc, string settingName)
        {
            bool res;
            while (true)
            {
                Messages.Info($"{desc}");
                Messages.Log($"Enter value for {settingName} (true/false): ");

                string input = Console.ReadLine()?.ToLower().Trim();
                Console.WriteLine();

                if (bool.TryParse(input, out res))
                {
                    return res;
                }

                Messages.Error($"Invalid input for {settingName}. Please type 'true' or 'false'.");
            }
        }

        /*
         * @private
         *
         * @params {string desc}
         * @params {string loginName}
         *
         * @returns {string}
         */
        private static string GetCredentials(string desc, string loginName)
        {
            Console.WriteLine("\n\n");
            Messages.Info($"{desc}");

            Messages.Log($"Enter value for {loginName}: ");

            string input = Console.ReadLine()?.ToLower().Trim();

            return input ?? string.Empty;
        }
    }
}
