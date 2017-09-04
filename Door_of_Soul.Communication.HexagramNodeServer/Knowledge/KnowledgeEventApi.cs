using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public static class KnowledgeEventApi
    {
        public static void SendEvent(KnowledgeHexagramEntrance target, KnowledgeEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
