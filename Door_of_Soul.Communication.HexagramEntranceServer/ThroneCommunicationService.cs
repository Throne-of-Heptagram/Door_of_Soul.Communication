using Door_of_Soul.Communication.HexagramEntranceServer.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class ThroneCommunicationService : HexagramCommunicationService
    {
        public static ThroneCommunicationService Instance { get; private set; }
        public static void Initial(ThroneCommunicationService instance)
        {
            Instance = instance;
        }

        protected bool HandleEvent(ThroneEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return ThroneEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        protected bool HandleOperationResponse(ThroneOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return ThroneOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(ThroneOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
