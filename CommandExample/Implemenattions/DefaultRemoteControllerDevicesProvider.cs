using Autofac.Features.AttributeFilters;
using CommandExample.Devices;
using CommandExample.Interfaces;
using System.Collections.Generic;

namespace CommandExample.Implemenattions
{
    class DefaultRemoteControllerDevicesProvider : IRemoteControllerDevicesProvider
    {
        private readonly IEnumerable<IRemoteControllerDevice> devices;

        public DefaultRemoteControllerDevicesProvider(
            [KeyFilter(nameof(BlueRayRemoteControlDevice))] IRemoteControllerDevice blueRay,
            [KeyFilter(nameof(TvSetRemoteControleDevice))] IRemoteControllerDevice tvSet,
            [KeyFilter(nameof(AmplifierRemoteControlDevice))] IRemoteControllerDevice amplifier,
            [KeyFilter(nameof(LightRemoteControlDevice))] IRemoteControllerDevice light,
            [KeyFilter(nameof(AirConditionRemoteControlDevice))] IRemoteControllerDevice airCondition
            )
        {
            devices = new IRemoteControllerDevice[]
                {
                    blueRay, tvSet, amplifier, light, airCondition
                };
        }

        public IEnumerable<IRemoteControllerDevice> Get() => devices;
    }
}
