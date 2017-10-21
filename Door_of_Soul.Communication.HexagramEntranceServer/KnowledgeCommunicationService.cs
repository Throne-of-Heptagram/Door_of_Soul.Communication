using Door_of_Soul.Communication.HexagramEntranceServer.Knowledge;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class KnowledgeCommunicationService : HexagramCommunicationService
    {
        public static KnowledgeCommunicationService Instance { get; private set; }
        public static void Initialize(KnowledgeCommunicationService instance)
        {
            Instance = instance;
        }

        public OperationReturnCode HandleEvent(KnowledgeEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return KnowledgeEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public OperationReturnCode HandleOperationResponse(KnowledgeOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return KnowledgeOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(KnowledgeOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
