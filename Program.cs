/*
  Author: fxhxyz
  Email: fxhxyz@proton.me
  Website: fxhxyz.envs.sh
*/

using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.JavaScript;

namespace TwT
{
    public class Program
    {
        private const string PING_URL = "twitch.tv";

        public static void Main(string[] args)
        {
            InitializeConsoleEncoding();

            ShowBanner();

            if (!CheckConnectionAvailable())
            {
                Messages.Warn("Failed to connect with Twitch!");
                return;
            }


            // CLI cli = new CLI();
            //
            // if (args.Length == 0)
            // {
            //   Console.WriteLine("No command provided. Type 'help' for a list of commands.");
            // }
            // else
            // {
            //   string command = args[0];
            //   string[] commandArgs = args.Length > 1 ? args[1..] : new string[] { };
            //
            //   cli.ExecuteCommand(command, commandArgs);
            // }

            Credentials.Configure();
            Console.ReadLine();
        }

        /*
        * @private
        */
        private static void InitializeConsoleEncoding()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
        }

        /*
        * @private
        */
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
              "    ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚══════╝",
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

        /*
        * @private
        */
        private static bool CheckConnectionAvailable()
        {
            try
            {
                using Ping ping = new Ping();
                PingReply reply = ping.Send(PING_URL);

                return reply.Status == IPStatus.Success;
            }
            catch (Exception e)
            {
                Messages.Error(e.StackTrace + e.Message);
                return false;
            }
        }
    }
}
