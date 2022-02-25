using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class BlueRayRemoteControlDevice : RemoteControlDeviceBase
    {
        public BlueRayRemoteControlDevice(
            [KeyFilter(nameof(BlueRayTurnOffCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(BlueRayTurnOnCommand))] IRemoteControlCommand turnOnCommand)
            : base(turnOffCommand, turnOnCommand)
        {
            DeviceName = "SONY";
        }
    }
}
