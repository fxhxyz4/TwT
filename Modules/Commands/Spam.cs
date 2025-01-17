using System;

namespace TwT
{
  public class SpamCommand : ICommand
  {
    public void Execute(string[] args)
    {
      try
      {
        int count = 5;
        string phrase;

        if (args.Length >= 1 && int.TryParse(args[0], out int parsedCount) && parsedCount > 0)
        {
          count = parsedCount;
          phrase = string.Join(" ", args, 1, args.Length - 1);
        }
        else
        {
          phrase = string.Join(" ", args);
        }

        for (int i = 0; i < count; i++)
        {
          Bot.SendMessage(phrase);
        }
      }
      catch (Exception e)
      {
        Messages.Error(e.StackTrace + e.Message);
        throw;
      }
    }
  }
}
