using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Soul
{
    public static class SoulEventApi
    {
        public static void SendEvent(TerminalEndPoint terminal, VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SoulEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.BroadcastSoulEvent(target, eventCode, parameters);
        }
    }
}
