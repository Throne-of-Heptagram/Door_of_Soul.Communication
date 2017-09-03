using Door_of_Soul.Communication.HexagramEntranceServer.Destiny;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class DestinyCommunicationService : HexagramCommunicationService
    {
        public static DestinyCommunicationService Instance { get; private set; }
        public static void Initial(DestinyCommunicationService instance)
        {
            Instance = instance;
        }

        public bool HandleEvent(DestinyEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DestinyEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public bool HandleOperationResponse(DestinyOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DestinyOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(DestinyOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
