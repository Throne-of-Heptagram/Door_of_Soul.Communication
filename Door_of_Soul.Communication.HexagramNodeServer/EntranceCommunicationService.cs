using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class EntranceCommunicationService<TEventCode, TOperationCode>
    {
        public static EntranceCommunicationService<TEventCode, TOperationCode> Instance { get; private set; }
        public static void Initial(EntranceCommunicationService<TEventCode, TOperationCode> instance)
        {
            Instance = instance;
        }

        protected bool HandleOperationRequest(TerminalHexagramEntrance hexagramEntrance, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramOperationRequestRouter<TOperationCode>.Instance.Route(hexagramEntrance, operationCode, parameters, out errorMessage);
        }

        public abstract void SendEvent(TerminalHexagramEntrance target, TEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(TerminalHexagramEntrance target, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out Core.Scene scene);
    }
}
