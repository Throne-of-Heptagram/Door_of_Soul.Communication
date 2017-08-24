using System;
using System.Collections.Generic;
using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initial(CommunicationService instance)
        {
            Instance = instance;
        }

        public abstract List<Core.Internal.EndPoint> GetAllEndPoints();
        public abstract bool FindAnswer(int answerId, out Core.Answer answer);
        public abstract bool FindSoul(int soulId, out Core.Soul soul);
        public abstract bool FindAvatar(int avatarId, out Core.Avatar avatar);
        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out Core.Scene scene);

        public abstract void SendEvent(Core.Internal.EndPoint target, EndPointEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(Core.Internal.EndPoint target, EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);
    }
}
