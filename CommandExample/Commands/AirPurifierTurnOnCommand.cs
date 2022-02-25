using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class AirPurifierTurnOnCommand : IRemoteControlCommand
    {
        private readonly AirPurifier _airPurifier;

        public AirPurifierTurnOnCommand(AirPurifier airPurifier)
        {
            _airPurifier = airPurifier;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _airPurifier != null && !_airPurifier.IsOn;

        public void Execute(object parameter) => _airPurifier.Purify();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
