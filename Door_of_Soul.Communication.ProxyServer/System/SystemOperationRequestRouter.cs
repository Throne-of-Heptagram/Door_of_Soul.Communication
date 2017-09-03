using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
