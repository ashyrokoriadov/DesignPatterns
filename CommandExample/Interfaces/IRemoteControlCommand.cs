using System.Windows.Input;

namespace CommandExample.Interfaces
{
    public interface IRemoteControlCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    } 
}
