using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class TvSetTurnOnCommand : IRemoteControlCommand
    {
        private readonly TvSet _tvSet;

        public TvSetTurnOnCommand(TvSet tvSet)
        {
            _tvSet = tvSet;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _tvSet != null && !_tvSet.IsOn;

        public void Execute(object parameter) => _tvSet.TurnOn();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
