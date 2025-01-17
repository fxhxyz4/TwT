using System;
using TwitchLib.Api;
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
    public async Task Connect(string channelName, string oauthToken)
    {
      ConnectionCredentials credentials = new ConnectionCredentials(channelName, oauthToken);
      client = new TwitchClient();

      client.Initialize(credentials, channelName);

      client.OnMessageReceived += OnMessageReceived;

      client.Connect();
    }

    /*
     * @private
     */
    public static async Task OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
      string type = $"[{e.ChatMessage.UserId}][{e.ChatMessage.Username}]: {e.ChatMessage.Message}";

      if (Settings.WriteLogs) Logs.WriteSync(type);

      if (Settings.DisplayMsg) Messages.Log(type);


      await Task.CompletedTask;
    }

    /*
     * @public
     *
     * @params {string message}
     */
    public static void SendMessage(string msg)
    {
      // twitchlib trash
      client.JoinChannel(Auth.ChannelName);

      if (client.JoinedChannels.Count == 0)
      {
        Messages.Error("No channels joined. Ensure the bot is connected to a channel");
        return;
      }

      try
      {
        client.SendMessage(client.JoinedChannels[0], msg);
      }
      catch (Exception e)
      {
        Messages.Error(e.StackTrace + e.Message);
      }
    }

    /*
     * @public
     */
    public static void Disconnect()
    {
      client.Disconnect();
    }

    /*
     * @public
     */
    public static void Reconnect()
    {
      try
      {
        if (client.IsConnected)
        {
          Disconnect();
        }

        Messages.Info("Reconnecting...");
        client.Connect();

      }
      catch (Exception e)
      {
        Messages.Error(e.StackTrace + e.Message);
        throw;
      }
    }
  }
}
