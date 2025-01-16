using System;

namespace TwT
{
  public class BanCommand : ICommand
  {
    public void Execute(string[] args)
    {
      if (args.Length == 0)
      {
        Messages.Error("No phrase provided!");
        return;
      }

      try
      {
        string phrase = args.Length > 0 && !string.IsNullOrEmpty(args[0]) ? args[0] : "";

        MonitoringSettings.MonitoredPhrases.Add(new PhraseCommand
        {
          Date = DateTime.Now.ToString("dd/MM/yyyy"),
          Command = "ban",
          Phrase = phrase,
        });

        TransferData.CopiedData();
        Messages.Info($"started phrase: {phrase}");
      }
      catch (Exception e)
      {
        Messages.Error(e.StackTrace + e.Message);
        throw;
      }
    }
  }
}
