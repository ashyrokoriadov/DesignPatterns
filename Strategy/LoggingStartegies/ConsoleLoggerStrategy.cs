using System;

namespace Strategy.LoggingStartegies
{
    class ConsoleLoggerStrategy : ILoggingStrategy
    {

        public void Log(string logMessage)
        {
            Console.WriteLine($"Вывожу сообщение на экран консоли: \"{logMessage}\"");
        }
    }
}
