using System;

namespace Singleton
{
    public class ConfigureOptions
    {
        private static ConfigureOptions _instance;
        public static ConfigureOptions GetInstance()
        {
            if (_instance == null)
            {
                _instance = Create();
            }

            Console.WriteLine($"Возвращаю существующий экземляр {nameof(ConfigureOptions)}.");
            return _instance;
        }

        private ConfigureOptions()
        { }

        public string ProtocolType => "Sip";

        public string PhoneNumber => "1234";

        public string ServerAddress => "10.10.10.89";


        private static ConfigureOptions Create()
        {
            if (_isCreated)
                Console.WriteLine("Экземляр уже создан!");

            _isCreated = true;

            Console.WriteLine($"Создаю новый экземляр {nameof(ConfigureOptions)}.");
            return new ConfigureOptions();
        }

        private static bool _isCreated = false;        
    }
}
