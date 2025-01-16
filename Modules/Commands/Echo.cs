using System;

namespace TwT
{
  public class EchoCommand : ICommand
  {
    public void Execute(string[] args)
    {
      Bot.SendMessage(args[0]);
    }
  }
}
