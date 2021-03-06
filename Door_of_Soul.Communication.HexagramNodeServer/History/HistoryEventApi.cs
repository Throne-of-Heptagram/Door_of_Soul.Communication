﻿using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    public static class HistoryEventApi
    {
        public static void SendEvent(HistoryHexagramEntrance target, HistoryEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
