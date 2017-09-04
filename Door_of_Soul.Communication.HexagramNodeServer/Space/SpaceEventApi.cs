using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public static class SpaceEventApi
    {
        public static void SendEvent(SpaceHexagramEntrance target, SpaceEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
