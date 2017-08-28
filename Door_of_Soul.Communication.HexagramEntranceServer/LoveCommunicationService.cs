using Door_of_Soul.Communication.HexagramEntranceServer.Love;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class LoveCommunicationService : HexagramCommunicationService
    {
        public static LoveCommunicationService Instance { get; private set; }
        public static void Initial(LoveCommunicationService instance)
        {
            Instance = instance;
        }

        protected bool HandleEvent(LoveEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return LoveEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        protected bool HandleOperationResponse(LoveOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return LoveOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(LoveOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
