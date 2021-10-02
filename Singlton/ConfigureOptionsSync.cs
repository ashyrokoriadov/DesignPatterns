using System;

namespace Singleton
{
    public class ConfigureOptionsSync
    {
        private static ConfigureOptionsSync _instance;
        private static object syncObject = new object();
        public static ConfigureOptionsSync GetInstance()
        {
            lock (syncObject)
            {
                if (_instance == null)
                {
                    _instance = Create();
                }

                Console.WriteLine($"Возвращаю существующий экземляр {nameof(ConfigureOptionsSync)}.");
                return _instance;
            }
        }

        private ConfigureOptionsSync()
        { }

        public string ProtocolType => "Sip";

        public string PhoneNumber => "1234";

        public string ServerAddress => "10.10.10.89";


        private static ConfigureOptionsSync Create()
        {
            if (_isCreated)
                Console.WriteLine("Экземляр уже создан!");

            _isCreated = true;
            Console.WriteLine($"Создаю новый экземляр {nameof(ConfigureOptionsSync)}.");
            return new ConfigureOptionsSync();
        }

        private static bool _isCreated = false;
    }
}
