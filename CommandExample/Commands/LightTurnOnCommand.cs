using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class LightTurnOnCommand : IRemoteControlCommand
    {
        private readonly LightController _lightController;

        public LightTurnOnCommand(LightController lightController)
        {
            _lightController = lightController;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _lightController != null && !_lightController.IsOn;

        public void Execute(object parameter) => _lightController.LightUp();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
