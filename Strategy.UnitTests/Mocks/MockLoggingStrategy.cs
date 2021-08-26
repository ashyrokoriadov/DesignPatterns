using Strategy.LoggingStartegies;

namespace Strategy.UnitTests.Mocks
{
    class MockLoggingStrategy : ILoggingStrategy
    {
        public void Log(string logMessage)
        {
            DoNothing();
        }

        private void DoNothing()
        { }
    }
}
