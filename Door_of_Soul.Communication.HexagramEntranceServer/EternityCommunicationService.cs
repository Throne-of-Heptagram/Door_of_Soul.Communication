using Door_of_Soul.Communication.HexagramEntranceServer.Eternity;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class EternityCommunicationService : HexagramCommunicationService
    {
        public static EternityCommunicationService Instance { get; private set; }
        public static void Initial(EternityCommunicationService instance)
        {
            Instance = instance;
        }

        public bool HandleEvent(EternityEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EternityEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public bool HandleOperationResponse(EternityOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EternityOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(EternityOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
