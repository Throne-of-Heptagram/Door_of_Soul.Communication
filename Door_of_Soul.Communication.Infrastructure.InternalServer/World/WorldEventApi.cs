using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.WorldEvent(target, eventCode, parameters);
        }
    }
}
