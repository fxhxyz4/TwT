using System;

namespace TwT
{
  public class EchoCommand : ICommand
  {
    public void Execute(string[] args)
    {
      string message = string.Join(" ", args).TrimStart().TrimEnd();
      Bot.SendMessage(message);
    }
  }
}
