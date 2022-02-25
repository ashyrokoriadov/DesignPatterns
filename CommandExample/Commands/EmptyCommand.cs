using CommandExample.Interfaces;
using System;

namespace CommandExample.Commands
{
    class EmptyCommand : IRemoteControlCommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => false;

        public void Execute(object parameter)
        {
            return;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
