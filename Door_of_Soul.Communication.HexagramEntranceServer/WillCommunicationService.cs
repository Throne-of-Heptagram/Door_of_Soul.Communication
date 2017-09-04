using Door_of_Soul.Communication.HexagramEntranceServer.Will;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class WillCommunicationService : HexagramCommunicationService
    {
        public static WillCommunicationService Instance { get; private set; }
        public static void Initialize(WillCommunicationService instance)
        {
            Instance = instance;
        }

        public bool HandleEvent(WillEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return WillEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public bool HandleOperationResponse(WillOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return WillOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(WillOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
