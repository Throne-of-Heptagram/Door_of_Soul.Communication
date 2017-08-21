using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initial(CommunicationService instance)
        {
            Instance = instance;
        }

        public event Action<bool> OnConnectStatusChanged;

        private bool serverConnected;
        public bool ServerConnected
        {
            get { return serverConnected; }
            protected set
            {
                serverConnected = value;
                OnConnectStatusChanged?.Invoke(serverConnected);
            }
        }

        public abstract Core.Device GetDevice();
        public abstract bool FindAnswer(int answerId, out Core.Answer answer);
        public abstract bool FindSoul(int soulId, out Core.Soul soul);
        public abstract bool FindAvatar(int avatarId, out Core.Avatar avatar);
        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out Core.Scene scene);

        protected bool HandleEvent(DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceEventRouter.Instance.Route(GetDevice(), eventCode, parameters, out errorMessage);
        }

        protected bool HandleOperationResponse(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationResponseRouter.Instance.Route(GetDevice(), operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract bool Connect(string serverAddress, int port, string applicationName);
        public abstract void Process();
        public abstract void Disconnect();
        public abstract void SendOperation(DeviceOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
