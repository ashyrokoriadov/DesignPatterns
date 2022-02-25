using CommandExample.Devices;
using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class BlueRayTurnOffCommand : IRemoteControlCommand
    {
        private readonly BlueRayPlayer _player;

        public BlueRayTurnOffCommand(BlueRayPlayer player)
        {
            _player = player;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _player != null && _player.IsOn;

        public void Execute(object parameter) =>_player.Stop();

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
