using System.Collections.Generic;

namespace Adapter.FilePublisher
{
    public interface IFilePublisher
    {
        void Publish(IEnumerable<string> contents);
    }
}
