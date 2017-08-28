using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public static class DestinyEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, DestinyEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<DestinyEventCode, DestinyOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
