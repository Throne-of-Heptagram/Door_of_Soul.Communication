using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramNodeServer.Element
{
    public static class ElementEventApi
    {
        public static void SendEvent(ElementHexagramEntrance terminal, ElementEventCode eventCode, Dictionary<byte, object> parameters)
        {
            terminal.SendEvent(eventCode, parameters);
        }
    }
}
