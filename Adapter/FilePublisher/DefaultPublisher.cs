using System;
using System.Collections.Generic;

namespace Adapter.FilePublisher
{
    public class DefaultPublisher : IFilePublisher
    {
        public void Publish(IEnumerable<string> contents)
        {
            Console.WriteLine($"Публикую значения коллекции {nameof(contents)}...");

            foreach(var item in contents)
                Console.WriteLine(item);
        }
    }
}
