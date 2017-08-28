using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramNodeServer.Element
{
    public static class ElementEventApi
    {
        public static void SendEvent(TerminalHexagramEntrance target, ElementEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<ElementEventCode, ElementOperationCode>.Instance.SendEvent(target, eventCode, parameters);
        }
    }
}
