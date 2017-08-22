using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initial(CommunicationService instance)
        {
            Instance = instance;
        }

        public event Action<bool> OnHexagrameEntranceServerConnectStatusChanged;

        private bool hexagrameEntranceServerConnected;
        public bool HexagrameEntranceServerConnected
        {
            get { return hexagrameEntranceServerConnected; }
            protected set
            {
                hexagrameEntranceServerConnected = value;
                OnHexagrameEntranceServerConnectStatusChanged?.Invoke(hexagrameEntranceServerConnected);
            }
        }

        public abstract Core.InternalServer.EndPoint GetEndPoint();
        public abstract List<Core.Device> GetAllDevices();
        public abstract bool FindDevice(int deviceId, out Core.Device device);
        public abstract bool FindAnswer(int answerId, out Core.Answer answer);
        public abstract bool FindSoul(int soulId, out Core.Soul soul);
        public abstract bool FindAvatar(int avatarId, out Core.Avatar avatar);
        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out Core.Scene scene);


        protected bool HandleOperationRequest(Core.Device device, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationRequestRouter.Instance.Route(device, device, operationCode, parameters, out errorMessage);
        }

        protected bool HandleEvent(Core.InternalServer.EndPoint endPoint, EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointEventRouter.Instance.Route(GetEndPoint(), eventCode, parameters, out errorMessage);
        }

        protected bool HandleOperationResponse(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationResponseRouter.Instance.Route(GetEndPoint(), GetEndPoint(), operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }

        public abstract void SendEvent(Core.Device target, DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(Core.Device target, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public abstract bool ConnectHexagrameEntranceServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectHexagrameEntranceServer();
        public abstract void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
