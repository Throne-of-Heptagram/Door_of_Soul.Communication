using Door_of_Soul.Communication.LoginServer.Device;
using Door_of_Soul.Communication.LoginServer.EndPoint;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer
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

        public OperationReturnCode HandleOperationRequest(TerminalDevice device, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationRequestRouter.Instance.Route(device, operationCode, parameters, out errorMessage);
        }

        public OperationReturnCode HandleEvent(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }

        public OperationReturnCode HandleOperationResponse(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }

        public abstract bool ConnectHexagrameEntranceServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectHexagrameEntranceServer();
        public abstract void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
