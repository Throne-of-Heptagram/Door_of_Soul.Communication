using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initialize(CommunicationService instance)
        {
            Instance = instance;
        }

        public event Action<bool> OnProxyServerConnectStatusChanged;

        private bool proxyServerConnected;
        public bool ProxyServerConnected
        {
            get { return proxyServerConnected; }
            protected set
            {
                proxyServerConnected = value;
                OnProxyServerConnectStatusChanged?.Invoke(proxyServerConnected);
            }
        }

        public abstract bool IsSceneServerConnected(string sceneServerName);

        public abstract bool FindAnswer(int answerId, out VirtualAnswer answer);
        public abstract bool FindSoul(int soulId, out VirtualSoul soul);
        public abstract bool FindAvatar(int avatarId, out VirtualAvatar avatar);
        public abstract bool FindWorld(int worldId, out VirtualWorld world);
        public abstract bool FindScene(int sceneId, out VirtualScene scene);
        public abstract bool FindSceneServerName(int sceneId, out string sceneServerName);

        protected bool HandleEvent(DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }

        protected bool HandleOperationResponse(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract bool ConnectProxyServer(string serverAddress, int port, string applicationName);
        public abstract bool ConnectSceneServer(string serverAddress, int port, string applicationName);
        public abstract void Process();
        public abstract void DisconnectProxyServer();
        public abstract void DisconnectPhysicsServer();
        public abstract void SendProxyServerOperation(DeviceOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendSceneServerOperation(string sceneServerName, DeviceOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
