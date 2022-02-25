using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class AirConditionTurnOnCommand : IRemoteControlCommand
    {
        private readonly AirCondition _airCondition;

        public AirConditionTurnOnCommand(AirCondition airCondition)
        {
            _airCondition = airCondition;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _airCondition != null && !_airCondition.IsOn;

        public void Execute(object parameter) => _airCondition.HeatUp();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
