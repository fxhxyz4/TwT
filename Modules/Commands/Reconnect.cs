using System;

namespace TwT
{
  public class ReconnectCommand : ICommand
  {
    public void Execute(string[] args)
    {
      try
      {
        Bot.Reconnect();
      }
      catch (Exception e)
      {
        Messages.Error(e.StackTrace + e.Message);
        throw;
      }
    }
  }
}
