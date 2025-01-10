/*
Author: fxhxyz
email: fxhxyz@proton.me
website: fxhxyz.envs.sh
*/

using System.Net.NetworkInformation;
using TwitchLib.Client;
using TwitchLib.Api;
using TwitchLib;
using System;

namespace TwT
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.InputEncoding = System.Text.Encoding.UTF8;

			string[] settings = new string[]{ };
			
			// const PING_URL
			const string PING_URL = "https://twitch.tv/";
			
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
				"=========================================================="
			};

			/*
			 * ShowBanner
			 *
			 * @params {string[] banner}
			 */ 
			static void ShowBanner(string[] banner)
			{
				foreach (string line in banner)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine(line);
				}
				
				Console.ForegroundColor = ConsoleColor.White;
			}
			
			ShowBanner(banner);
			
			bool isConnection = CheckConnectionAvailable();
			if (!isConnection)
			{
				Messages.Error($"Failed to connection with twitch!");
			}
			else
			{
				GetSettings.Get();
			}
			
			/*
			 * CheckConnectionAvailable
			 * @params {string url}
			 *
			 * @returns {bool}
			 */ 
			bool CheckConnectionAvailable()
			{
				try
				{
					Ping ping = new Ping();
					PingReply reply = ping.Send(PING_URL);
			
					if (reply.Status == IPStatus.Success)
					{
						return true;
					}

					Messages.Error("Failed to connection with twitch!");
					return false;
				}
				catch (Exception e)
				{
					Messages.Error(e.StackTrace + e.Message);
					throw;
				}
			}

			// Console READLINE
			Console.ReadLine();
		}
	}
}
