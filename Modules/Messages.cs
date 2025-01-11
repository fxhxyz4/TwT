using System;

namespace TwT
{
    public class Messages
    {
       /*
       * @public
       *
       * @params {string msg}
       */
        public static void Error(string msg)
        {
            WriteMessage($"[ERROR] {msg}", ConsoleColor.Red);
        }

        /*
         * @public
         *
         * @params {string msg}
         */
        public static void Info(string msg)
        {
            WriteMessage($"[INFO] {msg}", ConsoleColor.Blue);
        }

        /*
         * @public
         *
         * @params {string msg}
         */
        public static void Debug(string msg)
        {
            WriteMessage($"[DEBUG] {msg}", ConsoleColor.Green);
        }

        /*
         * @public
         *
         * @params {string msg}
         */
        public static void Log(string msg)
        {
            WriteMessage(msg, ConsoleColor.White);
        }

        /*
         * @public
         *
         * @params {string msg}
         */
        public static void Warn(string msg)
        {
            WriteMessage($"[WARN] {msg}", ConsoleColor.Yellow);
        }

        /*
         * @private
         *
         * @params {string msg}
         * @params {ConsoleColor color}
         */
        private static void WriteMessage(string msg, ConsoleColor color)
        {
          Console.ForegroundColor = color;
          Console.WriteLine(msg);

          if (Settings.WriteLogs)
          {
            Logs.WriteSync(msg);
          }

          Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
