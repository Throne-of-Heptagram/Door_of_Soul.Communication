using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initial(CommunicationService instance)
        {
            Instance = instance;
        }

        public abstract List<TerminalEndPoint> AllEndPoints { get; }
        public abstract List<TerminalEndPoint> AllProxyEndPoints { get; }
        public abstract List<TerminalEndPoint> AllSceneEndPoints { get; }
        public abstract bool FindEndPoint(int endPointId, out TerminalEndPoint endPoint);
        public abstract bool FindAnswer(int answerId, out Core.Answer answer);
        public abstract bool FindSoul(int soulId, out Core.Soul soul);
        public abstract bool FindAvatar(int avatarId, out Core.Avatar avatar);
        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out Core.Scene scene);

        protected bool HandleOperationRequest(TerminalEndPoint endPoint, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationRequestRouter.Instance.Route(endPoint, operationCode, parameters, out errorMessage);
        }

        public abstract void SendEvent(TerminalEndPoint target, EndPointEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(TerminalEndPoint target, EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);
    }
}
