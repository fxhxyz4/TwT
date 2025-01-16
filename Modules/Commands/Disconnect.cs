using System;

namespace TwT
{
  public class DisconnectCommand : ICommand
  {
    public void Execute(string[] args)
    {
      TransferData.CopiedData();
      Program._isRunning = false;

      Bot.Disconnect();
      Messages.Info("Bot disconnected!");
    }
  }
}
