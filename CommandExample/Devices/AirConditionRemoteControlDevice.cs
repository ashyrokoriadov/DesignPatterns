using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class AirConditionRemoteControlDevice : RemoteControlDeviceBase
    {
        public AirConditionRemoteControlDevice(
            [KeyFilter(nameof(AirConditionTurnOffCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(AirConditionTurnOnCommand))] IRemoteControlCommand turnOnCommand)
            : base (turnOffCommand, turnOnCommand)
        {
            DeviceName = "Hitachi";
        }      
    }
}
