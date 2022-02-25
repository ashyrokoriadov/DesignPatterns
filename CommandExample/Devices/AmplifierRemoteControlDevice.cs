using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class AmplifierRemoteControlDevice : RemoteControlDeviceBase
    {
        public AmplifierRemoteControlDevice(
            [KeyFilter(nameof(AmplifierTurnOffCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(AmplifierTurnOnCommand))] IRemoteControlCommand turnOnCommand)
            : base(turnOffCommand, turnOnCommand)
        {
            DeviceName = "Yamaha";
        }
    }
}
