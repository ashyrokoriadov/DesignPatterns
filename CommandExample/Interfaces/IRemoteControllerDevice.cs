namespace CommandExample.Interfaces
{
    public interface IRemoteControllerDevice
    {
        string DeviceName { get; }
        IRemoteControlCommand TurnOn { get;  }
        IRemoteControlCommand TurnOff { get; }
    }
}
