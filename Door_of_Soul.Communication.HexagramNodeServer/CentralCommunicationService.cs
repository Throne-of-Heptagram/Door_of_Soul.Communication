using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class CentralCommunicationService
    {
        public static CentralCommunicationService Instance { get; private set; }
        public static void Initialize(CentralCommunicationService instance)
        {
            Instance = instance;
        }

        public event Action<bool> OnHexagrameCentralServerConnectStatusChanged;

        private bool hexagrameCentralServerConnected;
        public bool HexagrameCentralServerConnected
        {
            get { return hexagrameCentralServerConnected; }
            protected set
            {
                hexagrameCentralServerConnected = value;
                OnHexagrameCentralServerConnectStatusChanged?.Invoke(HexagrameCentralServerConnected);
            }
        }

        public bool HandleForwardOperationRequest<TForwardOperationCode>(TForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramForwardOperationRouter<TForwardOperationCode>.Instance.Route(operationCode, parameters, out errorMessage);
        }

        public abstract bool ConnectHexagrameCentralServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectHexagrameCentralServer();
        public abstract void SendForwardOperation(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
