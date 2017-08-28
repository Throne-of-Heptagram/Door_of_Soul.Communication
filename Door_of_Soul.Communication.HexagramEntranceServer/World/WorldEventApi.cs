using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.WorldEvent(target, eventCode, parameters);
        }
    }
}
