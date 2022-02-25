using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class LightRemoteControlDevice : RemoteControlDeviceBase
    {
        public LightRemoteControlDevice(
            [KeyFilter(nameof(LightTurnOffCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(LightTurnOnCommand))] IRemoteControlCommand turnOnCommand)
            : base(turnOffCommand, turnOnCommand)
        {
            DeviceName = "IKEA";
        }
    }
}
