using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class AirPurifierTurnOffCommand : IRemoteControlCommand
    {
        private readonly AirPurifier _airPurifier;

        public AirPurifierTurnOffCommand(AirPurifier airPurifier)
        {
            _airPurifier = airPurifier;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _airPurifier != null && _airPurifier.IsOn;

        public void Execute(object parameter) => _airPurifier.StopPurifying();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
