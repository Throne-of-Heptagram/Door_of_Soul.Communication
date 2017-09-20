using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public static class KnowledgeForwardOperationApi
    {
        public static void SendOperationRequest(KnowledgeForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.KnowledgeOperationRequest(operationCode, parameters);
        }
    }
}
