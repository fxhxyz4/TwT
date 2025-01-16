/*
  Author: fxhxyz
  Email: fxhxyz@proton.me
  Website: fxhxyz.envs.sh
*/

using System;
using System.Net.NetworkInformation;

namespace TwT
{
    public class Program
    {
        private const string PING_URL = "twitch.tv";
        private static bool _debugLogged = false;

        public static bool _isRunning = false;
        public static long PingLatency { get; private set; }

        public static void Main(string[] args)
        {
            InitializeConsoleEncoding();
            ShowBanner();

            if (!CheckConnectionAvailable())
            {
                Messages.Warn("Failed to connect with twitch.tv!");
                Messages.Warn("Check your network connectivity and try again.");

                WaitBeforeExit();
                return;
            }

            Credentials.Configure();
            TwitchService.Connect();

            CLI cli = new CLI();
            _isRunning = true;

            while (_isRunning)
            {
                Console.WriteLine("\nEnter a command ('help' for available commands, 'exit' to quit):");
                string inputCommand = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(inputCommand))
                {
                    Messages.Warn("No command entered. Type 'help' for a list of commands.");
                    continue;
                }

                if (inputCommand == "exit")
                {
                    TransferData.CopiedData();
                    _isRunning = false;

                    Messages.Info("Exiting bot...");
                    break;
                }

                string[] commandArgs = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];

                string[] arguments = commandArgs.Length > 1 ? commandArgs[1..] : Array.Empty<string>();
                cli.ExecuteCommand(command, arguments);
            }

            WaitBeforeExit();
        }

        private static void InitializeConsoleEncoding()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
        }

        private static void ShowBanner()
        {
            string[] banner = new string[]
            {
              "==========================================================",
              "==========================================================",
              "",
              "    ███████╗██╗  ██╗██╗  ██╗██╗  ██╗██╗   ██╗███████╗",
              "    ██╔════╝╚██╗██╔╝██║  ██║╚██╗██╔╝╚██╗ ██╔╝╚══███╔╝",
              "    █████╗   ╚███╔╝ ███████║ ╚███╔╝  ╚████╔╝   ███╔╝ ",
              "    ██╔══╝   ██╔██╗ ██╔══██║ ██╔██╗   ╚██╔╝   ███╔╝  ",
              "    ██║     ██╔╝ ██╗██║  ██║██╔╝ ██╗   ██║   ███████╗",
              "    ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚══════╝",
              "",
              "==========================================================",
              "==========================================================",
              "\n\n"
            };

            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (string line in banner)
            {
                Console.WriteLine(line);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool CheckConnectionAvailable()
        {
            try
            {
                using Ping ping = new Ping();
                PingReply reply = ping.Send(PING_URL);

                if (reply.Status == IPStatus.Success)
                {
                    PingLatency = reply.RoundtripTime;
                    return true;
                }

                Messages.Error($"Server {PING_URL} timed out after {reply.RoundtripTime} ms");
                return false;
            }
            catch (Exception e)
            {
                Messages.Error($"Error during connection check: {e.Message}");
                return false;
            }
        }

        private static void WaitBeforeExit()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        public static class TwitchService
        {
            public static void Connect()
            {
                string channelName = Auth.ChannelName;
                string oAuthKey = Auth.OAuthKey;

                Bot bot = new Bot();
                bot.Connect(channelName, oAuthKey);

                Messages.Info("Connected to Twitch");
                LogDebugInfo(channelName, oAuthKey);
            }

            private static void LogDebugInfo(string channelName, string oAuthKey)
            {
              if (_debugLogged) return;

              Messages.Info("==================== DEBUG INFO ====================");
              Messages.Debug($"Channel Name: {channelName}");
              Messages.Debug($"OAuth Key: {oAuthKey}");
              Messages.Debug($"Ping Latency: {Program.PingLatency} ms");
              Messages.Debug($"Logs Enabled: {Settings.WriteLogs}");
              Messages.Debug($"Root Privileges: {Settings.RootPrivileges}");
              Messages.Info("====================================================");

              _debugLogged = true;
            }
        }
    }
}
