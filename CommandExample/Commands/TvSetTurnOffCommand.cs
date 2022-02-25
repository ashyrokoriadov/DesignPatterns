using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class TvSetTurnOffCommand : IRemoteControlCommand
    {
        private readonly TvSet _tvSet;

        public TvSetTurnOffCommand(TvSet tvSet)
        {
            _tvSet = tvSet;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _tvSet != null && _tvSet.IsOn;

        public void Execute(object parameter) => _tvSet.TurnOff();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
