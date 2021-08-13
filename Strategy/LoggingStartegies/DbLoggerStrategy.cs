using System;

namespace Strategy.LoggingStartegies
{
    class DbLoggerStrategy : ILoggingStrategy
    {
        public void Log(string logMessage)
        {
            GetConnection();
            ExecuteCommand(logMessage);
            DisposeConnection();
        }

        private void GetConnection()
        {
            Console.WriteLine("Получаю объект соединения с базой данных...");
            //Логика полученяи объекта базы даных
            Console.WriteLine("Объект соединения с базой данных получен.");
        }

        private void ExecuteCommand(string logMessage)
        {
            Console.WriteLine($"Выполняю комманду записи \"{logMessage}\" в базу данных...");
            //Логика выполнения комманды на базе данных - добавление {logMessage} в базу.
            Console.WriteLine("Комманда на базе данных выполнена.");
        }

        private void DisposeConnection()
        {
            Console.WriteLine("Закрываю соединения с базой данных и удаляю объект соединения...");
            //Логика закрытия и удаления соединения с базой данных 
            Console.WriteLine("Соединения с баззой данных закрыто и удалено.");
        }
    }
}
