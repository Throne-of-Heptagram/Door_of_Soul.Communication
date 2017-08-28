using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public static class EternityEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, EternityEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<EternityEventCode, EternityOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
