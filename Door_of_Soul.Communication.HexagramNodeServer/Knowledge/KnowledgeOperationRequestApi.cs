using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public static class KnowledgeOperationRequestApi
    {
        public static void SendOperationRequest(KnowledgeOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.KnowledgeOperationRequest(operationCode, parameters);
        }
    }
}
