using System;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace TwT
{
  // Transfered data to json file
  // Copied data for new list = _jsonList
  public class TransferData
  {
    public static List<JsonList> _jsonList = new List<JsonList>();
    public static string fullPathToJson = "";
    public class JsonList
    {
      public string Date { get; set; }
      public string Command { get; set; }
      public string Phrase { get; set; }
    }

    public static void CreateAndValidatePath()
    {
      string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
      string pathToJsonDirectory = Path.Combine(projectRoot, "data");

      string pathToJsonFile = Path.Combine(pathToJsonDirectory, "phrases.json");
      string directory = Path.GetDirectoryName(pathToJsonFile);

      if (!Directory.Exists(directory))
      {
        Directory.CreateDirectory(pathToJsonDirectory);
      }

      if (!File.Exists(pathToJsonFile))
      {
        using (File.Create(pathToJsonFile)) { }
      }

      // fullPathToJson method with full path to json file
      fullPathToJson = pathToJsonFile;
    }

    public static void CopiedData()
    {
      foreach (var v in MonitoringSettings.MonitoredPhrases)
      {
        _jsonList.Add(new JsonList
        {
          Date = v.Date,
          Command = v.Command,
          Phrase = v.Phrase
        });

        CreateAndValidatePath();

        try
        {
          string json = JsonConvert.SerializeObject(_jsonList, Formatting.Indented);
          Transfer(json, fullPathToJson);
        }
        catch (Exception e)
        {
          Messages.Error(e.StackTrace + e.Message);
          throw;
        }

        // DEBUG LOG INFO
        Console.WriteLine("date: " + v.Date);
        Console.WriteLine("command: " + v.Command);
        Console.WriteLine("phrase: " + v.Phrase);
      }
    }

    public static void Transfer(string json, string path)
    {
      File.WriteAllText(path, json);
    }
  }
}

