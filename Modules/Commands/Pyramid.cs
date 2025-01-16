using System;
using Microsoft.Extensions.Logging;

namespace TwT
{
  public class PyramidCommand : ICommand
  {
    public void Execute(string[] args)
    {
      string msg = args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]) ? args[0] : "ppL";
      int count = 3;

      try
      {
        for (int i = 1; i <= count; i++)
        {
          var pyramidRow = new System.Text.StringBuilder();
          for (int j = 0; j < i; j++)
          {
            pyramidRow.Append(msg + " ");
          }

          if (pyramidRow.Length > 0)
          {
            Bot.SendMessage(pyramidRow.ToString().Trim());
          }
        }

        for (int i = count - 1; i > 0; i--)
        {
          var pyramidRow = new System.Text.StringBuilder();
          for (int j = 0; j < i; j++)
          {
            pyramidRow.Append(msg + " ");
          }

          if (pyramidRow.Length > 0)
          {
            Bot.SendMessage(pyramidRow.ToString().Trim());
          }
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
