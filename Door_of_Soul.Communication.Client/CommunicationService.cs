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

        public event Action<string, bool> OnServerConnectStatusChanged;
        private Dictionary<string, bool> serverConnectStatusTable = new Dictionary<string, bool>();
        public void SetServerConnectStatus(string serverName, bool isConnected)
        {
            if(IsServerConnected(serverName))
            {
                serverConnectStatusTable[serverName] = isConnected;
                OnServerConnectStatusChanged?.Invoke(serverName, isConnected);
            }
            else
            {
                serverConnectStatusTable.Add(serverName, isConnected);
            }
        }
        public bool IsServerConnected(string serverName)
        {
            return serverConnectStatusTable.ContainsKey(serverName);
        }

        public abstract bool FindAnswer(int answerId, out VirtualAnswer answer);
        public abstract bool FindSoul(int soulId, out VirtualSoul soul);
        public abstract bool FindAvatar(int avatarId, out VirtualAvatar avatar);
        public abstract bool FindWorld(int worldId, out VirtualWorld world);
        public abstract bool FindScene(int sceneId, out VirtualScene scene);

        public OperationReturnCode HandleEvent(DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }

        public OperationReturnCode HandleOperationResponse(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }

        public abstract bool ConnectServer(string serverAddress, int port, string applicationName);
        public abstract void Process();
        public abstract void DisconnectServer(string applicationName);
        public abstract void SendOperation(string applicationName, DeviceOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
