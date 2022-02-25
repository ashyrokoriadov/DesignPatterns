using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    abstract class RemoteControlDeviceBase : IRemoteControllerDevice
    {
        public RemoteControlDeviceBase(IRemoteControlCommand turnOffCommand, IRemoteControlCommand turnOnCommand)
        {
            TurnOff = turnOffCommand;
            TurnOn = turnOnCommand;
        }

        public string DeviceName { get; protected set; }

        public IRemoteControlCommand TurnOn { get; init; }

        public IRemoteControlCommand TurnOff { get; init; }
    }
}
