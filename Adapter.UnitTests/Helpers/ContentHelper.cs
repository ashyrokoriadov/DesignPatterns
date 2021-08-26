using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter.UnitTests.Helpers
{
    static class ContentHelper
    {
        public static IEnumerable<string> GetFilled() => new[]
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            };

        public static IEnumerable<string> GetEmpty() => Enumerable.Empty<string>();

        public static IEnumerable<string> GetNull() => null;
    }
}
