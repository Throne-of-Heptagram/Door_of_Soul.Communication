using Door_of_Soul.Communication.SceneServer.Device;
using Door_of_Soul.Communication.SceneServer.EndPoint;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer
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

        public abstract Core.Internal.EndPoint GetEndPoint();
        public abstract List<TerminalDevice> GetAllDevices();
        public abstract bool FindDevice(int deviceId, out TerminalDevice device);
        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out TerminalScene scene);


        protected bool HandleOperationRequest(TerminalDevice device, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationRequestRouter.Instance.Route(device, device, operationCode, parameters, out errorMessage);
        }

        protected bool HandleEvent(Core.Internal.EndPoint endPoint, EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointEventRouter.Instance.Route(GetEndPoint(), eventCode, parameters, out errorMessage);
        }

        protected bool HandleOperationResponse(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationResponseRouter.Instance.Route(GetEndPoint(), GetEndPoint(), operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }

        public abstract void SendEvent(TerminalDevice target, DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public abstract bool ConnectHexagrameEntranceServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectHexagrameEntranceServer();
        public abstract void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
