using System;

namespace TwT
{
  public class ClearCommand : ICommand
  {
    public void Execute(string[] args)
    {
      // clear json
      try
      {
        // clear original list
        // MonitoringSettings.MonitoredPhrases.Clear();

        // clear copied list
        TransferData._jsonList.Clear();

        TransferData.CreateAndValidatePath();
        string pathToJson = TransferData.fullPathToJson;

        if (string.IsNullOrEmpty(pathToJson))
        {
          Messages.Error($"Error: Path: {pathToJson} is empty");
        }
        else
        {
          File.WriteAllText(pathToJson, string.Empty);
          Messages.Info("File content cleared");
        }

        Messages.Info("Cleared all phrases and json file");
      }
      catch (Exception e)
      {
        Messages.Error(e.StackTrace + e.Message);
        throw;
      }
    }
  }
}
