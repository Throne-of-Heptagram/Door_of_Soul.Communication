using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    public static class ShadowEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, ShadowEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<ShadowEventCode, ShadowOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
