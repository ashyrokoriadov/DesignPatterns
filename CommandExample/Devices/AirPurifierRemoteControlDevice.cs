using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class AirPurifierRemoteControlDevice : RemoteControlDeviceBase
    {
        public AirPurifierRemoteControlDevice(
            [KeyFilter(nameof(AirPurifierTurnOffCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(AirPurifierTurnOnCommand))] IRemoteControlCommand turnOnCommand)
            : base(turnOffCommand, turnOnCommand)
        {
            DeviceName = "Sharp";
        }
    }
}
