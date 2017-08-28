using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
//using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public static class KnowledgeOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, KnowledgeOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<KnowledgeEventCode, KnowledgeOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
