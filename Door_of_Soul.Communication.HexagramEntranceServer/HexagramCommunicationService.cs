using System;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class HexagramCommunicationService
    {
        public event Action<bool> OnServerConnectStatusChanged;

        private bool serverConnected;
        public bool ServerConnected
        {
            get { return serverConnected; }
            protected set
            {
                serverConnected = value;
                OnServerConnectStatusChanged?.Invoke(ServerConnected);
            }
        }

        public abstract bool ConnectServer(string serverAddress, int port, string applicationName);
        public abstract void DisconnectServer();
    }
}
