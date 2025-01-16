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

      string date = now.ToString("dd_MM_yyyy");
      string timeAndDate = now.ToString("dd_MM_yyyy_HH_mm_ss");

      string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
      string LOG_PATH = Path.Combine(projectRoot, "logs");

      try
      {
        if (!Directory.Exists(LOG_PATH))
        {
          Directory.CreateDirectory(LOG_PATH);
        }

        using (StreamWriter output = new StreamWriter(Path.Combine(LOG_PATH, date + ".log"), append: true))
        {
          output.WriteLine($"[{timeAndDate.Replace("_", ":")}]: {log ?? "No log message!"}");
        }
      }
      catch (Exception e)
      {
        Messages.Error($"{e.StackTrace} {e.Message}");
        throw;
      }
    }

    /*
     * @public
     *
     * @params {string path}
     */
    public static void ReadSync(string path)
    {
      try
      {
        Messages.Info("================Logs start================");
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
          Messages.Log(line);
        }

        Messages.Info("================Logs ended================");
      }
      catch (Exception e)
      {
        Messages.Error($"An error occurred while reading the file: {e.StackTrace} {e.Message}");
      }
    }
  }
}

