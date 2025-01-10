namespace TwT
{
    public class Messages
    {
        /*
         * Error
         *
         * @params {string msg}
         */
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\n[ERROR] {msg}\n\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        /*
         * Info
         *
         * @params {string msg}
         */
        public static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[INFO] {msg}");

            Console.ForegroundColor = ConsoleColor.White;
        }

        /*
         * Debug
         *
         * @params {string msg}
         */
        public static void Debug(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n[DEBUG] {msg}\n\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        /*
         * Log
         *
         * @params {string msg}
         */
        public static void Log(string msg)
        {
            Console.WriteLine($"[LOG] {msg}");
        }

        /*
         * Warn
         *
         * @params {string msg}
         */
        public static void Warn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[WARN] {msg}\n");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
