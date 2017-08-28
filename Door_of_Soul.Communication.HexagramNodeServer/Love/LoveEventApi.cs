using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public static class LoveEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, LoveEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<LoveEventCode, LoveOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
