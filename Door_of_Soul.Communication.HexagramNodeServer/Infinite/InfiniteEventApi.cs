using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public static class InfiniteEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, InfiniteEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<InfiniteEventCode, InfiniteOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
