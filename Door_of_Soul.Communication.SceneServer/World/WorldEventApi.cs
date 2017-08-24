using Door_of_Soul.Communication.SceneServer.Device;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.WorldEvent(target, eventCode, parameters);
        }
    }
}
