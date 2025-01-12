using System;

namespace TwT
{
  public class CLI
  {
    public void Help()
    {
      Messages.Log("Available Commands:");
      Messages.Log("help - Display this help information.");
      Messages.Log("open - Open log file\nUse: open {path to log file}");
    }

    public void ExecuteCommand(string cmd, string[] args)
    {
      switch (cmd.ToLower())
      {
        case "help":
          Help();
          break;
        case "open":
          if (args.Length > 0)
          {
            string path = args[0];

            if (File.Exists(path))
            {
              Logs.ReadSync(path);
            }
            else
            {
              Messages.Error($"The log file at '{path}' does not exist.");
            }
          }
          else
          {
            Messages.Error("Missing path to the log file. Use: open {path to log file}");
          }
          break;

        default:
          Messages.Error($"Unknown command: '{cmd}'. Type 'help' for a list of available commands.");
          break;
      }
    }
  }
}

