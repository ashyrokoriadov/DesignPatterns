using Autofac.Features.AttributeFilters;
using CommandExample.Devices;
using CommandExample.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CommandExample.ViewModels
{
    class RemoteControleViewModel 
    {
        private IRemoteControllerDevice _emptyDevice;
        private IRemoteControllerDevice[] _devices;

        public RemoteControleViewModel(
            IRemoteControllerDevicesProvider deviceProvider,
            ILogger logger,
            [KeyFilter(nameof(EmptyRemoteControlDevice))]IRemoteControllerDevice emptyDevice)
        {
            _devices = deviceProvider.Get().ToArray();
            _emptyDevice = emptyDevice;
            LogConsole = logger;
            LogConsole.PropertyChanged += LogConsoleChanged;
        }

        public ILogger LogConsole { get; init; }

        public string DeviceOneName => GetNameByIndex(0);
        public IRemoteControlCommand DeviceOneTurnOn => GetTurnOnCommandByIndex(0);
        public IRemoteControlCommand DeviceOneTurnOff => GetTurnOffCommandByIndex(0);

        public string DeviceTwoName => GetNameByIndex(1);
        public IRemoteControlCommand DeviceTwoTurnOn => GetTurnOnCommandByIndex(1);
        public IRemoteControlCommand DeviceTwoTurnOff => GetTurnOffCommandByIndex(1);

        public string DeviceThreeName => GetNameByIndex(2);
        public IRemoteControlCommand DeviceThreeTurnOn => GetTurnOnCommandByIndex(2);
        public IRemoteControlCommand DeviceThreeTurnOff => GetTurnOffCommandByIndex(2);

        public string DeviceFourName => GetNameByIndex(3);
        public IRemoteControlCommand DeviceFourTurnOn => GetTurnOnCommandByIndex(3);
        public IRemoteControlCommand DeviceFourTurnOff => GetTurnOffCommandByIndex(3);

        public string DeviceFiveName => GetNameByIndex(4);
        public IRemoteControlCommand DeviceFiveTurnOn => GetTurnOnCommandByIndex(4);
        public IRemoteControlCommand DeviceFiveTurnOff => GetTurnOffCommandByIndex(4);

        private string GetNameByIndex(int index)
        {
            try
            {
                var device = _devices[index];
                return device.DeviceName;
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is IndexOutOfRangeException)
                {
                    return _emptyDevice.DeviceName;
                }

                throw;
            }
        }

        private IRemoteControlCommand GetTurnOnCommandByIndex(int index)
        {
            try
            {
                var device = _devices[index];
                return device.TurnOn;
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is IndexOutOfRangeException)
                {
                    return _emptyDevice.TurnOn;
                }

                throw;
            }
        }

        private IRemoteControlCommand GetTurnOffCommandByIndex(int index)
        {
            try
            {
                var device = _devices[index];
                return device.TurnOff;
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is IndexOutOfRangeException)
                {
                    return _emptyDevice.TurnOff;
                }

                throw;
            }
        }

        private void LogConsoleChanged(object sender, PropertyChangedEventArgs e)
        {
            foreach(var device in _devices)
            {
                device.TurnOn.RaiseCanExecuteChanged();
                device.TurnOff.RaiseCanExecuteChanged();
            }
        }
    }
}
