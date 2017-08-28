using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public static class WillEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, WillEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<WillEventCode, WillOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
