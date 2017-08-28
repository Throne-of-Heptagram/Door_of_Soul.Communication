using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, ThroneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<ThroneEventCode, ThroneOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
