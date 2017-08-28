using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Knowledge
{
    public static class KnowledgeOperationRequestApi
    {
        public static void SendOperationRequest(KnowledgeOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            KnowledgeCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
