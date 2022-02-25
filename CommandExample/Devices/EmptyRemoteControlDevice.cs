using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class EmptyRemoteControlDevice : RemoteControlDeviceBase
    {
        public EmptyRemoteControlDevice(
            [KeyFilter(nameof(EmptyCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(EmptyCommand))] IRemoteControlCommand turnOnCommand)
            : base(turnOffCommand, turnOnCommand)
        {
            DeviceName = string.Empty;
        }
    }
}
