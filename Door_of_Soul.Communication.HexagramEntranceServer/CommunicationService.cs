using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.HexagramEntranceServer;
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

        public abstract bool FindEndPoint(int endPointId, out TerminalEndPoint endPoint);
        public abstract bool FindAnswer(int answerId, out VirtualAnswer answer);
        public abstract bool FindSoul(int soulId, out VirtualSoul soul);
        public abstract bool FindAvatar(int avatarId, out VirtualAvatar avatar);
        public abstract bool FindWorld(int worldId, out VirtualWorld world);
        public abstract bool FindScene(int sceneId, out VirtualScene scene);

        public bool HandleOperationRequest(TerminalEndPoint endPoint, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationRequestRouter.Instance.Route(endPoint, operationCode, parameters, out errorMessage);
        }
    }
}
