using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwT
{

  public static class MonitoringSettings
  {
    public static List<PhraseCommand> MonitoredPhrases { get; } = new List<PhraseCommand>();
  }
  public class Bot
  {
    //TODO
    public string regexp = "[A-Za-z0-9]+";
    private static TwitchClient client;

    /*
     * @public
     *
     * @params {string channelName}
     * @params {string oauthToken}
     */
    public void Connect(string channelName, string oauthToken)
    {
      ConnectionCredentials credentials = new ConnectionCredentials(channelName, oauthToken);
      client = new TwitchClient();

      client.Initialize(credentials, channelName);

      client.OnConnected += OnConnected;
      client.OnMessageReceived += OnMessageReceived;

      client.Connect();
    }

    /*
     * @private
     */
    private static async Task OnConnected(object sender, OnConnectedArgs e)
    {
      Messages.Info($"Connected to Twitch channel: {e.AutoJoinChannel}");
      await Task.CompletedTask;
    }

    /*
     * @private
     */
    public static async Task OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
      if (Settings.WriteLogs)
      {
        Logs.WriteSync($"[{e.ChatMessage.DisplayName}]: {e.ChatMessage.Message}");
      }

      /*
      if (Settings.RootPrivileges)
      {
        foreach (var entry in MonitoringSettings.MonitoredPhrases)
        {
          if (string.Equals(e.ChatMessage.Message, entry.Phrase, StringComparison.OrdinalIgnoreCase))
          {
            Bot.SendMessage($"/{entry.Command} {e.ChatMessage.DisplayName}");
            break;
          }
        }
      }
      */

      // Messages.Log($"[{e.ChatMessage.DisplayName}]: {e.ChatMessage.Message}");
      await Task.CompletedTask;
    }

    /*
     * @public
     *
     * @params {string message}
     */
    public static void SendMessage(string msg)
    {
      client.SendMessage(client.JoinedChannels[0], msg);
    }

    /*
     * @public
     */
    public static void Disconnect()
    {
      client.Disconnect();
    }
  }
}
