using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.WorldEvent(target, eventCode, parameters);
        }
    }
}
