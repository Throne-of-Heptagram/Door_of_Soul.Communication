using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    public static class HistoryEventApi
    {
        public static void SendEvent(HistoryHexagramEntrance terminal, HistoryEventCode eventCode, Dictionary<byte, object> parameters)
        {
            terminal.SendEvent(eventCode, parameters);
        }
    }
}
