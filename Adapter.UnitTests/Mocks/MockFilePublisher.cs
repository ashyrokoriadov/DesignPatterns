using Adapter.FilePublisher;
using System.Collections.Generic;

namespace Adapter.UnitTests.Mocks
{
    class MockFilePublisher : IFilePublisher
    {
        public void Publish(IEnumerable<string> contents)
        {
            return;
        }
    }
}
