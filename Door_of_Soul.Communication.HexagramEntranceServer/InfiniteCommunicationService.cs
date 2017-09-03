using Door_of_Soul.Communication.HexagramEntranceServer.Infinite;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class InfiniteCommunicationService : HexagramCommunicationService
    {
        public static InfiniteCommunicationService Instance { get; private set; }
        public static void Initial(InfiniteCommunicationService instance)
        {
            Instance = instance;
        }

        public bool HandleEvent(InfiniteEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return InfiniteEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public bool HandleOperationResponse(InfiniteOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return InfiniteOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(InfiniteOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
