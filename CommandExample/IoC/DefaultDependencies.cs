using Autofac;
using Autofac.Features.AttributeFilters;
using CommandExample.Commands;
using CommandExample.Devices;
using CommandExample.Implemenattions;
using CommandExample.Interfaces;
using CommandExample.ViewModels;

namespace CommandExample.IoC
{
    static class DefaultDependencies
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterDevices(builder);
            RegisterCommands(builder);
            RegisterRemoteControllerDevices(builder);

            builder.RegisterType<DefaultRemoteControllerDevicesProvider>()
              .As<IRemoteControllerDevicesProvider>()
              .WithAttributeFiltering();

            builder.RegisterType<RemoteControleViewModel>().AsSelf().WithAttributeFiltering();
            builder.RegisterType<WpfLogger>().As<ILogger>().SingleInstance();
        }

        private static void RegisterDevices(ContainerBuilder builder)
        {
            builder.RegisterType<AirCondition>().AsSelf().SingleInstance();
            builder.RegisterType<AirPurifier>().AsSelf().SingleInstance();
            builder.RegisterType<Amplifier>().AsSelf().SingleInstance();
            builder.RegisterType<BlueRayPlayer>().AsSelf().SingleInstance();
            builder.RegisterType<LightController>().AsSelf().SingleInstance();
            builder.RegisterType<TvSet>().AsSelf().SingleInstance();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<AirConditionTurnOffCommand>()
               .Named<IRemoteControlCommand>(nameof(AirConditionTurnOffCommand));
            builder.RegisterType<AirConditionTurnOnCommand>()
                .Named<IRemoteControlCommand>(nameof(AirConditionTurnOnCommand));
            builder.RegisterType<AirPurifierTurnOffCommand>()
                .Named<IRemoteControlCommand>(nameof(AirPurifierTurnOffCommand));
            builder.RegisterType<AirPurifierTurnOnCommand>()
                .Named<IRemoteControlCommand>(nameof(AirPurifierTurnOnCommand));
            builder.RegisterType<AmplifierTurnOffCommand>()
               .Named<IRemoteControlCommand>(nameof(AmplifierTurnOffCommand));
            builder.RegisterType<AmplifierTurnOnCommand>()
               .Named<IRemoteControlCommand>(nameof(AmplifierTurnOnCommand));
            builder.RegisterType<BlueRayTurnOffCommand>()
                .Named<IRemoteControlCommand>(nameof(BlueRayTurnOffCommand));
            builder.RegisterType<BlueRayTurnOnCommand>()
                .Named<IRemoteControlCommand>(nameof(BlueRayTurnOnCommand));
            builder.RegisterType<EmptyCommand>()
               .Named<IRemoteControlCommand>(nameof(EmptyCommand));
            builder.RegisterType<LightTurnOffCommand>()
               .Named<IRemoteControlCommand>(nameof(LightTurnOffCommand));
            builder.RegisterType<LightTurnOnCommand>()
                .Named<IRemoteControlCommand>(nameof(LightTurnOnCommand));
            builder.RegisterType<TvSetTurnOffCommand>()
              .Named<IRemoteControlCommand>(nameof(TvSetTurnOffCommand));
            builder.RegisterType<TvSetTurnOnCommand>()
                .Named<IRemoteControlCommand>(nameof(TvSetTurnOnCommand));
        }
   
        private static void RegisterRemoteControllerDevices(ContainerBuilder builder)
        {
            builder.RegisterType<AirConditionRemoteControlDevice>()
           .Named<IRemoteControllerDevice>(nameof(AirConditionRemoteControlDevice))
           .WithAttributeFiltering();
            builder.RegisterType<AirPurifierRemoteControlDevice>()
            .Named<IRemoteControllerDevice>(nameof(AirPurifierRemoteControlDevice))
            .WithAttributeFiltering();
            builder.RegisterType<AmplifierRemoteControlDevice>()
            .Named<IRemoteControllerDevice>(nameof(AmplifierRemoteControlDevice))
            .WithAttributeFiltering();
            builder.RegisterType<BlueRayRemoteControlDevice>()
            .Named<IRemoteControllerDevice>(nameof(BlueRayRemoteControlDevice))
            .WithAttributeFiltering();
            builder.RegisterType<EmptyRemoteControlDevice>()
            .Named<IRemoteControllerDevice>(nameof(EmptyRemoteControlDevice))
            .WithAttributeFiltering();
            builder.RegisterType<LightRemoteControlDevice>()
            .Named<IRemoteControllerDevice>(nameof(LightRemoteControlDevice))
            .WithAttributeFiltering();
            builder.RegisterType<TvSetRemoteControleDevice>()
            .Named<IRemoteControllerDevice>(nameof(TvSetRemoteControleDevice))
            .WithAttributeFiltering();
        }
    }
}
