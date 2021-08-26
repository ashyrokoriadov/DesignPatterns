using System;

namespace Strategy.LoggingStartegies
{
    class FileLoggerStrategy : ILoggingStrategy
    {
       
        public void Log(string logMessage)
        {
            CreateOrOpenLogFile();
            WriteToFile(logMessage);
            CloseFile();
        }

        private void CreateOrOpenLogFile()
        {
            Console.WriteLine("Открываю или создаю файл...");
            //Логика открытия или создания файла
            Console.WriteLine("Файл создан / открыт.");
        }

        private void WriteToFile(string logMessage)
        {
            Console.WriteLine($"Записываю данные \"{logMessage}\" в файл...");
            //Логика записи данных в файл - добавление {logMessage} в текстовый файл.
            Console.WriteLine("Данные записаны.");
        }

        private void CloseFile()
        {
            Console.WriteLine("Закрываю файл...");
            //Логика закрытия файла 
            Console.WriteLine("Файл закрыт.");
        }
    }
}
