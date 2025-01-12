using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwT
{
  public class Bot
  {
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
    private static async Task OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
      if (Settings.WriteLogs)
      {
        Logs.WriteSync($"[{e.ChatMessage.DisplayName}]: {e.ChatMessage.Message}");
      }

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
    public void Disconnect()
    {
      client.Disconnect();
    }
  }
}
