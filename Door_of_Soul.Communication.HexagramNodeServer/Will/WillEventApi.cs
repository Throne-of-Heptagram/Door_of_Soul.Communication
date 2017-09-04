using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public static class WillEventApi
    {
        public static void SendEvent(WillHexagramEntrance target, WillEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
