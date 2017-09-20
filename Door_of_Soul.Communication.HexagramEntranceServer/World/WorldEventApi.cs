using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(TerminalEndPoint terminal, VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.WorldEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.BroadcastWorldEvent(target, eventCode, parameters);
        }
    }
}
