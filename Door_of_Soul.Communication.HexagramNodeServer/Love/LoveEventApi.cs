using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public static class LoveEventApi
    {
        public static void SendEvent(LoveHexagramEntrance target, LoveEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
