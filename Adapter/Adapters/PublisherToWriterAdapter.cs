using Adapter.FilePublisher;
using Adapter.FileWriter;
using System;
using System.Collections.Generic;

namespace Adapter.Adapters
{
    public class PublisherToWriterAdapter : IFileWriter
    {
        private IFilePublisher _filePublisher;

        public PublisherToWriterAdapter(IFilePublisher filePublisher)
        {
            _filePublisher = filePublisher;
        }

        public bool Write(IEnumerable<string> contents)
        {
            try
            {
                Console.WriteLine($"Вызов метода {nameof(Write)} класса {nameof(PublisherToWriterAdapter)}.");
                _filePublisher.Publish(contents);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
