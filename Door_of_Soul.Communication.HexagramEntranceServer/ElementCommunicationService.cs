using Door_of_Soul.Communication.HexagramEntranceServer.Element;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class ElementCommunicationService : HexagramCommunicationService
    {
        public static ElementCommunicationService Instance { get; private set; }
        public static void Initialize(ElementCommunicationService instance)
        {
            Instance = instance;
        }

        public OperationReturnCode HandleEvent(ElementEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return ElementEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public OperationReturnCode HandleOperationResponse(ElementOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return ElementOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(ElementOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
