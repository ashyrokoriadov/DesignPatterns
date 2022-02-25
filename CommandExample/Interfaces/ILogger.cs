using System.ComponentModel;

namespace CommandExample.Interfaces
{
    public interface ILogger : INotifyPropertyChanged
    {
        void Log(string message);
        string LogMessage { get; }
    }
}
