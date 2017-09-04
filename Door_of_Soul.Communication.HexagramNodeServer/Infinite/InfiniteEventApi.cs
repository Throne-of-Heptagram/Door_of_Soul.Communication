using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public static class InfiniteEventApi
    {
        public static void SendEvent(InfiniteHexagramEntrance target, InfiniteEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
