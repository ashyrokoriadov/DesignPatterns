using Adapter.FilePublisher;
using System.Collections.Generic;

namespace Adapter.UnitTests.Mocks
{
    class MockFilePublisherWithException : IFilePublisher
    {
        public void Publish(IEnumerable<string> contents)
        {
            throw new System.Exception($"Exception in {nameof(MockFilePublisherWithException)}");
        }
    }
}
