using System;
using System.Collections.Generic;

namespace TwT
{
  public class CLI
  {
    private readonly Dictionary<string, ICommand> _commands;

    public CLI()
    {
      _commands = new Dictionary<string, ICommand>
      {
        { "help", new HelpCommand() },
        { "disconnect", new DisconnectCommand() },
        { "clear", new ClearCommand() },
        { "echo", new  EchoCommand() },
        { "open", new OpenCommand() },
        { "pyramid", new PyramidCommand() },
        { "ban", new BanCommand() },
      };
    }

    public void ExecuteCommand(string cmd, string[] args)
    {
      if (_commands.TryGetValue(cmd.ToLower(), out var command))
      {
        command.Execute(args);
      }
      else
      {
        Messages.Error($"Unknown command: '{cmd}'. Type 'help' for a list of available commands.");
      }
    }
  }
}
