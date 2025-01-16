using System;

namespace TwT
{
  public class HelpCommand : ICommand
  {
    public void Execute(string[] args)
    {
      Messages.Warn("=======Available Commands=======");
      Messages.Log("exit - Exit");
      Messages.Log("help - Display this help information");
      Messages.Log("disconnect - Disconnect");
      Messages.Log("clear - Cleared all phrases and json file");

      Console.WriteLine("\n");

      Messages.Log("echo - Write echo message");
      Messages.Log("Use: echo {message}");
      Messages.Log("Example: echo ppL TeaTime");

      Console.WriteLine("\n");

      Messages.Log("open - Open log file in terminal");
      Messages.Log("Use: open {path to log file}");
      Messages.Log("Example: open logs/01_01_2025.log");

      Console.WriteLine("\n");

      Messages.Log("ban - Banned users by phrase");
      Messages.Log("Use: ban {phrase}");
      Messages.Log("Example: ban KEKW");

      Console.WriteLine("\n");

      Messages.Log("mute - Mute users by phrase (Default time: 10s)");
      Messages.Log("Use: mute {time} {phrase}");
      Messages.Log("Example: mute 100 KEKW");

      Console.WriteLine("\n");

      Messages.Log("spam - Spam phrase by count (Default count: 5)");
      Messages.Log("Use: spam {count} {phrase}");
      Messages.Log("Example: spam 3 KEKW");

      Console.WriteLine("\n");

      Messages.Log("pyramid - Created pyramid by phrase");
      Messages.Log("Use: pyramid {phrase}");
      Messages.Log("Example: pyramid KEKW");

      Console.WriteLine("\n");

      Messages.Warn("=======Txt files=======");
      Messages.Log("spamf - Spam phrase by file");
      Messages.Log("Use: spamf {file}");
      Messages.Log("Example: spamf ./file.txt");

      Console.WriteLine("\n");

      Messages.Log("banu - Ban users by file");
      Messages.Log("Use: banu {path to file with usernames}");
      Messages.Log("Example: banu ./userlist.txt");

      Console.WriteLine("\n");

      Messages.Log("banp - Load ban phrases from file");
      Messages.Log("Use: banp {path to file with banned phrases}");
      Messages.Log("Example: banp ./banphrase.txt");

      Console.WriteLine("\n");

      Messages.Log("muteu - Mute users by file");
      Messages.Log("Use: muteu {time} {path to file with usernames}");
      Messages.Log("Example: muteu 3000 ./userlist.txt");

      Console.WriteLine("\n");

      Messages.Log("muteu - Load mute phrases from file");
      Messages.Log("Use: muteu {time} {path to file with phrases}");
      Messages.Log("Example: muteu 3000 ./mutephrase.txt");

      Console.WriteLine("\n");
    }
  }
}

