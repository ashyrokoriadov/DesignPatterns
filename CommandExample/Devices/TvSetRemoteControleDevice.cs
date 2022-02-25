using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    class TvSetRemoteControleDevice : RemoteControlDeviceBase
    {
        public TvSetRemoteControleDevice(
            [KeyFilter(nameof(TvSetTurnOffCommand))] IRemoteControlCommand turnOffCommand,
            [KeyFilter(nameof(TvSetTurnOnCommand))] IRemoteControlCommand turnOnCommand)
            : base(turnOffCommand, turnOnCommand)
        {
            DeviceName = "Samsung";
        }
    }
}
