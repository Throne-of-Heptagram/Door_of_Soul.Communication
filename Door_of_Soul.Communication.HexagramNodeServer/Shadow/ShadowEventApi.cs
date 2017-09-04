using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    public static class ShadowEventApi
    {
        public static void SendEvent(ShadowHexagramEntrance target, ShadowEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
