using Autofac.Features.AttributeFilters;
using CommandExample.Devices;
using CommandExample.Interfaces;
using System.Collections.Generic;

namespace CommandExample.Implemenattions
{
    class ThreeDevicesRemoteControllerDevicesProvider : IRemoteControllerDevicesProvider
    {
        private readonly IEnumerable<IRemoteControllerDevice> devices;

        public ThreeDevicesRemoteControllerDevicesProvider(
            [KeyFilter(nameof(BlueRayRemoteControlDevice))] IRemoteControllerDevice blueRay,
            [KeyFilter(nameof(TvSetRemoteControleDevice))] IRemoteControllerDevice tvSet,
            [KeyFilter(nameof(AmplifierRemoteControlDevice))] IRemoteControllerDevice amplifier
            )
        {
            devices = new IRemoteControllerDevice[]
                {
                    blueRay, tvSet, amplifier
                };
        }

        public IEnumerable<IRemoteControllerDevice> Get() => devices;
    }
}
