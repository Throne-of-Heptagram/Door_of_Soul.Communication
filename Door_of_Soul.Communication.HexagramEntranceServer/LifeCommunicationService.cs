using Door_of_Soul.Communication.HexagramEntranceServer.Life;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class LifeCommunicationService : HexagramCommunicationService
    {
        public static LifeCommunicationService Instance { get; private set; }
        public static void Initial(LifeCommunicationService instance)
        {
            Instance = instance;
        }

        protected bool HandleEvent(LifeEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return LifeEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        protected bool HandleOperationResponse(LifeOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return LifeOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(LifeOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
