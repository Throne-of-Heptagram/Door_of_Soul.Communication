using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;
using Door_of_Soul.Communication.ProxyServer.System;

namespace Door_of_Soul.Communication.ProxyServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initialize(CommunicationService instance)
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
        public TerminalDevice Device { get; private set; }

        protected CommunicationService()
        {
            TerminalDevice device;
            DeviceFactory.Instance.CreateDevice(
                sendEventMethod: (eventCode, parameters) => 
                {

                },
                sendOperationResponseMethod: (operationCode, returnCode, operationMessage, parameters) => 
                {

                },
                device: out device);
            Device = device;
        }

        public bool HandleOperationRequest(TerminalDevice device, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationRequestRouter.Instance.Route(device, operationCode, parameters, out errorMessage);
        }

        public bool HandleEvent(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }

        public bool HandleOperationResponse(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }

        public abstract bool ConnectHexagrameEntranceServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectHexagrameEntranceServer();
        public abstract void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
