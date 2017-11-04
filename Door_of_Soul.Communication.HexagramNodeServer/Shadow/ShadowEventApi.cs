using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    public static class ShadowEventApi
    {
        public static void SendEvent(ShadowHexagramEntrance terminal, ShadowEventCode eventCode, Dictionary<byte, object> parameters)
        {
            terminal.SendEvent(eventCode, parameters);
        }
    }
}
