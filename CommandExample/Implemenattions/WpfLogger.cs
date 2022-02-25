using CommandExample.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CommandExample.Implemenattions
{
    class WpfLogger : ILogger
    {
        private StringBuilder _textHolder = new StringBuilder();
        private static object _syncObject = new object();
        private static WpfLogger _instance;

        public WpfLogger() { }
        //private WpfLogger() { }

        public static WpfLogger GetInstance()
        {
            lock (_syncObject)
            {
                if (_instance == null)
                {
                    _instance = new WpfLogger();
                }

                return _instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _logMessage;
        public string LogMessage
        {
            get => _logMessage;
            set
            {
                _logMessage = value;
                NotifyPropertyChanged();
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Log(string message)
        {
            try
            {
                lock (_syncObject)
                {
                    _textHolder.Append(message);
                    _textHolder.AppendLine();
                    LogMessage = _textHolder.ToString();
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
    }
}
