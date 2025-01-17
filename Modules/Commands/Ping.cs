using System;

namespace TwT
{
  public class PingCommand : ICommand
  {
    public void Execute(string[] args)
    {
      Bot.SendMessage("ppL TeaTime");
    }
  }
}
