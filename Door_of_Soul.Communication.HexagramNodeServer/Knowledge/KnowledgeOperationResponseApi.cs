using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
//using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public static class KnowledgeOperationResponseApi
    {
        public static void SendOperationResponse(KnowledgeHexagramEntrance terminal, KnowledgeOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            terminal.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
