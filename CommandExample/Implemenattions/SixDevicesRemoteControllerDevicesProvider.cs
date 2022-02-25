using Autofac.Features.AttributeFilters;
using CommandExample.Devices;
using CommandExample.Interfaces;
using System.Collections.Generic;

namespace CommandExample.Implemenattions
{
    class SixDevicesRemoteControllerDevicesProvider : IRemoteControllerDevicesProvider
    {
        private readonly IEnumerable<IRemoteControllerDevice> devices;

        public SixDevicesRemoteControllerDevicesProvider(
            [KeyFilter(nameof(BlueRayRemoteControlDevice))] IRemoteControllerDevice blueRay,
            [KeyFilter(nameof(TvSetRemoteControleDevice))] IRemoteControllerDevice tvSet,
            [KeyFilter(nameof(AmplifierRemoteControlDevice))] IRemoteControllerDevice amplifier,
            [KeyFilter(nameof(LightRemoteControlDevice))] IRemoteControllerDevice light,
            [KeyFilter(nameof(AirConditionRemoteControlDevice))] IRemoteControllerDevice airCondition,
            [KeyFilter(nameof(AirPurifierRemoteControlDevice))] IRemoteControllerDevice airPurifier
            )
        {
            devices = new IRemoteControllerDevice[]
                {
                    blueRay, tvSet, amplifier, light, airCondition, airPurifier
                };
        }

        public IEnumerable<IRemoteControllerDevice> Get() => devices;
    }
}
