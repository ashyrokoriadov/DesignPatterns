using System;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowFirstExample();
            ShowSecondExample();
            //ShowThirdExample();

            Console.ReadKey();
        }

        static void ShowFirstExample()
        {
            Console.WriteLine($"Первый пример.");

            var configureOptions1 = ConfigureOptions.GetInstance();
            var configureOptions2 = ConfigureOptions.GetInstance();
            //var configureOptions3 = new ConfigureOptions();

            Console.WriteLine($"Is equal: {ReferenceEquals(configureOptions1, configureOptions2)}");
            Console.WriteLine();
        }

        static void ShowSecondExample()
        {
            Console.WriteLine($"Второй пример.");

            var numbers = Enumerable.Range(0, 10).ToList();

            Parallel.ForEach(numbers, number =>
            {
                var config = ConfigureOptions.GetInstance();
            });

            Console.WriteLine();
        }

        static void ShowThirdExample()
        {
            Console.WriteLine($"Третий пример.");

            var numbers = Enumerable.Range(0, 10).ToList();

            Parallel.ForEach(numbers, number =>
            {
                var config = ConfigureOptionsSync.GetInstance();
            });

            Console.WriteLine();
        }
    }
}
