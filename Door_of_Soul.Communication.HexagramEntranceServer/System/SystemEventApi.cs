using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System
{
    public static class SystemEventApi
    {
        public static void SendEvent(TerminalEndPoint terminal, SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SystemEvent(terminal, eventCode, parameters);
        }

        public static void SendBroadcastEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.BroadcastSystemEvent(eventCode, parameters);
        }
    }
}
