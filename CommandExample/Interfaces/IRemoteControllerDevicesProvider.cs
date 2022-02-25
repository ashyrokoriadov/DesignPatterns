using System.Collections.Generic;

namespace CommandExample.Interfaces
{
    public interface IRemoteControllerDevicesProvider
    {
        IEnumerable<IRemoteControllerDevice> Get();
    }
}
