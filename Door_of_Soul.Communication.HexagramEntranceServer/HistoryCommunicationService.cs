using Door_of_Soul.Communication.HexagramEntranceServer.History;
using Door_of_Soul.Communication.Protocol.Hexagram.History;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class HistoryCommunicationService : HexagramCommunicationService
    {
        public static HistoryCommunicationService Instance { get; private set; }
        public static void Initialize(HistoryCommunicationService instance)
        {
            Instance = instance;
        }

        public OperationReturnCode HandleEvent(HistoryEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HistoryEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public OperationReturnCode HandleOperationResponse(HistoryOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HistoryOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(HistoryOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
