using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class AmplifierTurnOffCommand : IRemoteControlCommand
    {
        private readonly Amplifier _amplifier;

        public AmplifierTurnOffCommand(Amplifier amplifier)
        {
            _amplifier = amplifier;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _amplifier != null && _amplifier.IsOn;

        public void Execute(object parameter) => _amplifier.PlugOut();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
