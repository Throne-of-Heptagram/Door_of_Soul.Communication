using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public static class DestinyEventApi
    {
        public static void SendEvent(DestinyHexagramEntrance target, DestinyEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
