using Door_of_Soul.Communication.HexagramEntranceServer.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class SpaceCommunicationService : HexagramCommunicationService
    {
        public static SpaceCommunicationService Instance { get; private set; }
        public static void Initial(SpaceCommunicationService instance)
        {
            Instance = instance;
        }

        protected bool HandleEvent(SpaceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return SpaceEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        protected bool HandleOperationResponse(SpaceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return SpaceOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(SpaceOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
