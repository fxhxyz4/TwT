using System;

namespace TwT
{
  public class OpenCommand : ICommand
  {
    public void Execute(string[] args)
    {
      if (args.Length == 0)
      {
        Messages.Error("No file path provided!");
        return;
      }

      string path = args[0];
      string basePath = Path.GetFullPath("../../../");

      string fullPath = Path.Combine(basePath, path);

      if (!File.Exists(fullPath))
      {
        Messages.Error($"File {fullPath} does not exist!");
        return;
      }

      Logs.ReadSync(fullPath);
    }
  }
}

