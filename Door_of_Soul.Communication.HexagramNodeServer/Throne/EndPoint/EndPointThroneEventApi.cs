using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.EndPoint
{
    public static class EndPointThroneEventApi
    {
        public static void SendEvent(ThroneHexagramEntrance terminal, int endPointId, EndPointThroneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            ThroneEventApi.EndPointEvent(terminal, endPointId, eventCode, parameters);
        }
    }
}
