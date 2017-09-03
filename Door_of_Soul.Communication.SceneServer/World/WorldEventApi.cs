using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Communication.SceneServer.Device;
using Door_of_Soul.Core.SceneServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.WorldEvent(target, eventCode, parameters);
        }
    }
}
