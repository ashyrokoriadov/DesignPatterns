using Adapter.Adapters;
using Adapter.FilePublisher;
using Adapter.FileWriter;
using System;
using System.Collections.Generic;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileWriter = new TextFileWriter("sample.txt");

            var sampleClass = new SampleClassUsingIFileWriterInterface(fileWriter);
            sampleClass.Run(3);

            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine();

            var filePublisher = new DefaultPublisher();

            var publisherAdapter = new PublisherToWriterAdapter(filePublisher);

            Console.WriteLine($"filePublisher это IFileWriter? {filePublisher is IFileWriter}");
            Console.WriteLine($"publisherAdapter это IFileWriter? {publisherAdapter is IFileWriter}");
            Console.WriteLine();

            var sampleClassUsingAdapter = new SampleClassUsingIFileWriterInterface(publisherAdapter);
            sampleClass.Run(3);
        }
    }

    // Представим что у нас очень много классом, который используют реализацию интерфейса IFileWriter.
    // У нас нет сил и вдохновления переписывать всё классы с использования реализации IFileWriter на IFilePublisher.
    public class SampleClassUsingIFileWriterInterface
    {
        private IFileWriter _fileWriter;

        public SampleClassUsingIFileWriterInterface(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Run(int iterationsCount)
        {
            var data = GenerateData(iterationsCount);
            var result = _fileWriter.Write(data);

            Console.Write("Операция успешна: ");
            Console.WriteLine(result ? "да." : "нет.");
        }

        private IEnumerable<string> GenerateData(int iterationsCount)
        {
            var data = new List<string>();
            
            for(int i = 0; i < iterationsCount; i++)
            {
                data.Add(Guid.NewGuid().ToString());
            }

            return data;
        }
    }
}
