using System;
using System.IO;

namespace TwT
{
  class Logs
  {
    /*
     * @private
     *
     * @params {string log}
     */
    public static void WriteSync(string log)
    {
      DateTime now = DateTime.Now;
      string fullDate = now.ToString("dd_MM_yyyy");

      string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
      string LOG_PATH = Path.Combine(projectRoot, "Logs");

      try
      {
        if (!Directory.Exists(LOG_PATH))
        {
          Directory.CreateDirectory(LOG_PATH);
        }

        using (StreamWriter output = new StreamWriter(Path.Combine(LOG_PATH, fullDate + ".log"), append: true))
        {
          output.WriteLine($"[{fullDate.Replace("_", ":")}]: {log ?? "No log message!"}");
        }
      }
      catch (Exception e)
      {
        Messages.Error($"{e.StackTrace} {e.Message}");
        throw;
      }
    }

    /*
     * @private
     *
     * mb later
     */
    // private static void ReadSync()
    // {
    //   Messages.Info("Write path for open log file:");
    //   Console.WriteLine("\n");
    //
    //   string path = Console.ReadLine();
    //
    //   if (!File.Exists(path))
    //   {
    //     Messages.Error($"File {path} does not exist!");
    //     return;
    //   }
    //
    //   try
    //   {
    //     string[] lines = File.ReadAllLines(path);
    //
    //     foreach (string line in lines)
    //     {
    //       Console.WriteLine(line);
    //     }
    //   }
    //   catch (Exception e)
    //   {
    //     Messages.Error($"An error occurred while reading the file: {e.StackTrace} {e.Message}");
    //   }
    // }
  }
}

