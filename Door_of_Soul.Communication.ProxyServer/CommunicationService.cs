using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer
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
                OnHexagrameEntranceServerConnectStatusChanged?.Invoke(HexagrameEntranceServerConnected);
            }
        }

        public abstract List<TerminalDevice> AllDevices { get; }
        public abstract bool FindDevice(int deviceId, out TerminalDevice device);
        public abstract bool FindAnswer(int answerId, out TerminalAnswer answer);
        public abstract bool FindSoul(int soulId, out Core.Soul soul);
        public abstract bool FindAvatar(int avatarId, out Core.Avatar avatar);


        protected bool HandleOperationRequest(TerminalDevice device, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationRequestRouter.Instance.Route(device, operationCode, parameters, out errorMessage);
        }

        protected bool HandleEvent(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }

        protected bool HandleOperationResponse(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }

        public abstract void SendEvent(TerminalDevice target, DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public abstract bool ConnectHexagrameEntranceServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectHexagrameEntranceServer();
        public abstract void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
